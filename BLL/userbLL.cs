using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankSystem.userBLL
{
    class UserbLL
    {

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserAddress { get; set; }
        public string UserConatct { get; set; }
        public string UserPassword { get; set; }
        public string UserCfrmPassword { get; set; }
        public string Gender { get; set; }
        public DateTime AddDate { get; set; }
        public string ImageSource { get; set; }
    }
}
