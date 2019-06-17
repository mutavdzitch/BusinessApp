using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DataTransfer
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [MinLength(2, ErrorMessage = "This field must have minimum 2 characters.")]
        [MaxLength(30, ErrorMessage = "This field must have maximum 30 characters.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [MinLength(2, ErrorMessage = "This field must have minimum 2 characters.")]
        [MaxLength(30, ErrorMessage = "This field must have maximum 30 characters.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [MinLength(5, ErrorMessage = "This field must have minimum 5 characters.")]
        [MaxLength(20, ErrorMessage = "This field must have maximum 20 characters.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [MinLength(3, ErrorMessage = "This field must have minimum  characters.")]
        [MaxLength(50, ErrorMessage = "This field must have maximum 50 characters.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [MinLength(5, ErrorMessage = "This field must have minimum 5 characters.")]
        [MaxLength(20, ErrorMessage = "This field must have maximum 20 characters.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [MinLength(9, ErrorMessage = "This field must have minimum 9 characters.")]
        [MaxLength(11, ErrorMessage = "This field must have maximum 11 characters.")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int VocationId { get; set; }
        public string VocationName { get; set; }
        public IEnumerable<string> ProjectNames { get; set; }
        public IEnumerable<string> TaskNames { get; set; }
    }
}
