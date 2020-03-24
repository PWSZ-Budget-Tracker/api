using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget_Tracker.VievModel
{
    public class ClientVM
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public bool IsAdmin { get; set; }
    }
}
