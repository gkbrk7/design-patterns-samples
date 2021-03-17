using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        // Bir nesne örneğinden sadece bir kez üretilip bu nesnenin uygulama yaşam döngüsü boyunca kullanılmasını amaçlayan bir desendir.
        static void Main(string[] args)
        {
            var customerManager = CustomerManager.CreateAsSingleton();
            customerManager.Save();

        }
    }

    class CustomerManager
    {
        private static CustomerManager _customerManager;
        static object _lockObject = new object();
        private CustomerManager()
        {

        }

        public static CustomerManager CreateAsSingleton()
        {
            // thread-safe işlem gerçekleştirmek için mesela bir program bu class a yazıyor biri de aynı anda okumaya çalışıyorsa, aynı anda instance üretilmeye çalışılırsa sıkıntı çıkar bunu önlemek için her bir threadin işlemi beklemesini sağlamalıyız.
            // _customerManager in null olup olmadığını kontrol eder eğer null değilse _customerManager i döndürür eğer null ise new instance oluşturur.
            // lock işlemi içerisine alınan kod parçasını sadece bir threade verir belli bir zaman da yapmak için kısaca bir thread in işlemini yapıp bitirmesi için ilgili kod bloğunu kitler.
            //Locks only allow one thread into the locked section at a time. When other threads hit the lock, they’ll block until the lock is released. This incurs overhead, but it guarantees thread-safety. There’s always a price to pay for thread-safety
            // https://makolyte.com/csharp-thread-safe-primitive-properties-using-lock-vs-interlocked/

            lock (_lockObject)
            {
                if (_customerManager == null)
                {
                    _customerManager = new CustomerManager();
                }
            }
            return _customerManager;
        }

        public void Save()
        {
            Console.WriteLine("Saved");
        }
    }
}
