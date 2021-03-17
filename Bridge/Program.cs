using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    // Bir nesnenin içerisinde soyutlanabilir yani switch edilebilir bir class, property ya da method varsa onları soyutlama teknikleriyle değiştirip kullanılabilir hale getirir
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            //customerManager.MessageSenderBase = new EmailSender();
            customerManager.MessageSenderBase = new SmsSender();
            customerManager.UpdateCustomer();
        }
    }

    abstract class MessageSenderBase
    {
        public void Save()
        {
            Console.WriteLine("Message Saved");
        }

        public abstract void Send(Body body);

    }

    class Body
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }

    class SmsSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine($"{body.Title}, was sent via SmsSender");
        }
    }

    class EmailSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine($"{body.Title}, was sent via EmailSender");
        }
    }

    //-----------------
    class CustomerManager
    {
        public MessageSenderBase MessageSenderBase { get; set; }

        public void UpdateCustomer()
        {
            MessageSenderBase.Send(new Body { Title = "About the Course" });
            Console.WriteLine("Customer Updated");
        }
    }

    class NewCustomerManager : CustomerManager
    {

    }
}
