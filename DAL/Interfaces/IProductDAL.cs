using DTO;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IProductDAL
    {
        List<ProductDTO> GetProducts();
        ProductDTO CreateProduct();
        ProductDTO ChangeProduct();
    }
}
