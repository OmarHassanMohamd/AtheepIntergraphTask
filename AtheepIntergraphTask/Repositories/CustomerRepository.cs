using AtheepIntergraphTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtheepIntergraphTask.Repositories
{
    public class CustomerRepository : IRepository<Customer>,IDisposable
    {
        AtheepIntergraphTaskEntities _entities;
        public CustomerRepository()
        {
            _entities = new AtheepIntergraphTaskEntities();
        }
        public void Add(Customer entity)
        {
            _entities.Customers.Add(entity);
            _entities.SaveChanges();
        }

        public void Dispose()
        {
            _entities.Dispose();
        }

        public List<Customer> FindAll()
        {
            return _entities.Customers.ToList();
        }

        public Customer GetById(int id)
        {
            return _entities.Customers.Where(c => c.ID == id).FirstOrDefault();
        }

        public void Remove(int id)
        {
            var customer = GetById(id);
            _entities.Customers.Remove(customer);
            _entities.SaveChanges();
        }

        public void Update(Customer entity)
        {
            var originalValues = GetById(entity.ID);
            _entities.Entry(originalValues).CurrentValues.SetValues(entity);
            _entities.SaveChanges();
        }
    }
}