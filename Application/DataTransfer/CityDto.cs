using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DataTransfer
{
    public class CityDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [MinLength(2, ErrorMessage = "This field must have minimum 2 characters.")]
        [MaxLength(20, ErrorMessage = "This field must have maximum 20 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [Range(0, 99999)]
        public int PostalCode { get; set; }
        public IEnumerable<string> CompanyNames { get; set; }
    }
}
