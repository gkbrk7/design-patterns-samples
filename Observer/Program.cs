using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    // Kendisine abone olunan sistemlerin bir işlem olduğunda devreye girmesini sağlayan tasarım desenidir.
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager();
            var customerObserver = new CustomerObserver();
            productManager.Attach(customerObserver);
            productManager.Attach(new EmployeeObserver());
            productManager.UpdatePrice();

            productManager.Detach(customerObserver);
            productManager.UpdatePrice();
        }
    }

    class ProductManager
    {
        List<Observer> _observers = new List<Observer>();
        public void UpdatePrice()
        {
            Console.WriteLine("Product Price Changed");
            Notify();
        }

        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        private void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }

    abstract class Observer
    {
        public abstract void Update();
    }

    class CustomerObserver : Observer
    {
        public override void Update() => Console.WriteLine("Message to Customer: Product Price Changed!!");
    }

    class EmployeeObserver : Observer
    {
        public override void Update() => Console.WriteLine("Message to Employee: Product Price Changed!!");
    }
}
