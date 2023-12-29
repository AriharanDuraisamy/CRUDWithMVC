using System;
using System.Collections.Generic;


namespace DapperDataAccessLayer
{
    public interface ITicketBooking
    {
        public void InsertSP(TicketModel Details);
        public void DeleteSP(long PassengerID);
        public TicketModel ReadbyIDSP(long PassengerID);
        public List<TicketModel> ReadSP();
        public void UpdateSP(int ticupd, TicketModel Details);
    }
}
