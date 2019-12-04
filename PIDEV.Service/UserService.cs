using PIDEV.Data.Infrastructure;
using PIDEV.Domain;
using PIDEV.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIDEV.Service
{
    public class UserService: Service<user>, IUserService
    {
        static IDataBaseFactory factory = new DataBaseFactory();
        static IUnitOfWork utk = new UnitOfWork(factory);
        public UserService() : base(utk)
        {

        }
    }
}
