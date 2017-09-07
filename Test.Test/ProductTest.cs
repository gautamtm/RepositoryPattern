using Moq;
using Service.Chat;
using Service.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDemo.Controllers;
using Xunit;

namespace Test.Test
{
    public class ProductTest
    {
        //private IProductService _productService;
        public ProductTest()
        {
            
        }

        [Theory]
        public void GetProductList()
        {
            try
            {
                var ps = new Mock<IProductService>();
                var serviceModel = new[] { new Service.ServiceModel.Product { ProductID = 1 } };
                ps.Setup(m => m.GetProductList()).Returns(serviceModel);
            
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
