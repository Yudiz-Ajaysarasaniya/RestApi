using RestApi.models.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.models.Entities
{
    public class Product : BaseEntity
    {
        public string? ProductName { get; set; }
        public int Price { get; set; }
        public string? Description { get; set; }
    }
}
