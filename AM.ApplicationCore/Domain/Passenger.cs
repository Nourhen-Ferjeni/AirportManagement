using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public int Id { get; set; }
        public string PassportNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string TelNumber { get; set; }
        public string EmailAddress { get; set; }
        
        // Relation * avec Flights
        public ICollection<Flight> Flights { get; set; }
        public override string ToString()
        {
            return "FirstName: " + FirstName
                + " LastName: " + LastName
                + " BirthDate: " + BirthDate;
        }
       
        public bool CheckProfile(string FirstName, string LastName, string email = null)
        {
            if (email != null)
                return this.FirstName == FirstName && this.LastName == LastName
                    && EmailAddress == email;
            else
                return this.FirstName == FirstName && this.LastName == LastName;

        }
        public virtual void PassengerType()
        {
            Console.WriteLine("I am the passenger: " + FirstName);
        }


    }
}
