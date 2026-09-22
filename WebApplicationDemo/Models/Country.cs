using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationDemo.Models
{
    public class Country
    {
        [Key]
        public int Country_Id { get; set; }
        [Display(Name ="Country")]
        [Required(ErrorMessage = "Country is required")]
        [Remote(action: "GetCountryIsExist", controller: "Country",AdditionalFields ="Country_Id" ,ErrorMessage = "Country already exist.")]
        public string Country_Name { get; set; }
      
        public virtual ICollection<State> States { get; set; }
    }
}
