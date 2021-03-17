using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        // Kullanıcıları hiyerarşik bir model çerçevesine alıp veritabanına toplu bir şekilde ekleme, güncelleme işlemini gerçekleştirebiliriz
        static void Main(string[] args)
        {
            Employee gokberk = new Employee { Name = "Gokberk" };
            Employee guven = new Employee { Name = "Guven" };
            Employee gulcin = new Employee { Name = "Gulcin" };
            Employee ahmet = new Employee { Name = "Ahmet" };

            gokberk.AddSubordinate(guven);
            gokberk.AddSubordinate(gulcin);

            guven.AddSubordinate(ahmet);

            Console.WriteLine(gokberk.Name);
            foreach (Employee manager in gokberk)
            {
                Console.WriteLine(">" + manager.Name);
                foreach (var employee in manager)
                {
                    Console.WriteLine(">>" + employee.Name);
                }
            }

            //var a = gokberk.GetEnumerator();
            //a.MoveNext();
            //Console.WriteLine(((Employee)a.Current).Name);
            //a.MoveNext();
            //Console.WriteLine(((Employee)a.Current).Name);
            //a.Dispose();

        }
    }

    interface IPerson
    {
        string Name { get; set; }
    }

    class Employee : IPerson, IEnumerable<IPerson>
    {
        List<IPerson> _subordinates = new List<IPerson>();

        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }
        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }
        public string Name { get; set; }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                // Enumerable olarak dönmesi için yield return ifadesi kullanılır.
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
