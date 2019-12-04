using PIDEV.Domain;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PIDEV.Domain.training;

namespace PIDEV.Service
{
    public interface ITrainingService : IService<training>
    {
        // IEnumerable<training> GetTrainingByTitle(string title);
        IEnumerable<training> GetTrainingBySubject(string sub);
    }
}
