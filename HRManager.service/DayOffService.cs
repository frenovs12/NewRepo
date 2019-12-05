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

    public class DayOffService : Service<DayOff>, IDayOffService
    {
        static IDatabaseFactory factory = new DatabaseFactory();
        static IUnitOfWork iow = new UnitOfWork(factory);
        public DayOffService() : base(iow)
        {

        }
        public override void Add(DayOff entity)
        {
            entity.State = State.Pending;
            entity.EndDate = entity.StartDate.AddDays(entity.Duration);
            base.Add(entity);
        }


        public void GrantDayOff(int DayOffId)
        {
            DayOff DayOff = base.GetById(DayOffId);
            DayOff.State = State.Accepted;
            base.Update(DayOff);
        }
        public void DeclineDayOff(int DayOffId)
        {
            DayOff DayOff = base.GetById(DayOffId);
            DayOff.State = State.Declined;
            base.Update(DayOff);
        }

        IEnumerable<DayOff> IDayOffService.getDaysOffForUser(int userId)
        {
            return GetAll().Where(dayoff => dayoff.UserId == userId);
        }
        //public IEnumerable<Product> getListByCategor(String cat)
        //{
        //    return GetAll().Where(x => x.Category.Name.Equals(cat));
        //}

        //public IEnumerable<Product> getListByPrix()
        //{
        //    //List<Product> getList;
        //    //getList = iow.getRepository<Product>().GetAll().OrderByDescending(x => x.Price).ToList();
        //    return GetAll().OrderByDescending(x => x.Price);
        //}

        //public IEnumerable<Product> getProductByQT()
        //{
        //    return GetAll().OrderByDescending(x => x.Quantity).Take(2);
        //}

        //public int nb_Prodct_Prov(Provider p, int seuil)
        //{
        //    return p.Products.Where(x => x.Quantity >= seuil).Count();
        //    //  GetAll().Where(x => x.Providers.Equals(p) && x.Quantity > seuil).Count();
        //}
    }
}

