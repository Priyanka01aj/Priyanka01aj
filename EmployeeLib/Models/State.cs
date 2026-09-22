using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeLib.Models
{
    public class State
    {
        [Key]
        public int State_Id { get; set; }
        public string State_Name { get; set; }
        public int Country_Id { get; set; }
        public Country Country { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
