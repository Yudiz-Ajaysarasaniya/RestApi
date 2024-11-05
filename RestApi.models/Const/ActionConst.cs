using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.models.Const
{
    public class ActionConst
    {
        public const string Get = "Products/get";
        public const string GetById = "Products/get_by_id";
        public const string Add = "Products/add";
        public const string Update = "Products/update";
        public const string Delete = "Products/delete";
    }

    public class CustomersConst
    {
        public const string AddUpdate = "Customer/add_update";
        public const string Delete = "Customer/delete";
        public const string Get = "Customer/getall";
        public const string GetById = "Customer/get_by_id";
    }
}
