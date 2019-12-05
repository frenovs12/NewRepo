using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManager.domain.Entities
{
    public class Response
    {
        public int ResponseId { get; set; }
        public Survey Survey { get; set; }
        public int UserId { get; set; }

    }
}
