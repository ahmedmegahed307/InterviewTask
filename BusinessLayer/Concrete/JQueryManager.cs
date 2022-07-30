using AutoMapper;
using BusinessLayer.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class JQueryManager : IJQueryService
    {
        
        private readonly IJQueryDal _jQueryDal;

        public IQueryable<Contents> GetAllContents()
        {
            return _jQueryDal.GetAll();
        }

        
    }
}
