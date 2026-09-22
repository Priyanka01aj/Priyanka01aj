using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeLib.Models
{
    public class City
    {
        [Key]
        
        public int City_Id { get; set; }
        public string City_Name { get; set; }
        public int State_Id { get; set; }
        public State State { get; set; }
        

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
