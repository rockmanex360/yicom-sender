using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sender
{
    public class Request
    {
        public string Message { get; set; }
        public string TimeStamp { get; set; }
        public int Priority { get; set; }
    }
}