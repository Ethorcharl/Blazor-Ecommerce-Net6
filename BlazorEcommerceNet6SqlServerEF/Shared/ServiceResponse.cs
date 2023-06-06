using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerceNet6SqlServerEF.Shared
{
    public class ServiceResponse<T> //generit type
    {
        public T? Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set;} = string.Empty;
    }
}
