using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_octo_adventure.Models.ResponseWrapper
{   
    /// <summary>
    /// Wraps the response with a custom message.
    /// </summary>
    /// <typeparam name="T">The actual object</typeparam>
    public class ResponseWrapper<T>
    {
        public string message { get; set; }
        public T body { get; set; }
    }
}
