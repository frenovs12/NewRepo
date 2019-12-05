using HRManager.domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManager.service
{
    public interface ISurveyService : IService<Survey>
    {


        //IEnumerable<Product> getListByPrix();
        //IEnumerable<Product> getListByCategor(String cat);
        //IEnumerable<Product> getProductByQT();
        //int nb_Prodct_Prov(Provider p, int seuil);
        IEnumerable<Survey> getSurveysForUser(int userId);
        void AddSurveyQuestion(int SurveyId, Criterion criterion);
        void DeleteById(int SurveyId);


        //void GrantDayOff(int DayOffId);
        //void DeclineDayOff(int DayOffId);
    }
}

