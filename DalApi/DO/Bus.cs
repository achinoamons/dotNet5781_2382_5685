using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
   public class Bus
    {
        public int LicenseNum { get; set; }
        public DateTime FromDate { get; set; }
        public double Mileage { get; set; }
        public double FuelTank { get; set; }
        public BusStatus Status { get; set; }
        public override string ToString() => this.ToStringProperty();
    }
}
