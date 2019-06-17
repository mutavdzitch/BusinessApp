using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DataTransfer
{
    public class CompanyDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [MinLength(2, ErrorMessage = "This field must have minimum 2 characters.")]
        [MaxLength(50, ErrorMessage = "This field must have maximum 50 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [MinLength(2, ErrorMessage = "This field must have minimum 2 characters.")]
        [MaxLength(50, ErrorMessage = "This field must have maximum 50 characters.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [MinLength(9, ErrorMessage = "This field must have minimum 9 characters.")]
        [MaxLength(11, ErrorMessage = "This field must have maximum 11 characters.")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int BankAccount { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [MinLength(3, ErrorMessage = "This field must have minimum  characters.")]
        [MaxLength(50, ErrorMessage = "This field must have maximum 50 characters.")]
        public string WebSite { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public IEnumerable<string> ProjectNames { get; set; }
        public IEnumerable<string> EmployeeNames { get; set; }
    }
}
