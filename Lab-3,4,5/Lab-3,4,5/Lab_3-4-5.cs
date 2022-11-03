using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_4_5
{
    internal class Program
    {

        public static void UseParams(params int[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                Console.Write(list[i] + " ");
            }

        }



    

        class Person
        {
            public  const int C = 12;

            static int count = 0;

            public Person()
            {
                Random rnd = new Random();


                var names = (Names)rnd.Next(0, 7);

                name = names.ToString();

                age = rnd.Next(18, 45);

                count++;

                Console.WriteLine("//////////////////////////");
                Console.WriteLine($"Був створений новий екзепляр класу персон(або нащадок цього класу)  Його номер :{count} | Ім'я : {name} | Вік : {age} ");
                Console.WriteLine("//////////////////////////");
            }
            private string name;
            private int age;


            enum Names
            {
                Tom,
                Jack,
                Peter,
                Mark,
                Edvard,
                Zak,
                Harry,
                Leo
            
            }
            public int Age
            { get { return age; } set { age = value; } }
            public string Name
            { get { return name; } set { name = value; } }

            public void Deconstruct(out string personName, out int personAge)
            {
                personName = name;
                personAge = age;
            }
        }
        class Employee : Person
        {
           public string task;
            public Employee() { }
            public Employee(ref string task)
            {
                this.task = task;

                
                if (this.task!=null)
                {
                    Work( );
                }
            }

            public virtual void Work() 
            {       

            }
        }
        class Boss : Person
        {
            public void Work(ref string task)
            {
                Console.WriteLine("Босс отримав завдання і вибирає хто буде його виконувати");
                Console.WriteLine("Selest developer : ");
                Developers(Int32.Parse(Console.ReadLine()), ref task);


            }

            void Developers(int number, ref string task) 
            {
                switch (number)
                {
                    case 1:
                        Junior junior = new Junior(ref task);
                        break;
                    case 2:
                        Middle middle = new Middle(ref task);
                        break;
                    case 3:
                        Senior senior = new Senior(ref task);
                        break;
                    default:
                        break;
                }
            }
        }


        class Pc
        {
            bool knowledge;
            public Pc()
            { 
                knowledge = true;
                Work();
            }
            public Pc(int d) 
            {
                knowledge = false;
                Work();
            }

            public void Work()
            {
                Console.WriteLine("ПК був запущений");
                if (knowledge == false)
                {
                    Internet internet = new Internet();
                    internet.GiveInfo();
                }

                Cod cod = new Cod();
                cod.Compilation();
            }

            int b = Person.C;

        }

        class Junior : Employee
        {
            public Junior(ref string task)
            {
                this.task = task;
                Console.WriteLine("Junior отримав завдання");

                if (this.task != " ")
                {
                    Console.WriteLine("Junior почав виконувати завдання");
                    Work();
                }
            }
            public override void Work()
            {
                Pc pc = new Pc(1);
            }
        }

        class Middle : Employee
        {
            public Middle(ref string task)
            {
                this.task = task;
                Console.WriteLine("Middle отримав завдання");


                if (this.task != " ")
                {
                    Console.WriteLine("Middle почав виконувати завдання");
                    Work();
                }
            }
            public override void Work()
            {
                Pc pc = new Pc();
            }

        }

        class Senior : Employee
        {
            public Senior(ref string task)
            {
                this.task = task;
                Console.WriteLine("Senior отримав завдання");

                if (this.task != " ")
                {
                    Console.WriteLine("Senior почав виконувати завдання");
                    Work();
                }
            }
            public override void Work()
            {   Air_conditioning air_Conditioning = new Air_conditioning();

                Pc pc = new Pc();

            }
        }

        class Customer : Person
        {

            public void Task()
            {
                Console.WriteLine("Створений клієнт");
                Console.WriteLine("Task : ");
                string task = Console.ReadLine();

                Console.WriteLine("Клієнт має завдання і передає його далі");
                Boss boss = new Boss();

                boss.Work(ref task);
            }

        }

        class Cod
        {
            public void Compilation()
            {
                Console.WriteLine("Start progress");
                Console.WriteLine("Task done");
            }

        }

        class Internet
        { 
            public void GiveInfo()
            {
                Console.WriteLine("Інтернет дав інформацію");
            }
        }

        class Air_conditioning
        {
            int temp;

            public Air_conditioning()
            {
                Console.WriteLine("Був увімкнутий кондиціонер");

                Random rn = new Random();
                temp = rn.Next(-5, 25);

                Console.WriteLine("Кондиціонер визначив ткмпературу в кімнаті");
                if (temp < 15)
                {Cold();}
                else if(temp > 20) { Hot(); }
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

            
            Customer customer = new Customer();

            customer.Task();


            UseParams(1, 2, 3, 4);

            (string name, int age) = customer;

            Console.WriteLine(name);    
            Console.WriteLine(age);
           

        }
    }
}
