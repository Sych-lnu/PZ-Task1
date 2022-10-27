using AutoMapper;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DAL.Concrete
{
    public class OrderDAL : IOrderDAL
    {
        private readonly IMapper _mapper;

        public OrderDAL(IMapper mapper)
        {
            _mapper = mapper;
        }
        public OrderDTO CreateOrder()
        {
            throw new NotImplementedException();
        }
        public OrderDTO UpdateOrder(OrderDTO order)
        {
            using (var entities = new TestDB2022Entities2())
            {
                var orderInDB = _mapper.Map<order>(order);
                orderInDB.OrderID = order.OrderID;
                entities.orders.Remove(orderInDB);
                entities.orders.AddOrUpdate(orderInDB);
                entities.SaveChanges();
                return _mapper.Map<OrderDTO>(orderInDB);
            }

        }
        public OrderDTO UpdateOrder()
        {
            using (var entities = new TestDB2022Entities2())
            {
                throw new NotImplementedException();
            }

        }


        public OrderDTO CreateOrder(OrderDTO order)
        {
            using(var entities = new TestDB2022Entities2())
            {
                var orderInDB = _mapper.Map<order>(order);
                entities.orders.Add(orderInDB);
                entities.SaveChanges();
                return _mapper.Map<OrderDTO>(orderInDB);
            }
        }

        public List<OrderDTO> GetOrders()
        {
            using (var entities = new TestDB2022Entities2())
            {
                var orders = entities.orders.ToList();
                return _mapper.Map<List<OrderDTO>>(orders);
            }
        }
    }
}
