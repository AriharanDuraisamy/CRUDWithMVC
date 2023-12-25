using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDataAccessLayer
{
    public class TicketModelSP
    {
        public int PASSENGERID { get; set; }
        public string TICKETNUMBER { get; set; }
        public string PASSENGERNAME { get; set; }
        public long PHNUMBER { get; set; }
        public string EMAILID { get; set; }
        public DateTime JOURNEYDATE { get; set; }
    }
}
