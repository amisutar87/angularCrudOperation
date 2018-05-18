using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngularCrud.Model
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Mobile { get; set; }  
    }
}
