﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtheepIntergraphTask.Service
{
    public interface IService<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(int id);
        List<T> FindAll();
        T GetById(int id);
    }
}
