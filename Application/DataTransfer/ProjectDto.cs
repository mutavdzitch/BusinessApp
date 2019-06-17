using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DataTransfer
{
    public class ProjectDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [MinLength(2, ErrorMessage = "This field must have minimum 2 characters.")]
        [MaxLength(30, ErrorMessage = "This field must have maximum 30 characters.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [MinLength(20, ErrorMessage = "This field must have minimum 20 characters.")]
        [MaxLength(1000, ErrorMessage = "This field must have maximum 1000 characters.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int StatusId { get; set; }
        public string StatusValue { get; set; }
        public IEnumerable<string> CompanyNames { get; set; }
        public IEnumerable<string> EmployeeNames { get; set; }
        public IEnumerable<string> TaskNames { get; set; }
    }
}
