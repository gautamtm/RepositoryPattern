<<<<<<< HEAD
﻿//using Rhino.Mocks;
using Moq;
=======
﻿using Moq;
>>>>>>> a227b1e6115d7cd76ed6043e6d4d842b471c9278
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
<<<<<<< HEAD
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
=======
        //private IProductService _productService;
        public ProductTest()
        {
            
        }

        [Theory]
>>>>>>> a227b1e6115d7cd76ed6043e6d4d842b471c9278
        public void GetProductList()
        {
            try
            {
<<<<<<< HEAD
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
=======
                var ps = new Mock<IProductService>();
                var serviceModel = new[] { new Service.ServiceModel.Product { ProductID = 1 } };
                ps.Setup(m => m.GetProductList()).Returns(serviceModel);
            
            }
            catch (Exception)
            {
                
>>>>>>> a227b1e6115d7cd76ed6043e6d4d842b471c9278
                throw;
            }
        }
    }
}
