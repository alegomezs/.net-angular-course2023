using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportApp
{
    public class Omnibus : Transport
    {
        public Omnibus(int transportID, int passengersAmount) : base(transportID, passengersAmount)
        {
        }

        public override string ShowPassengersAmount()
        {
            return $"Omnibus {TransportID}: {PassengersAmount} pasajeros";
        }
    }
}
