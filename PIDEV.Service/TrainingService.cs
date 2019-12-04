using PIDEV.Data.Infrastructure;
using PIDEV.Domain;
using PIDEV.ServicePattern;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PIDEV.Domain.training;

namespace PIDEV.Service
{
    public  class TrainingService : Service<training>, ITrainingService
    {
        static IDataBaseFactory factory = new DataBaseFactory();
        static IUnitOfWork utk = new UnitOfWork(factory);
        public TrainingService() : base(utk)
        {

        }

        /*  public IEnumerable<training> GetTrainingByTitle(Sub title)
 {

     return GetMany(f => f.subject.Contains(title));
 }*/
        public IEnumerable<training> GetTrainingBySubject(string sub)
        {

            return GetMany(c => c.subject.Equals(sub));
        }

    }
}
