using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class User:IEntity
    {
        [Key]
        public int UserId  { get; set; }
        public string UserName  { get; set; }
        public string UserEmail  { get; set; }
        public string PasswordHash  { get; set; }
    }
}
