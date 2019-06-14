using AtheepIntergraphTask.Models;
using AtheepIntergraphTask.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtheepIntergraphTask.Service
{
    public class CompanyService : IService<CompanyModel>
    {
        CompanyRepository _companyRepository;
        public CompanyService()
        {
            _companyRepository = new CompanyRepository();
        }
        public void Add(CompanyModel entity)
        {
            var company = new Company()
            {
                Code = entity.Code,
                Logo = entity.Logo,
                Name = entity.Name,
                PhoneNo = entity.PhoneNo
            };
            _companyRepository.Add(company);
        }

        public List<CompanyModel> FindAll()
        {
            var companies = _companyRepository.FindAll();

            List<CompanyModel> companiesModel = companies.ConvertAll(x => new CompanyModel()
            {
                Code = x.Code,
                Logo = x.Logo,
                PhoneNo = x.PhoneNo,
                Name = x.Name,
                ID = x.ID
            });
            return companiesModel;
        }

        public CompanyModel GetById(int id)
        {
            var company = _companyRepository.GetById(id);
            return new CompanyModel()
            {
                Code = company.Code,
                ID = company.ID,
                Logo = company.Logo,
                Name = company.Name,
                PhoneNo = company.PhoneNo
            };
        }

        public void Remove(int id)
        {
            _companyRepository.Remove(id);
        }

        public void Update(CompanyModel entity)
        {
            var company = new Company()
            {
                Code = entity.Code,
                Logo = entity.Logo,
                PhoneNo = entity.PhoneNo,
                Name = entity.Name,
                ID = entity.ID
            };
            _companyRepository.Update(company);
        }
    }
}