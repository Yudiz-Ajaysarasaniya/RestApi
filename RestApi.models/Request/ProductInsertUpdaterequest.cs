using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.models.Request
{
    public class ProductInsertUpdaterequest
    {
        public string? ProductName { get; set;}
        public int Price{ get; set;}
        public string? Description { get; set; }
    }
}
