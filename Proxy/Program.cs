using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proxy
{
    // Cacheleme sistemine benzer, sınıfın çağırdığı bir işlem olsun bir defadan fazla çağırılan operasyonlar için o kaynağı tekrar tekrar üretmek yerine tek bir kaynak üzerinden operasyon işlemi gerçekleşir.
    class Program
    {
        static void Main(string[] args)
        {
            //CreditManager manager = new CreditManager();
            //Console.WriteLine(manager.Calculate());
            CreditBase proxy = new CreaditManagerProxy();
            Console.WriteLine(proxy.Calculate());
            Console.WriteLine(proxy.Calculate());
        }
    }

    abstract class CreditBase
    {
        public abstract int Calculate();
    }

    class CreditManager : CreditBase
    {
        public override int Calculate()
        {
            int result = 1;
            for (int i = 1; i < 5; i++)
            {
                result *= i;
                Thread.Sleep(1000);
            }
            return result;
        }
    }

    class CreaditManagerProxy : CreditBase
    {
        private CreditManager _creditManager;
        private int _cachedData;

        public override int Calculate()
        {
            if (_creditManager == null)
            {
                _creditManager = new CreditManager();
                _cachedData = _creditManager.Calculate();
            }

            return _cachedData;
        }
    }
}
