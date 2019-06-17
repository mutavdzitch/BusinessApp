using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DataTransfer
{
    public class StatusDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [MinLength(3, ErrorMessage = "This field must have minimum 3 characters.")]
        [MaxLength(15, ErrorMessage = "This field must have maximum 15 characters.")]
        public string Value { get; set; }
        public IEnumerable<string> ProjectNames { get; set; }
        public IEnumerable<string> TaskNames { get; set; }
    }
}
