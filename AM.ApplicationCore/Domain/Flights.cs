using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public int FlightId { get; set; }
        public DateTime FlightDate { get; set; }
        public int EstimatedDuration { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }

        //Relation 1 avec Plane
        public Plane Plane { get; set; }
        [ForeignKey("Plane")]
        public int PlaneFk { get; set; }
        // Relation * avec Passengers
        public ICollection<Passenger> Passengers { get; set; }
        public override string ToString()
        {
            return "Destination: " + Destination
                + " FlightDate: " + FlightDate
                + " EstimatedDuration: " + EstimatedDuration;
        }
    }
}
