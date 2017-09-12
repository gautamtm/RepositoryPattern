//using Rhino.Mocks;
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
        #region Field
        private Mock<IProductService> mock;
        private IProductService _productService;
        #endregion

        #region constructor
        public ProductTest()
        {
            mock = new Mock<IProductService>();
            //_productService = MockRepository.GenerateMock<IProductService>();
        }
        #endregion

        [Fact]
        public void GetProductList()
        {
            try
            {
                //var ps = new Mock<IProductService>();
                var model = new[] { new Service.ServiceModel.Product { ProductID = 1, Name = "Static Check Shirt" } };
                mock.Setup(m => m.GetProductList()).Returns(model);
                var name = mock.Object.GetProductList().FirstOrDefault();
               // var serviceModel = _productService.GetProductList();
                Assert.Equal(name.Name, "Check Shirt");

                //using rhino mock
                //var list = _productService.Expect(m => m.GetProductList()).Return(model).Repeat.Once();
                //var pList = _productService.GetProductList();
                //var product = string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
