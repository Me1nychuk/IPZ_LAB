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
        static void Main(string[] args)
        {

            CInternet internet = CInternet.GetInstance();
            Pc pc = new Pc(internet);
            Pc pc1 = new Pc(internet);
            Pc pc2 = new Pc(internet);
            Air_conditioning air_Conditioning = new Air_conditioning();

            Customer customer1 = new Customer();
            Customer customer2 = new Customer();
            Customer customer3 = new Customer();


            Junior junior = new Junior(pc);
            Middle middle = new Middle(pc1);
            Senior senior = new Senior(pc2, air_Conditioning);


            Boss boss = new Boss(junior, middle, senior);

            customer1.Task(ref boss);
            customer2.Task(ref boss);
            customer3.Task(ref boss);

            boss.Look();


            Stack myStack = new Stack();
        }

    }



    #region Clases
    abstract class Person
    {
        #region Feilds

        static int _count = 0;
        private string _name;
        private int _age;
        #endregion




        #region Constructors
        public Person()
        {
            Random rnd = new Random();


            var names = (Names)rnd.Next(0, 10);

            _name = names.ToString();

            _age = rnd.Next(18, 45);

            _count++;


            Console.WriteLine($"\t\tУ нас з'явилась нова людина. \n \t\tЇї номер :{_count} | Ім'я : {_name} | Вік : {_age} ");
            Console.WriteLine("//////////////////////////");
        }

        #endregion
        #region Enums
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
        #endregion
        #region Properties
        public int Age
        { get { return _age; } set { _age = value; } }
        public string Name
        { get { return _name; } set { _name = value; } }
        #endregion

    }
    abstract class Employee : Person
    {

        #region Feilds
        protected string _task;
        public bool knowlge;
        #endregion
        #region Constructors
        public Employee() { }

        #endregion

        #region Methods
        public abstract string Work(string task);

        #endregion

    }


    class Boss : Person
    {
        #region Feilds
        Junior junior;
        Middle middle;
        Senior senior;

        Stack myStack = new Stack();

        #endregion


        #region Constructors
        public Boss(in Junior junior, in Middle middle, in Senior senior)
        {


            this.junior = junior;
            this.middle = middle;
            this.senior = senior;


        }
        #endregion


        #region Methods
        public void Look()
        {
            Console.WriteLine("Босс показує усі виконані завдання");
            IEnumerable myCollection = myStack;

            foreach (Object obj in myCollection)
                Console.Write("    {0}", obj);
            Console.WriteLine();


        }


        public string TaskCheck(string task)
        {
            Console.WriteLine("Босс отримав завдання від клієнта та почав вирішувати кому його дати");
            myStack.Push(task);
            Console.WriteLine("Також босс записав це завдання у свій блокнотик");

            Console.Write("Отримав :\t");
            if (task.Length < 5)
            {
                return (Developers(1, ref task));
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


        string Developers(int number, ref string task)
        {
            string res;
            switch (number)
            {
                case 1:
                    res = (junior.Work(task));
                    break;
                case 2:
                    res = (middle.Work(task));
                    break;
                case 3:
                    res = (senior.Work(task));
                    break;
                default:
                    res = "";
                    break;
            }

            return res;

        }

        #endregion
    }


    class Pc
    {
        #region Feilds
        public CInternet internet
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public Pc(in CInternet internet)
        {
            this.internet = internet;
        }
        #endregion


        #region Methods
        public void OnPC()
        { Console.WriteLine("Був увімкнутий ПК"); }
        public string Work()
        {
            Console.WriteLine("Девелопер почав писати код");
            Cod cod = new Cod();

            return (cod.Compilation() + " ");
        }
        #endregion


    }


    #region Developers
    class Junior : Employee
    {
        #region Feilds
        Pc pc;
        #endregion

        #region Constructors
        public Junior(Pc pc)
        {

            this.pc = pc;


        }

        internal Pc Pc
        {
            get => default;
            set
            {
            }
        }
        #endregion

        #region Methods
        public override string Work(string task)
        {
            Console.WriteLine(" Junior отримав своє завдання і почав працювати");
            pc.OnPC();
            Random rnd = new Random();

            if (rnd.Next(0, 100) % 2 == 0 || rnd.Next(0, 100) % 5 == 0)
            {
                while (!knowlge)
                {
                    knowlge = pc.internet.GiveInfo();
                }

            }


            return (pc.Work());
        }
        #endregion
    }

    class Middle : Employee
    {
        #region Feilds
        Pc pc;
        #endregion

        #region Constructors
        public Middle(Pc pc)
        {
            this.pc = pc;


        }
        #endregion



        #region Methods
        public override string Work(string task)
        {
            Console.WriteLine(" Middle отримав своє завдання і почав працювати");
            pc.OnPC();


            return (pc.Work());
        }
        #endregion

    }

    class Senior : Employee
    {
        #region Feilds
        Air_conditioning air_Conditioning;
        Pc pc;
        #endregion

        #region Constructors
        public Senior(Pc pc, Air_conditioning air_Conditioning)
        {
            this.pc = pc;
            this.air_Conditioning = air_Conditioning;

        }
        #endregion


        #region Methods
        public override string Work(string task)
        {
            Console.WriteLine(" Senior отримав своє завдання і почав працювати");

            air_Conditioning.Work();
            pc.OnPC();

            return (pc.Work());

        }
        #endregion
    }

    #endregion

    class Customer : Person
    {
        #region Feilds
        string result;
        #endregion

        #region Methods
        public void Task(ref Boss boss)
        {

            Console.WriteLine("Вкажіть ваше завдання: ");
            string task = Console.ReadLine();

            Console.WriteLine("Клієнт має завдання і передає його далі");

            result = boss.TaskCheck(task);


            Console.WriteLine($"////////// RESULT: {result} ////////////////");
            Console.WriteLine();
        }
        #endregion

    }

    class Cod
    {
        #region Methods
        public int Compilation()
        {
            Console.WriteLine("Start progress");
            Random rnd = new Random();

            int bbb = rnd.Next(0, 100);
            Console.WriteLine("Task done");
            return bbb;
        }
        #endregion

    }

    public sealed class CInternet
    {


        private CInternet() { }

        private static CInternet _instance;
        #region Methods
        public static CInternet GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CInternet();
            }
            return _instance;
        }

        public bool GiveInfo()
        {
            Console.WriteLine("Пошук інформації");
            Random rnd = new Random();

            if (rnd.Next(0, 100) % 20 == 0)
            {
                return false;
            }

            return true;
        }

        #endregion
    }

    class Air_conditioning
    {
        #region Feilds
        int temp;
        #endregion


        #region Methods
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

        #endregion
    }
    #endregion


}

