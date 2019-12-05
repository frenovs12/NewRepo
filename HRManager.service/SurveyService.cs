using HRManager.data;
using HRManager.Data.Infrastructure;
using HRManager.domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace HRManager.service
{
    
    public class SurveyService : Service<Survey>, ISurveyService
    {
        static IDatabaseFactory factory = new DatabaseFactory();
        static IUnitOfWork iow = new UnitOfWork(factory);
        private IResponseService responseService;
        private IQuestionService questionService;
        public SurveyService() : base(iow)
        {
            responseService = new ResponseService();
            questionService = new QuestionService();
        }
        public override void Add(Survey entity)
        {
            entity.Date = DateTime.Now;
            base.Add(entity);
            base.Commit();
        }

        public void AddSurveyQuestion(int SurveyId, Criterion criterion)
        {
            try
            {
                Survey Survey = base.GetById(SurveyId);

                Survey.Criteria.Add(criterion);
                Survey.Criteria.ToList().RemoveAll(c => c.Description == "" || c.Description == null);
                
                base.Update(Survey);
                base.Commit();
            }
            catch (DbEntityValidationException e)
            {
                var newException = new FormattedDbEntityValidationException(e);
                throw newException;
            }
        }

        public void DeleteById(int SurveyId)
        {
            var responses = responseService.GetAll();
            foreach (Response response in responses)
            {

                responseService.Delete(response);
                responseService.Commit();

            }
            Survey Survey = base.GetById(SurveyId);


            base.Delete(Survey);
            base.Commit();

        }

        IEnumerable<Survey> ISurveyService.getSurveysForUser(int userId)
        {
            return GetAll().Where(survey => survey.UserId == userId);
        }
    }

}

