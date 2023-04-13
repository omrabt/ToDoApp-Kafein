using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class AddUpdateRequestDto
    {
        public int AssignmentId { get; set; }
        public string AssignmentName { get; set; }
        public int AssignmentStatus { get; set; }
        public string? UserComment { get; set; }
    }
}
