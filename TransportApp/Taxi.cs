using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TransportApp
{
    public class Taxi : Transport
    {
        public Taxi(int transportID, int passengersAmount, int transportType) : base(transportID, passengersAmount, transportType)
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
