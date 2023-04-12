using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Assignment:IEntity
    {
        [Key]
        public int AssignmentId { get; set; }
        public string AssignmentName { get; set; }
        public int AssignmentStatus { get; set; }
        public int UserId { get; set; }
        public byte[] UserToken { get; set; }
        public string? UserComment { get; set; }

    }
}
