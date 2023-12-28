using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
namespace DapperDataAccessLayer
{
    public class TicketModel
    {

        public TicketModel()
        {
            JourneyDate = DateTime.Now;
        }
        


        [DisplayName("Passenger ID")]
        public int PassengerID{ get; set; }
        [Required(ErrorMessage = "Must enter Ticket Number")]
        [DisplayName("Ticket Number")]
        [MaxLength(8,ErrorMessage =" Must Be 8 Characters")]
        [StringLength(10,ErrorMessage ="Must Be Below 10 Charcters)")]
        
        public string TicketNumber { get; set; }
        [Required(ErrorMessage = "Must enter your Name")]
        [StringLength(20,ErrorMessage ="Must be below 20 characters ")]
        
        public string PassengerName { get; set; }
        [Required(ErrorMessage = "Must enter your Phone Number")]
        
        public long PhoneNumber { get; set; }
        [EmailAddress(ErrorMessage ="Must be in proper format")]
        public string EmailID { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}") ]
        public DateTime JourneyDate { get; set; }
    }
}
