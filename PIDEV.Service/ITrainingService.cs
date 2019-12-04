using PIDEV.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIDEV.Service
{
    public interface ITrainingService
    {
        IEnumerable<training> GetTrainingByTitle(string title);
    }
}
