using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportApp
{
    public class Taxi : Transport
    {
        public Taxi(int transportID, int passengersAmount) : base(transportID, passengersAmount)
        {
        }
        public override string Description()
        {
            return $"TAXI {TransportID}";
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
