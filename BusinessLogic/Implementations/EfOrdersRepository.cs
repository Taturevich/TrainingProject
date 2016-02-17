using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using Domain;
using Domain.Entities;

namespace BusinessLogic.Implementations
{
    public class EfOrdersRepository : IOrdersRepository 
    {
        private EfDataBaseContext context;

        public EfOrdersRepository(EfDataBaseContext context)
        {
            this.context = context;
        }
        public IEnumerable<Order> GetOrders()
        {
            return context.Orders;
        }

        public Order GetOrderById(int id)
        {
            return context.Orders.FirstOrDefault(x => x.Id == id);
        }

        public Order GetOrderByLoginId(int id)
        {
            return context.Orders.FirstOrDefault(x => x.LoginId == id);
        }

        public Order GetOrderByCategoryId(int id)
        {
            return context.Orders.FirstOrDefault(x => x.CategoryId == id);
        }

        public void AddOrder(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }

        public void SaveOrder(Order order)
        {
            if (order.Id == 0)
                context.Orders.Add(order);
            else
                context.Entry(order).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteOrder(Order order)
        {
            context.Entry(order).State = EntityState.Deleted;
            //context.Entry(order).State = EntityState.Modified;
            //context.Orders.Remove(order);
            context.SaveChanges();
        }
    }
}
