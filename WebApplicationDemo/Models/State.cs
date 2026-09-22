using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationDemo.Models
{
    public class State
    {
        [Key]
        public int State_Id { get; set; }
        [Display(Name ="State")]
        [Required(ErrorMessage = "State is required")]
        [Remote("GetStateIsExist", "State", AdditionalFields = "State_Id", ErrorMessage = "State already exist.")]
        public string State_Name { get; set; }
        [Required(ErrorMessage ="Please enter Country")]
        public int Country_Id { get; set; }
        public Country Country { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
