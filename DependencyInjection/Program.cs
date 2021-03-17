using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    // Katmanlar arası geçiş yapılırken bu desen çok kullanılır. Arayüzün business ile iletişimini kurarken de geçerlidir. Cross cutting concerns (Loglama, Cacheleme, Validation) lerin de DI ile kullanımı söz konusudur. iOC containerlar ile de newleme işlemlerini container içerisinden new lemeden inject edilebilir.
    // ninject ile bir kurulum yapılıp container üzerinden new lemeleri yönetelim. Install-package Ninject ile kurulumu gerçekleştir.
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IProductDal>().To<EfProductDal>().InSingletonScope();
            //kernel.Bind<IProductDal>().To<NhProductDal>().InSingletonScope();

            ProductManager productManager = new ProductManager(kernel.Get<IProductDal>());
            //ProductManager productManager = new ProductManager(new NhProductDal());
            productManager.Save();
        }
    }

    interface IProductDal
    {
        void Save();
    }

    class EfProductDal: IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved with EF");
        }
    }

    class NhProductDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved with Nh");
        }
    }

    class ProductManager
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public void Save()
        {
            // Business Code
            _productDal.Save();
        }
    }
}
