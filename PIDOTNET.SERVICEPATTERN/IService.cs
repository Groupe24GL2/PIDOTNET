﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;


namespace PIDOTNET.SERVICEPATTERN
{
    public interface IService<T> where T : class
    {
        //crud
        void Add(T Entity);
        T GetById(int id);
        T GetById(string id);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> Condition = null,
            Expression<Func<T, bool>> orderBy = null);//list conditionné
        void Update(T Entity);
        void Delete(T Entity);
        void Delete(Expression<Func<T, bool>> Condition);
        IEnumerable<T> GetAll();
        void Commit();
        void dispose();
    }
}
