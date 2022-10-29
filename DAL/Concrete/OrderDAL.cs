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
        public OrderDTO UpdateOrder(OrderDTO newOrder)
        {
            using (var entities = new TestDB2022Entities2())
            {
                var orderInDB = _mapper.Map<order>(newOrder);
                var orders = entities.orders.ToList();
                for (int i = 0; i < orders.Count; i++)
                {
                    if(orders[i].OrderID== newOrder.OrderID)
                    {
                        orders[i]=_mapper.Map<order>(newOrder);
                        entities.orders.AddOrUpdate(orders[i]);
                        break;
                    }
                }
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
        public OrderDTO DeleteOrder()
        {
            using (var entities = new TestDB2022Entities2())
            {
                throw new NotImplementedException();
            }
        }
        public OrderDTO DeleteOrder(OrderDTO oldOrder)
        {
            using (var entities = new TestDB2022Entities2())
            { 
                var deletedOrder = new OrderDTO();
                foreach(order order  in entities.orders)
                {
                    if (order.OrderID == oldOrder.OrderID)
                    {
                        entities.orders.Remove(order);
                        deletedOrder = _mapper.Map<OrderDTO>(order);
                        break;
                    }
                }
                entities.SaveChanges();
                return deletedOrder;
            }
        }
    }
}
