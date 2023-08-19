using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportApp
{
    public class Omnibus : Transport
    {
        public Omnibus(int transportID, int passengersAmount, int TransportType) : base(transportID, passengersAmount, TransportType)
        {
        }
        public override string Description()
        {
            return $"OMNIBUS {TransportID}";
        }
        public override string CapacityStatus()
        {

            return $"{PassengersAmount} PASAJEROS";
        }

        public override string Stop()
        {
            return $"DETENIDO";
        }

        public override string Move()
        {
            return $"AVANZANDO";
        }
    }
}
