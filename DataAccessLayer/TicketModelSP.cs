using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace DapperDataAccessLayer
{
    public class TicketModelSP
    {
        [DisplayName("Passenger ID")]
        public int PASSENGERID { get; set; }
        [Required(ErrorMessage = "Must enter Ticket Number")]
        [DisplayName("Ticket Number")]
        
        public string TICKETNUMBER { get; set; }
        [Required(ErrorMessage = "Must enter your Name")]
        [StringLength(20,ErrorMessage ="Must be below 20 characters ")]
        
        public string PASSENGERNAME { get; set; }
        [Required(ErrorMessage = "Must enter your Phone Number")]
        [Phone]
        public long PHNUMBER { get; set; }
        [EmailAddress(ErrorMessage ="Must be in proper format")]
        public string EMAILID { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}") ]
        public DateTime JOURNEYDATE { get; set; }
    }
}
