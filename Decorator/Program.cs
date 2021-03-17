using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    // Elimizdeki halihazırda bulunan nesneye ekstra özellikler ekleyerek daha farklı amaçlar içinde kullanmaktır.
    class Program
    {
        static void Main(string[] args)
        {
            var personalCar = new PersonalCar { Brand = "BMW", HirePrice = 2500, Model = "3.20d" };
            SpecialOffer specialOffer = new SpecialOffer(personalCar);
            Console.WriteLine("Concrete: " + personalCar.HirePrice);
            specialOffer.DiscountPercentage = 10;
            Console.WriteLine("Special Offer: " + specialOffer.HirePrice);
        }
    }

    abstract class CarBase
    {
        public abstract string Brand { get; set; }
        public abstract string Model { get; set; }
        public abstract decimal HirePrice { get; set; }
    }

    class PersonalCar : CarBase
    {
        public override string Brand { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    class CommercialCar : CarBase
    {
        public override string Brand { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    abstract class CarDecoratorBase : CarBase
    {
        private CarBase _CarBase;
        protected CarDecoratorBase(CarBase carBase)
        {
            _CarBase = carBase;
        }
    }

    class SpecialOffer : CarDecoratorBase
    {
        // Constructora gelen parametre ilk önce bu class ın içerisinde işlemlere tabi tutulduktan sonra base ' e yani CarBase class ına gönderilir.
        public int DiscountPercentage { get; set; }
        private readonly CarBase _carBase;
        public SpecialOffer(CarBase carBase): base(carBase)
        {
            _carBase = carBase;
        }

        public override string Brand { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get => _carBase.HirePrice - (_carBase.HirePrice * DiscountPercentage/100); set { } }
    }
}
