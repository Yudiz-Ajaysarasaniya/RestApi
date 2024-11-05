using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.models.Entities.Base
{
    public class BaseEntity : BaseIdEntity
    {
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public BaseEntity()
        {
            Active = true;
            Deleted = false;
            Created = DateTime.UtcNow;
            Modified = DateTime.UtcNow;
        }

    }
}
