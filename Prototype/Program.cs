using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Program
    {
        // Temel sınıftan bir prototip(Temel nesne) oluşturup yeni nesne klonlanarak üzerinde çalışmalar yapılır. Nesne üretimi maliyetlerini minimize etmektir
        static void Main(string[] args)
        {
            Customer customer = new Customer {
                FirstName = "Gokberk",
                LastName = "Yıldırım",
                City = "Ankara",
                Id = 1
            };

            var customer1 = (Customer)customer.Clone();
            customer1.FirstName = "Guven";

            Console.WriteLine(customer.FirstName);
            Console.WriteLine(customer1.FirstName);

        }
    }

    public abstract class Person
    {
        public abstract Person Clone();

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Customer: Person
    {
        public string City { get; set; }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }

    public class Employee : Person
    {
        public decimal Salary { get; set; }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }
}
