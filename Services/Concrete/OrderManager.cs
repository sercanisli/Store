﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.Concrete
{
    public class OrderManager: IOrderService
    {
        private readonly IRepositoryManager _manager;

        public OrderManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IQueryable<Order> Orders => _manager.Order.Orders;
        public Order? GetOneOrder(int id)
        {
            return _manager.Order.GetOneOrder(id);
        }

        public void Complete(int id)
        {
            _manager.Order.Complete(id);
            _manager.Save();

        }

        public void SaveOrder(Order order)
        {
            _manager.Order.SaveOrder(order);
        }

        public int NumberOfInProcess => _manager.Order.NumberOfInProcess;
    }
}
