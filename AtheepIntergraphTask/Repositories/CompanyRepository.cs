using AtheepIntergraphTask.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace AtheepIntergraphTask.Repositories
{
    public class CompanyRepository : IRepository<Company>,IDisposable
    {
        AtheepIntergraphTaskEntities _entities;
        public CompanyRepository()
        {
            _entities = new AtheepIntergraphTaskEntities();
        }
        public void Add(Company entity)
        {
            _entities.Companies.Add(entity);
            _entities.SaveChanges();
        }

        public void Dispose()
        {
            _entities.Dispose();
        }

        public List<Company> FindAll()
        {
            return _entities.Companies.ToList();
        }

        public Company GetById(int id)
        {
            return _entities.Companies.Where(c => c.ID == id).FirstOrDefault();
        }

        public void Remove(int id)
        {
            var company = GetById(id);
            _entities.Companies.Remove(company);
            _entities.SaveChanges();
        }

        public void Update(Company entity)
        {
            _entities.Configuration.ValidateOnSaveEnabled = false;

            var originalValues = GetById(entity.ID);
            originalValues.Code = entity.Code;
            originalValues.Logo = entity.Logo;
            originalValues.Name = entity.Name;
            originalValues.PhoneNo = entity.PhoneNo;
            _entities.SaveChanges();
        }
    }
}