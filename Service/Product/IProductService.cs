using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Product
{
    public interface IProductService
    {
        IList<ServiceModel.Product> GetProductList();
    }
}
