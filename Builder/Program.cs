using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            // Arka arkaya işlemler sonucunda bir nesne çıkarmak için kullanılır. Businesslayer ve Frontend tasarımında genelde kullanılır.
            ProductDirector productDirector = new ProductDirector();
            var builder = new NewCustomerProductBuilder();
            // var builder = new OldCustomerProductBuilder(); ile de kullanılabilir.
            productDirector.GenerateProduct(builder);
            var model = builder.GetModel();
            Console.WriteLine(model.Id);
            Console.WriteLine(model.ProductName);
            Console.WriteLine(model.DiscountedPrice);
            Console.WriteLine(model.DiscountApplied);
            Console.WriteLine(model.UnitPrice);

        }

    }

    class ProductViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public bool DiscountApplied { get; set; }
    }

    abstract class ProductBuilder
    {
        public abstract void GetProductData();
        public abstract void ApplyDiscount();
        public abstract ProductViewModel GetModel();
    }

    class NewCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel productViewModel = new ProductViewModel();
        public override void ApplyDiscount()
        {
            productViewModel.DiscountedPrice = productViewModel.UnitPrice * (decimal)0.90;
            productViewModel.DiscountApplied = true;
        }

        public override ProductViewModel GetModel()
        {
            return productViewModel;
        }

        public override void GetProductData()
        {
            productViewModel.Id = 1;
            productViewModel.CategoryName = "Beverages";
            productViewModel.ProductName = "Chai";
            productViewModel.UnitPrice = 20;
        }

    }

    class OldCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel productViewModel = new ProductViewModel();
        public override void ApplyDiscount()
        {
            productViewModel.DiscountedPrice = productViewModel.UnitPrice;
            productViewModel.DiscountApplied = false;
        }

        public override ProductViewModel GetModel()
        {
            return productViewModel;
        }

        public override void GetProductData()
        {
            throw new NotImplementedException();
        }
    }

    class ProductDirector
    {
        public void GenerateProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();
        }
    }
}
