using AutoMapper;
using DTO;

namespace DAL.Profiles
{
    public class Supplier: Profile
    {
        public Supplier()
        {
            CreateMap<supplier, SupplierDTO>().ReverseMap();
        }
    }
}
