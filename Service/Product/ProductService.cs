using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.ServiceModel;
using Service.Configuration;

namespace Service.Product
{
    public class ProductService : IProductService
    {
        private IRepository<Data.Entities.Product> _productRepo;

        public ProductService(IRepository<Data.Entities.Product> product)
        {
            _productRepo = product;
        }

        public IList<ServiceModel.Product> GetProductList()
        {
            try
            {
                var data = _productRepo.Table.Where(m => m.Status == true).ToList();
                return AutomapperConfig.Mapper.Map<IList<ServiceModel.Product>>(data);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
