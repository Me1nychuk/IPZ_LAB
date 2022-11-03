using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Необхідно сворити додаток за допомогою якого можна буде імітувати роботу обмінника валют.

namespace Lab2
{
    class Program
    {
        #region Methods
        static void Main(string[] args) // Point of enter
        {
            #region Password
     
              Random rnd = new Random();
              int x = rnd.Next(3, 20);
            
            string[] truePassw = { x.ToString() };//вірний пароль
            Lab1.Program.Main(truePassw);
            Console.Write("Key = " + x + ". Enter the password = ");//ключ = x. Введіть пароль
            double customerPassw = Convert.ToDouble(Console.ReadLine());//пароль, отриманий від клієнта

            
           
            #endregion

            if (Convert.ToDouble(truePassw[0]) == customerPassw)
            {
                Computer computer = new Computer();

                Employee employee = new Employee(computer);//працівник
                Customer customer = new Customer();//клієнт
                customer.StartExchange(employee);
            }
            else
            {
                Console.WriteLine("We're simply sitting here");//Ми просто сидимо тут
            }
        }
        #endregion
    }
    class Customer //клієнт
    {
        
        
        #region Properties
        string _name = "Melnychuk Sviatoslav V.";
        #endregion

        #region Methods
        public void StartExchange(Employee employee)//початок обміну
        {
            int punct;
            double customerStartMoney;//початкові гроші клієнта
            double? customerResultMoney;//результуючі гроші клієнта
            string[] names = { "Jonny", "Tom", "Jack" };
         
            employee.Question1();//питання 1
            punct = Convert.ToInt32(Console.ReadLine());
            switch (punct)
            {
                case 0:
                    break;
                case 1:
                    employee.Question2("grn to dollar" , ref names);//питання 2
                    customerStartMoney = Convert.ToDouble(Console.ReadLine());
                    customerResultMoney = employee.Exchange("grn to dollar", customerStartMoney);
                    //_name + " дав " + customerStartMoney + " грн і отримав " + customerResultMoney + " доларів"
                    if (customerResultMoney != null) Console.WriteLine(_name + " get " + customerStartMoney + " grn and received " + customerResultMoney + " dollars");
                    break;
                case 2:
                    employee.Question2("grn to euro", ref names);
                    customerStartMoney = Convert.ToDouble(Console.ReadLine());
                    customerResultMoney = employee.Exchange("grn to euro", customerStartMoney);
                    //_name + " дав " + customerStartMoney + " грн і отримав " + customerResultMoney + " євро"
                    if (customerResultMoney != null) Console.WriteLine(_name + " get " + customerStartMoney + " grn and received " + customerResultMoney + " euros");
                    break;
                case 3:
                    employee.Question2("dollar to grn", ref names);
                    customerStartMoney = Convert.ToDouble(Console.ReadLine());
                    customerResultMoney = employee.Exchange("dollar to grn", customerStartMoney);
                    //_name + " дав " + customerStartMoney + "  доларів і отримав " + customerResultMoney + " грн " 
                    if (customerResultMoney != null) Console.WriteLine(_name + " get " + customerStartMoney + " dollars and received " + customerResultMoney + " grns ");
                    break;

                case 4:
                    employee.Question2("euro to grn", ref names);
                    customerStartMoney = Convert.ToDouble(Console.ReadLine());
                    customerResultMoney = employee.Exchange("euro to grn", customerStartMoney);
                    //_name + " дав " + customerStartMoney + " євро і отримав " + customerResultMoney + " грн"
                    if (customerResultMoney != null) Console.WriteLine(_name + " get " + customerStartMoney + " euros and received " + customerResultMoney + " grns");
                    break;

                case 5:
                    employee.Question2("lir to grn", ref names);
                    customerStartMoney = Convert.ToDouble(Console.ReadLine());
                    customerResultMoney = employee.Exchange("lir to grn", customerStartMoney);
                    //_name + " дав " + customerStartMoney + " євро і отримав " + customerResultMoney + " грн"
                    if (customerResultMoney != null) Console.WriteLine(_name + " get " + customerStartMoney + " lirs and received " + customerResultMoney + " grns");
                    break;

                case 6:
                    employee.Question2("grn to lir", ref names);
                    customerStartMoney = Convert.ToDouble(Console.ReadLine());
                    customerResultMoney = employee.Exchange("grn to lir", customerStartMoney);
                    //_name + " дав " + customerStartMoney + " євро і отримав " + customerResultMoney + " грн"
                    if (customerResultMoney != null)
                    {
                        Console.WriteLine(_name + " get " + customerStartMoney + " grns and received " + customerResultMoney + " lirs");
                    }
                    break;
                default:
                    Console.WriteLine("It's imposible!");//це неможливо
                    return;
            }
        }
        #endregion
    }
    class Employee //працівник обмінника
    {
        #region Properties //властивості
        public string _name;
        Computer _computer; 

        float? _grnAmount = 2147483647;//кількість гривень в касі
        double? _dollarAmount = 65535;//кількість доларів в касі
        double? _euroAmount = 128;//кількість євро в касі
        double? _lirAmount = 345;
        #endregion

        #region Methods
        public Employee(Computer computer)
        {
            _computer = computer;
        }
        public Employee(Computer computer,string name )
        {
            _computer = computer;
            _name = name;
        }
        public double? Exchange(string currencyOut, double customerStartMoney)
        {
            double? resultAmount = _computer.Exchange(currencyOut, customerStartMoney);
            switch (currencyOut)
            {
                case "grn to dollar":
                    if (_dollarAmount - resultAmount > 0)
                    {
                        _dollarAmount -= resultAmount;
                        _grnAmount += (float)customerStartMoney;
                    }
                    else 
                    {
                        Console.WriteLine("Sorry, we have problems with _dollarAmount");
                        return null;
                    }

                    break;

                //////////////////////////////////////////////////
                case "grn to euro":
                    if (_euroAmount > resultAmount  )
                    {
                        _euroAmount -= resultAmount;
                        _grnAmount += (float)customerStartMoney;
                    }
                    else Console.WriteLine("Sorry, we have problems with _euroAmount"); return null;
                    break;

                //////////////////////////////////////////////////

                case "dollar to grn":
                    if (_grnAmount - resultAmount > 0)
                    { 
                        _grnAmount -= (float)resultAmount;
                        _dollarAmount += customerStartMoney;
                    }
                    else Console.WriteLine("Sorry, we have problems with _grnAmount "); return null;
                    break;

                //////////////////////////////////////////////////

                case "euro to grn":
                    if (_grnAmount - resultAmount > 0)
                    {
                        _grnAmount -= (float)resultAmount;
                        _euroAmount += customerStartMoney;
                    }
                    else Console.WriteLine("Sorry, we have problems with _grnAmount"); return null;
                    break ;
                    //////////////////////////////////////////////////


                    
                case "lir to grn":
                    if (_grnAmount - resultAmount > 0)
                    {
                        _grnAmount -= (float)resultAmount;
                        _lirAmount += customerStartMoney;
                    }
                    else Console.WriteLine("Sorry, we have problems with _grnAmount"); return null;
                    break;

                ////////////////////////////////////////

                case "grn to lir":
                    if (_lirAmount - resultAmount > 0)
                    {
                        _grnAmount += (float)resultAmount;
                        _lirAmount -= customerStartMoney;
                    }
                    else Console.WriteLine("Sorry, we have problems with _lirAmount"); return null;
                    break;
                default:
                    return null;
            }
            


            return resultAmount;
        }
        public string GetName() { return _name; }
        public void Question1()
        {
            Console.WriteLine("Choose a punct:");//виберіть пункт
            Console.WriteLine("0. End of exchange");//завершення обміну
            Console.WriteLine("1. Exchange grn to dollar");//обміняти гривні на долари
            Console.WriteLine("2. Exchange grn to euro");//обміняти гривні на євро
            Console.WriteLine("3. Exchange dollar to grn");//обміняти долари на гривні
            Console.WriteLine("4. Exchange euro to grn");//обміняти євро на гривні
            Console.WriteLine("5. Exchange grn to lir");//обміняти долари на гривні
            Console.WriteLine("6. Exchange lir to grn");//обміняти євро на гривні
            



        }
        public void Question2(string currencyOut, ref string[] names)
        {
            Random rnd = new Random();
           
            string name = names[rnd.Next(0, names.Length - 1)];

            Console.Write("Today employee is " + name + ". ");//Сьогодні працівником є name.
            Console.WriteLine("How many " + currencyOut + " you want to exchange?");//Скільки currencyOut Ви хочете обміняти
        }
        #endregion

    }
    class Computer //комп'ютер
    {
        #region Properties
        double _dollarRateSell = 41.6;//ціна продажу
        double _dollarRateBuy = 41.5;//ціна купівлі
        double _euroRateSell = 40.9;//ціна продажу
        double _euroRateBuy = 40.8;//ціна купівлі
        double _lirRateSell = 1.9;
        double _lirRateBuy = 1.8;
       


        public Computer()
        { }
        public Computer(double dollarRateSell = 41.6, double dollarRateBuy = 41.5, double euroRateSell = 40.9, double euroRateBuy = 40.8, double lirRateSell = 1.9,double lirRateBuy = 1.8)
        {
            _dollarRateSell = dollarRateSell;
            _dollarRateBuy = dollarRateBuy;
            _euroRateSell = euroRateSell;
            _euroRateBuy = euroRateBuy;
            _lirRateBuy = lirRateBuy;
            _lirRateSell = lirRateSell;
        }

                #endregion

        #region Methods
        public double? Exchange(string currencyOut, double customerStartMoney)
        {
            switch (currencyOut)
            {
                case "grn to dollar":
                    return customerStartMoney / _dollarRateBuy;
                case "grn to euro":
                    return customerStartMoney / _euroRateBuy;
                case "dollar to grn":
                    return customerStartMoney * _dollarRateSell;
                case "euro to grn":
                    return customerStartMoney * _euroRateSell;
                case "lir to grn":
                    return customerStartMoney * _lirRateSell;
                case "grn to lir":
                    return customerStartMoney / _lirRateBuy;

                default:
                    return null;
            }
        }
        #endregion
    }
}
