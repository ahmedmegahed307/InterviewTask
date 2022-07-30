using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfJQueryDal : EfBaseRepository<Contents> ,IJQueryDal
    {
        private readonly ProjectContext _context;
        public EfJQueryDal(ProjectContext context) : base(context)
        {
            _context = context;
        }
    }
}
