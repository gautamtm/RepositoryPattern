using Service.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestDemo.ViewModels;

namespace TestDemo.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: Product
        public ActionResult Index()
        {
            var model = GetProductList();
            return View(model);
        }

        public IList<ProductViewModel> GetProductList()
        {
            try
            {
<<<<<<< HEAD
                var check = Core.Helper.HtmlHelper.ConvertPlainTextToHtml("hello");
                var link = Core.Helper.ResolveLinksHelper.FormatText("https://github.com/aspnetboilerplate/aspnetboilerplate/tree/dev/src");
=======
>>>>>>> a227b1e6115d7cd76ed6043e6d4d842b471c9278
                var list = new List<ProductViewModel>();
                Random price = new Random();
                var products = new[] { "Shoes", "Shirt", "Half-Pants", "Sun Glass", "Headphone", "Laptop", "Desktop", "Mobile", "Slipper" };
                var dbList = _productService.GetProductList().FirstOrDefault();
                list.Add(new ProductViewModel()
                {
                    ProductID = dbList.ProductID,
                    Name = dbList.Name,
                    CostPrice = dbList.CostPrice ?? 0,
                    SalesPrice = dbList.SalesPrice ?? 0
                });
                var productName = string.Empty;
                for (int i = 5; i < 15; i++)
                {
                    var cp = price.Next(i, 3000);
                    var sp = cp + (15 * cp) / 100;
                    productName = products.OrderBy(m => Guid.NewGuid()).FirstOrDefault();
                    if (list.Any(m => m.Name == productName))
                        productName = GetRandomWord(i);
                    list.Add(new ProductViewModel
                    {
                        ProductID = i,
                        Name = productName,
                        CostPrice = cp,
                        SalesPrice = sp
                    });
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string GetRandomWord(int wordLength) 
        {
            Random random = new Random();
            string[] consonant = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "y", "z" };
            string[] vowels = { "a", "e", "i", "o", "u" };
            string word = string.Empty;

            for (int i = 0; i <= wordLength; i++) 
            {
                word += GetRandomLetter(random, consonant) + GetRandomLetter(random, vowels);
            }
            word = word.Replace("q", "qu").Substring(0, wordLength);
            return word;
        }

        private string GetRandomLetter(Random rn, string[] letters)
        {
            return letters[rn.Next(0, letters.Length - 1)];
        }

    }
}