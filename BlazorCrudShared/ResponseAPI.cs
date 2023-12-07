using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrudShared
{
    public class ResponseAPI<T>
    {
        public bool Success { get; set; }
        public T? value { get; set; }

        public string? message { get; set; }
    }
}
