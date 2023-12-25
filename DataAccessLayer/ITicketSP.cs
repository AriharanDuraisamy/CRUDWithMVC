using System;
using System.Collections.Generic;


namespace DapperDataAccessLayer
{
    public interface ITicketSP
    {
        public void InsertSP(TicketModelSP Details);
        public void DeleteSP(long PASSENGERID);
        public TicketModelSP ReadbyIDSP(long PASSENEGERID);
        public List<TicketModelSP> ReadSP();
        public void UpdateSP(int ticupd, TicketModelSP Details);
    }
}
