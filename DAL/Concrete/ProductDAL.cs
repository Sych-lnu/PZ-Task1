using AutoMapper;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Concrete
{
    public class ProductDAL : IProductDAL
    {
        private readonly IMapper _mapper;
        public ProductDAL(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ProductDTO ChangeProduct()
        {
            throw new NotImplementedException();
        }

        public ProductDTO CreateProduct()
        {
            throw new NotImplementedException();
        }

        public List<ProductDTO> GetProducts()
        {
            using (var entities = new TestDB2022Entities2())            {
                var products = entities.products.ToList();
                return _mapper.Map<List<ProductDTO>>(products);
            }
        }
    }
}
