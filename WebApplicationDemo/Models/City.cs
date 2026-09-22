using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationDemo.Models
{
    public class City
    {
        [Key]
        
        public int City_Id { get; set; }
        [Display(Name ="City")]
        [Required(ErrorMessage ="City is required")]
        [Remote("GetCityIsExist", "City",AdditionalFields ="City_Id" ,ErrorMessage = "City already exist.")]

        public string City_Name { get; set; }
        [Required(ErrorMessage ="Please enter State Name")]
        public int State_Id { get; set; }
        public State State { get; set; }
        

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
