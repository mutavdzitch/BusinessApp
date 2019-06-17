using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DataTransfer
{
    public class TaskDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [MinLength(5, ErrorMessage = "This field must have minimum 5 characters.")]
        [MaxLength(50, ErrorMessage = "This field must have maximum 50 characters.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [MinLength(20, ErrorMessage = "This field must have minimum 20 characters.")]
        [MaxLength(1000, ErrorMessage = "This field must have maximum 1000 characters.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int StatusId { get; set; }
        public string StatusValue { get; set; }
    }
}
