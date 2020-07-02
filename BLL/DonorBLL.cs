using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankSystem.BLL
{
    class DonorBLL
    {
        public int donorId { get; set; }
        public string DFullName { get; set; }
        public string dEmail { get; set; }
        public string DAddress { get; set; }
        public string DConatct { get; set; }
        public string DPassword { get; set; }
        public string DCfrmPassword { get; set; }
        public string DGender { get; set; }
        public DateTime AddDate { get; set; }
        public string DImageSource { get; set; }
        public string DBloodG { get; set; }
        public string DEllig { get; set; }

        public int UserId { get; set; }
    }
}
