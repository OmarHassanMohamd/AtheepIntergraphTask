using AtheepIntergraphTask.Models;
using AtheepIntergraphTask.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtheepIntergraphTask.Service
{
    public class CustomerService : IService<CustomerModel>
    {
        CustomerRepository _customerRepository;
        CompanyRepository _companyRepository;
        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
            _companyRepository = new CompanyRepository();
        }
        public void Add(CustomerModel entity)
        {
            var customer = new Customer()
            {
                BirthDate = entity.BirthDate,
                //Company = _companyRepository.GetById(entity.CompanyId),
                CompanyId = entity.CompanyId,
                Email = entity.Email,
                Job = entity.Job,
                MobileNo = entity.MobileNo,
                Name = entity.Name
            };
            _customerRepository.Add(customer);
        }

        public List<CustomerModel> FindAll()
        {
            var customers = _customerRepository.FindAll();

            List<CustomerModel> customersModel = customers.ConvertAll(x => new CustomerModel
            {
                  BirthDate = x.BirthDate,
                  CompanyId = x.CompanyId,
                  Email = x.Email,
                  Job = x.Job,
                  MobileNo = x.MobileNo,
                  Name = x.Name,
                  ID = x.ID
                });
            return customersModel;
        }

        public CustomerModel GetById(int id)
        {
            var customer = _customerRepository.GetById(id);
            return new CustomerModel()
            {
                BirthDate = customer.BirthDate,
                CompanyId = customer.CompanyId,
                Email = customer.Email,
                ID = customer.ID,
                Job = customer.Job,
                MobileNo = customer.MobileNo,
                Name = customer.Name
            };
        }

        public void Remove(int id)
        {
            _customerRepository.Remove(id);
        }

        public void Update(CustomerModel entity)
        {
            var customer = new Customer()
            {
                BirthDate = entity.BirthDate,
                Name = entity.Name,
                MobileNo = entity.MobileNo,
                CompanyId = entity.CompanyId,
                Email = entity.Email,
                ID = entity.ID,
                Job = entity.Job
            };
            _customerRepository.Update(customer);
        }
    }
}