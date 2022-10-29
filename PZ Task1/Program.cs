using AutoMapper;
using DAL;
using DAL.Concrete;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_Task1
{
    internal class Program
    {
        static IMapper Mapper = SetupMapper();

        private static IMapper SetupMapper()
        {
            MapperConfiguration config = new MapperConfiguration(
                    cfg => cfg.AddMaps(typeof(OrderDAL).Assembly,typeof(ProductDAL).Assembly,typeof(SupplierDAL).Assembly,typeof(UserDAL).Assembly)
                );
            return config.CreateMapper();
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Wellcome to Trading Company! Please choose an action:");
                Console.WriteLine("Type 'p' to list all products");
                Console.WriteLine("Type 'o' to list all orders");
                Console.WriteLine("Type 's' to list all suppliers");
                Console.WriteLine("Type 'a' to add new order");
                Console.WriteLine("Type 'u' to update order");
                Console.WriteLine("Type 'd' to delete order");
                Console.WriteLine("Type 'q' to exit");
                char c = char.Parse(Console.ReadLine());
                switch (c)
                {
                    case 'p':
                        {
                            ListAllProducts();
                            break;
                        }
                    case 'o':
                        {
                            ListAllOrders();
                            break;
                        }
                    case 's':
                        {
                            ListAllSuppliers();
                            break;
                        }
                    case 'a':
                        {
                            AddNewOrder();
                            break;
                        }
                    case 'u':
                        {
                            ListAllOrders();
                            Console.WriteLine("Enter order's ID");
                            int index = int.Parse(Console.ReadLine());
                            ChangeOrder(index);
                            break;
                        }
                    case 'd':
                        {
                            ListAllOrders();
                            Console.WriteLine("Enter order's ID");
                            int index = int.Parse(Console.ReadLine());
                            DeleteOrder(index);
                            break;
                        }
                    case 'q':
                        {
                            return;
                        }
                }


            }
        }

        private static void DeleteOrder(int index)
        {
            var oldOrder = FindOrder(index);
            if (oldOrder != null)
            {
                var dal = new OrderDAL(Mapper);
                dal.DeleteOrder(oldOrder);
            }
            else
            {
                Console.WriteLine("Order with this ID doesn't exist");
            }

        }

        private static OrderDTO FindOrder(int index)
        {
            var dal = new OrderDAL(Mapper);
            var orders = dal.GetOrders();
            foreach (var order in orders)
            {
                if (order.OrderID == index)
                {
                    return order;

                }
            }
            return null;
        }

        private static void ChangeOrder(int index)
        {
            var order = FindOrder(index);
            if (order != null)
            {
                var dal = new OrderDAL(Mapper);
                int p, s, c;
                ListAllProducts();
                Console.WriteLine("Enter product ID");
                p = int.Parse(Console.ReadLine());
                ListAllSuppliers();
                Console.WriteLine("Enter supplier ID");
                s = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter count of products");
                c = int.Parse(Console.ReadLine());
                var newOrder = new OrderDTO
                {
                    OrderID = order.OrderID,
                    ProductID = p,
                    SupplierID = s,
                    Count = c
                };
                dal.UpdateOrder(newOrder);
            }
            else
            {
                Console.WriteLine("Order with this ID doesn't exist");
            }
        }

        private static void AddNewOrder()
        {
            int p, s, c;
            ListAllProducts();
            Console.WriteLine("Enter product ID");
            p = int.Parse(Console.ReadLine());
            ListAllSuppliers();
            Console.WriteLine("Enter supplier ID");
            s = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter count of products");
            c = int.Parse(Console.ReadLine());
            var dal = new OrderDAL(Mapper);
            var order = new OrderDTO {
                ProductID = p,
                SupplierID = s,
                Count = c
            };
            order = dal.CreateOrder(order);
            Console.WriteLine($"New OrderID: {order.OrderID}");

        }

        private static void ListAllSuppliers()
        {
            var dal = new SupplierDAL(Mapper);
            var suppliers = dal.GetSuppliers();
            Console.WriteLine("-----------------------------------------------------------");
            foreach (var o in suppliers)
            {
                Console.WriteLine($"SupplierID: {o.SupplierID}\t SupplierName: {o.SupplierName}\t");
            }
            Console.WriteLine("-----------------------------------------------------------\n");
        }

        private static void ListAllOrders()
        {
            var dal = new OrderDAL(Mapper);
            var orders = dal.GetOrders();
            Console.WriteLine("-----------------------------------------------------------");
            foreach (var o in orders)
            {
                Console.WriteLine($"OrderID: {o.OrderID}\t ProductID: {o.ProductID}\t SupplierID: {o.SupplierID}\t Count: {o.Count}");
            }
            Console.WriteLine("-----------------------------------------------------------\n");
        }

        private static void ListAllProducts()
        {
            var dal = new ProductDAL(Mapper);
            var products = dal.GetProducts();
            Console.WriteLine("-----------------------------------------------------------");
            foreach (var o in products)
            {
                Console.WriteLine($"ProductID: {o.ProductID}\t ProductName: {o.ProductName}\t ProductCount: {o.ProductCount}");
            }
            Console.WriteLine("-----------------------------------------------------------\n");
        }
    }
}
