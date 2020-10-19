using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollectorProject.Models
{
    public class Customer
    {
        [Key]
        public int id { get; set; }
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        [ForeignKey("ZipCode")]
        [Display(Name ="Zip Code")]
        public int ZipCodeId { get; set; }
        public ZipCode ZipCode { get; set; }

        [Display(Name = "Pickup Date")]
        [DataType(DataType.Date)]
        public DateTime PickupDate { get; set; }
        [Display(Name = "Special Pickup Date")]
        [DataType(DataType.Date)]
        public DateTime SpecialPickup { get; set; }
        [Display(Name = "Suspension Start")]
        [DataType(DataType.Date)]
        public DateTime SuspendStart { get; set; }
        [Display(Name = "Suspension End")]
        [DataType(DataType.Date)]
        public DateTime SuspendEnd { get; set; }
        [Display(Name ="Balance Due")]
        public double Balance { get; set; }


    }
}
