using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    // Birbirine benzeyen veya hiyerarşik nesnelerin aynı metodunun çağrılması, birisi üzerinden diğerlerinin çağrılması
    class Program
    {
        static void Main(string[] args)
        {
            Manager gokberk = new Manager() { Name = "Gokberk", Salary= 5000};
            Manager guven = new Manager() { Name = "Guven", Salary = 4500 };
            Worker gulcin = new Worker { Name = "Gulcin", Salary = 2500 };
            Worker gizem = new Worker { Name = "Gizem", Salary = 2250 };

            gokberk.SubOrdinates.Add(guven);
            guven.SubOrdinates.Add(gulcin);
            guven.SubOrdinates.Add(gizem);

            OrganizationalStructure organizationalStructure = new OrganizationalStructure(gokberk);

            PayrollVisitor payrollVisitor = new PayrollVisitor();
            PayriseVisitor payriseVisitor = new PayriseVisitor();

            organizationalStructure.Accept(payrollVisitor);
            organizationalStructure.Accept(payriseVisitor);
        }
    }

    class OrganizationalStructure
    {
        public EmployeeBase Employee;
        public OrganizationalStructure(EmployeeBase firstEmployee)
        {
            Employee = firstEmployee;
        }

        public void Accept(VisitorBase visitor)
        {
            Employee.Accept(visitor);
        }
    }

    abstract class EmployeeBase
    {
        public abstract void Accept(VisitorBase visitor);
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }

    class Manager : EmployeeBase
    {
        public Manager()
        {
            SubOrdinates = new List<EmployeeBase>();
        }
        public List<EmployeeBase> SubOrdinates { get; set; }
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
            foreach (var employee in SubOrdinates)
            {
                employee.Accept(visitor);
            }
        }
    }

    class Worker : EmployeeBase
    {
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }

    abstract class VisitorBase
    {
        public abstract void Visit(Worker worker);
        public abstract void Visit(Manager manager);
    }

    class PayrollVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine($"{worker.Name} paid {worker.Salary}");
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine($"{manager.Name} paid {manager.Salary}");
        }
    }

    class PayriseVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine($"{worker.Name} salary increased to {worker.Salary * (decimal)1.1}");
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine($"{manager.Name} salary increased to {manager.Salary * (decimal)1.2}");
        }
    }
}
