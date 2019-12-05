using HRManager.Data.Infrastructure;
using HRManager.domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManager.service
{

    public class QuestionService : Service<Criterion>, IQuestionService
    {
        static IDatabaseFactory factory = new DatabaseFactory();
        static IUnitOfWork iow = new UnitOfWork(factory);
        public QuestionService() : base(iow)
        {

        }



    }

}

