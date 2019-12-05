using HRManager.domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManager.service
{
    public interface IDayOffService : IService<DayOff>
    {


        //IEnumerable<Product> getListByPrix();
        //IEnumerable<Product> getListByCategor(String cat);
        //IEnumerable<Product> getProductByQT();
        //int nb_Prodct_Prov(Provider p, int seuil);
        IEnumerable<DayOff> getDaysOffForUser(int userId);
        void GrantDayOff(int DayOffId);
        void DeclineDayOff(int DayOffId);
    }
}

