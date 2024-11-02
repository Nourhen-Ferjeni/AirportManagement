using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        //public int Id { get; set; }
        [Key]
        [StringLength(7)]
        public string PassportNumber { get; set; }

        [MinLength(3, ErrorMessage = "Min 3 caractères")]
        [MaxLength(25, ErrorMessage = "Max 25 caractères")]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [RegularExpression("^[0,9]{8}$")]
        public string TelNumber { get; set; }

        [DataType(DataType.EmailAddress)]
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
