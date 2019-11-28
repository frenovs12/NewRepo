


using PIDEV.ServicePattern;
using Service.Pattern;
using Solution.Data.Infrastructure;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Service
{
    public class FilmService : Service<Film>, IFilmService
    {
        static IDataBaseFactory factory = new DataBaseFactory();
        static IUnitOfWork utk = new UnitOfWork(factory);
        public FilmService() : base(utk)
        {
        }
        public IEnumerable<Film> GetFilmByProducers(int producerId)
        {
            return GetMany(f=>f.ProducerId==producerId);
        }
    }
}
