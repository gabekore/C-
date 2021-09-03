using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Message
{
    public class CallbackRegistNty
    {
        public CallbackRegistNty(string pid)
        {
            PId = pid;
        }

        /// <summary>
        /// プッシュId
        /// </summary>
        public string PId { get; set; }
    }
}
