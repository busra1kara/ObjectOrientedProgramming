using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgramming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sayi1 = 10;
            int sayi2 = 20;
            sayi1 = sayi2;
            sayi2 = 100;
            Console.WriteLine(sayi1); // Değer tiplerde değişkene değer üzerinden atama yapılır. Sayi1'in değeri
                                     // değişmediği için sayi1 değişmez

            int[] sayilar1 = new int[] {1, 2, 3};
            int[] sayilar2 = new int[] {10, 20, 30};
            sayilar1 = sayilar2;
            sayilar2[0] = 1000;
            Console.WriteLine(sayilar1[0]); //Referans değeri değiştiğinde referans tiplerde referans alan değişkenin de
                                           //değeri değişir.

            //CreditManager creditManager = new CreditManager();
            ////creditManager.Calculate();
            ////creditManager.Save();

            Customer customer = new Customer();
            customer.Id = 1;
            customer.City = "Ankara";

            Customer customer1 = new Customer();
            Customer customer2 = new Person();
            Customer customer3 = new Company();
            customer1.Id = 1;
            customer2.Id = 2;
            //(customer2 as Person).FirstName = "Selim";
            customer3.Id = 3;

            Person person = new Person();
            person.Id = 1;
            person.FirstName = "Büşra";
            person.LastName = "Kara";
            person.City = "Eskişehir";
            Company company = new Company();
            company.Id = 2;
            company.CompanyName = "ASUS";
            company.TaxNumber = "123456789";

            //CustomerManager customerManager = new CustomerManager(customer2);
            //customerManager.Save();

            CustomerManager customerManager = new CustomerManager(new Customer(), new TeacherCreditManager());
            customerManager.GiveCredit();
            CustomerManager customerManager2 = new CustomerManager(new Customer(), new MilitaryCreditManager());
            customerManager2.GiveCredit();

            Console.ReadLine();
        }

        class CreditManager
        {
            public void Calculate(int creditType)
            {
                if(creditType == 1)
                {

                }
                if (creditType == 2)
                {

                }
            }

            public void Save() 
            {
                Console.WriteLine("Kaydedildi");
            }
        }

        interface ICreditManager
        {
            void Calculate();
            void Save();
        }

        abstract class BaseCreditManager : ICreditManager
        {
            public abstract void Calculate();
            public virtual void Save()
            {
                Console.WriteLine("Kaydedildi");
            }
        }

        class TeacherCreditManager : BaseCreditManager, ICreditManager
        {
            public override void Calculate()
            {
                Console.WriteLine("Öğretmen kredisi hesaplandı");
            }

            public override void Save()
            {
                Console.WriteLine("Öğretmenler ek kredi");
                base.Save();
                Console.WriteLine("Beş yıl geçerli");
            }
        }

        class MilitaryCreditManager : BaseCreditManager, ICreditManager
        {
            public override void Calculate()
            {
                Console.WriteLine("Askerlik kredisi hesaplandı");
            }

            //public void Save()
            //{
            //    throw new NotImplementedException();
            //}
        }

        class Customer
        {
            public Customer()
            {

            }
            public int Id { get; set; }
            public string City { get; set; }
        }

        class Person : Customer
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string NationalIdentity { get; set; }
        }

        class Company : Customer
        {
            public string CompanyName { get; set; }
            public string TaxNumber { get; set; }
        }

        class CustomerManager
        {
            private Customer _customer;
            private ICreditManager _creditManager;
            public CustomerManager(Customer customer, ICreditManager creditManager)
            {
                _customer = customer;
                _creditManager = creditManager;

            }
            //public CustomerManager(Person person)
            //{
            //    _customer = person;
            //}
            //public CustomerManager(Company company)
            //{
            //    _customer = company;
            //}
            public void Save()
            {
                //Console.WriteLine((_customer as Person).FirstName);
                //Console.WriteLine((_customer as Company).CompanyName);
            }

            public void GiveCredit()
            {
                _creditManager.Calculate();
                _creditManager.Save();
                Console.WriteLine("Kredi verildi");
            }
        }
    }
}
