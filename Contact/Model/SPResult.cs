using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.Model
{
    public class SPResult
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
    public class SPResult<T> where T : class
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public IEnumerable<T> List { get; set; }
    }
}
