using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class StatusDto
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public IEnumerable<string> ProjectNames { get; set; }
        public IEnumerable<string> TaskNames { get; set; }
    }
}
