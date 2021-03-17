using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    // Factory Method yazılımda değişimi kontrol altında tutmaktır. ORM, Cache ve loglama sistemlerine göre değişiklik gösterecek yapıları barındırır.
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new LoggerFactory2());
            customerManager.Save();
        }
    }

    public class LoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            // Business to decide factory
            // Hangi ILogger dan türüyen nesneyi üreteceğimize karar veririz.
            return new GyLogger();
        }
    }

    public class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            // Business to decide factory
            // Hangi ILogger dan türüyen nesneyi üreteceğimize karar veririz.
            return new Log4NetLogger();
        }
    }

    public interface ILogger
    {
        void Log();
    }

    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    public class GyLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with GyLogger");
        }
    }

    public class Log4NetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with Log4NetLogger");
        }
    }

    public class CustomerManager
    {
        private ILoggerFactory _loggerFactory;
        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }
        public void Save()
        {
            Console.WriteLine("Saved");
            //ILogger logger = new LoggerFactory().CreateLogger();
            ILogger logger = _loggerFactory.CreateLogger();
            logger.Log();
        }
    }
}
