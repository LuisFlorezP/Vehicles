using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists.Logic
{
    public class Responce
    {
        public bool IsSucced { get; set; }

        public string Message { get; set; }

        public Responce()
        {
            IsSucced = false;
            Message = "Failed process\n";
        }

        public override string ToString()
        {
            if (IsSucced)
            {
                Message = "Succed process\n";
                return Message;
            }
            return Message;
        }
    }
}
