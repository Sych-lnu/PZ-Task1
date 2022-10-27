using AutoMapper;
using DAL.Interfaces;
using DTO;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Concrete
{
    public class SupplierDAL: ISupplierDAL
    {
        private readonly IMapper _mapper;
        public SupplierDAL(IMapper mapper)
        {
            _mapper = mapper;
        }
        public List<SupplierDTO> GetSuppliers()
        {
            using (var entities = new TestDB2022Entities2())
            {
                var suppliers = entities.suppliers.ToList();
                return _mapper.Map<List<SupplierDTO>>(suppliers);
            }

        }

    }
}
