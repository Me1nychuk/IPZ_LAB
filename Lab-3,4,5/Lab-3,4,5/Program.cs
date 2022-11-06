using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Lab_3_4_5
{
    internal class Program
    {
        abstract class Person
        {
            

            static int count = 0;

            public Person()
            {
                Random rnd = new Random();


                var names = (Names)rnd.Next(0, 10);

                _name = names.ToString();

                _age = rnd.Next(18, 45);

                count++;

                
                Console.WriteLine($"Був створений новий екзепляр класу персон(або нащадок цього класу)  Його номер :{count} | Ім'я : {_name} | Вік : {_age} ");
                Console.WriteLine("//////////////////////////");
            }
            private string _name;
            private int _age;


            enum Names
            {
                Tom,
                Jack,
                Peter,
                Mark,
                Edvard,
                Zak,
                Harry,
                Leo,
                Gary,
                Sony,
                Rick
            
            }
            public int Age
            { get { return _age; } set { _age = value; } }
            public string Name
            { get { return _name; } set { _name = value; } }

            public void Deconstruct(out string personName, out int personAge)
            {
                personName = _name;
                personAge = _age;
            }
        }
        abstract class Employee : Person
        {
            public string task;
            public bool knowlge;
            public Employee() { }


            public virtual string Work(string task)
            {
                return null;
            }
        }

       
        class Boss : Person
        {
            Junior junior;
            Middle middle;
            Senior senior;

            Stack myStack = new Stack();


           
            public Boss(ref Junior junior ,ref Middle middle, ref Senior senior )
            {


                this.junior = junior;
                this.middle = middle;
                this.senior = senior;


            }

            public void Look()
            {
                Console.WriteLine("Босс показує усі виконані завдання");
                IEnumerable myCollection = myStack;

                foreach (Object obj in myCollection)
                    Console.Write("    {0}", obj);
                Console.WriteLine();


            }
            
           
            public   string TaskCheck(string task)
            {
                Console.WriteLine("Босс отримав завдання від клієнта та почав вирішувати кому його дати");
                myStack.Push(task);
                Console.WriteLine("Також босс записав це завдання у свій блокнотик");

                Console.Write("Отримав :\t");
                if (task.Length < 5)
                {
                  return  (Developers(1, ref task));
                }
                else if (task.Length > 10)
                {
                    return (Developers(3, ref task));
                }
                else
                {
                    return (Developers(2, ref task));
                }




            }


            string Developers(int number,ref string task) 
            {
                string res;
                switch (number)
                {
                    case 1:
                        res = (junior.Work(task));
                        break;
                    case 2:
                        res =  (middle.Work(task));
                        break;
                    case 3:
                        res =  (senior.Work(task));
                        break;
                    default:
                        res = "";
                        break;
                }

                return res;
                
            }
        }


        class Pc
        {
            public Internet internet;
            public Pc(ref Internet internet)
            { 
                this.internet = internet;
            }
           
            public void OnPC()
            { Console.WriteLine("Був увімкнутий ПК"); }
            public string Work()
            {
                Console.WriteLine("Девелопер почав писати код");
                Cod cod = new Cod();

                return (cod.Compilation() + " ");
            }

           

        }


        #region Developers
        class Junior : Employee
        {
            Pc pc;
            public Junior(Pc pc)
            {

                this.pc = pc;


            }
            public override string Work(string task)
            {
                Console.WriteLine(" Junior отримав своє завдання і почав працювати");
                pc.OnPC();
                Random rnd = new Random();

                if (rnd.Next(0, 100) % 2 == 0 || rnd.Next(0,100)%5==0)
                {
                    while (!knowlge)
                    {
                        knowlge = pc.internet.GiveInfo();
                    }

                }
                

                return (pc.Work()); 
            }
        }

        class Middle : Employee
        {
            Pc pc;
            public Middle(Pc pc)
            {
                this.pc = pc;


            }
            public override string Work(string task)
            {
                Console.WriteLine(" Middle отримав своє завдання і почав працювати");
                pc.OnPC();
                

                return (pc.Work());
            }

        }

        class Senior : Employee
        {
            Air_conditioning air_Conditioning;
            Pc pc;
            public Senior(Pc pc, Air_conditioning air_Conditioning)
            {
                this.pc = pc;
                this.air_Conditioning = air_Conditioning;

            }
            public override string Work(string task)
            {
                Console.WriteLine(" Senior отримав своє завдання і почав працювати");

                air_Conditioning.Work();
                pc.OnPC();
               
                return (pc.Work());

            }
        }

        #endregion

        class Customer : Person
        {
            string result;

           public Customer()
            {

            }
            public void Task(ref Boss boss)
            {

                Console.WriteLine("Вкажіть ваше завдання: ");
                string task = Console.ReadLine();

                Console.WriteLine("Клієнт має завдання і передає його далі");

               result = boss.TaskCheck(task);


                Console.WriteLine($"////////// RESULT: {result} ////////////////");
            }

        }

        class Cod
        {
            public int Compilation()
            {
                Console.WriteLine("Start progress");
                Random rnd = new Random();

                int bbb = rnd.Next(0, 100);
                    Console.WriteLine("Task done");
                return bbb;
            }

        }

        class Internet
        { 
            public bool GiveInfo()
            {
                Console.WriteLine("Пошук інформації");
                Random rnd = new Random();

                if (rnd.Next(0, 100) % 20 == 0)
                {
                    return false ;
                }

                    return true;
            }
        }

        class Air_conditioning
        {
            int temp;

            public Air_conditioning()
            {

            }

            public void Work()
            {
                Console.WriteLine("Був увімкнутий кондиціонер");

                Random rn = new Random();
                temp = rn.Next(-5, 25);

                Console.WriteLine("Кондиціонер визначив температуру в кімнаті");
                if (temp < 15)
                { Cold(); }
                else if (temp > 20) { Hot(); }
            }



            public void Cold()
            {
                Console.WriteLine("Кондиціонер збільшив температуру до комфортної");
                temp = 18;
            }

            public void Hot()
            {
                Console.WriteLine("Кондиціонер зменшив температуру до комфортної");

                temp = 16;
            }
        }


        static void Main(string[] args)
        {
            Internet internet = new Internet();
            Pc pc = new Pc(ref internet);
            Pc pc1 = new Pc(ref internet);
            Pc pc2 = new Pc(ref internet);
            Air_conditioning air_Conditioning = new Air_conditioning();

            Customer customer1 = new Customer();
            Customer customer2 = new Customer();
            Customer customer3 = new Customer();


            Junior junior = new Junior(pc);
            Middle middle = new Middle(pc1);
            Senior senior = new Senior(pc2, air_Conditioning);


            Boss boss = new Boss(ref junior, ref middle, ref senior);

            customer1.Task(ref boss);
            customer2.Task(ref boss);
            customer3.Task(ref boss);

            boss.Look();


            Stack myStack = new Stack();
        }
    }
}
