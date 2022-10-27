using DTO;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IOrderDAL
    {
        List<OrderDTO> GetOrders();
        OrderDTO CreateOrder();
        OrderDTO UpdateOrder();
    }
}
