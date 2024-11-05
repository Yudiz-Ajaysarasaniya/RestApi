using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.models.Entities.Base
{
    public class BaseIdEntity
    {
        public Guid Id { get; set; }

        public BaseIdEntity() => Id = Guid.NewGuid(); 
    }
}
