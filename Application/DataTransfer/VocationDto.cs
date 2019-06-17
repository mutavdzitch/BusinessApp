using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DataTransfer
{
    public class VocationDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [MinLength(3, ErrorMessage = "This field must have minimum 3 characters.")]
        [MaxLength(30, ErrorMessage = "This field must have maximum 30 characters.")]
        public string Name { get; set; }
        public IEnumerable<string> EmployeeNames { get; set; }
    }
}
