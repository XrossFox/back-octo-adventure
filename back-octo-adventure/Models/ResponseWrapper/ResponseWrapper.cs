using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_octo_adventure.Models.ResponseWrapper
{
    public class ResponseWrapper<T>
    {
        public string message { get; set; }
        public T body { get; set; }
    }
}
