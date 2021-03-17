using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    // Belirli bir stratejiye göre ilgili methodun çalıştırılmasıdır.
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.CreditCalculaterBase = new After2010CreditCalculator();
            //customerManager.CreditCalculaterBase = new Before2010CreditCalculator();
            customerManager.SaveCredit();
        }
    }

    abstract class CreditCalculatorBase
    {
        public abstract void Calculate();
    }

    class Before2010CreditCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit calculated using Before2010");
        }
    }

    class After2010CreditCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit calculated using After2010");
        }
    }

    class CustomerManager
    {
        public CreditCalculatorBase CreditCalculaterBase { get; set; }
        public void SaveCredit()
        {
            Console.WriteLine("Customer Manager Business");
            this.CreditCalculaterBase.Calculate();
        }
    }
}
