using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportApp
{
    public abstract class Transport
    {
        public int PassengersAmount { get; set; }
        public int TransportID { get; set; }
        public int TransportType { get; set; }    
        protected Transport(int transportID, int passengersAmount, int transportType)
        {
            TransportID = transportID;
            PassengersAmount = passengersAmount;
            TransportType = transportType;            
        } 

        public abstract string Description();
        public abstract string CapacityStatus();
        public abstract string Move();
        public abstract string Stop();
    }
}
