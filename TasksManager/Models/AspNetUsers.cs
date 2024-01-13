using System.ComponentModel.DataAnnotations;

namespace TasksManager.Models
{
    public class AspNetUsers
    {
        [Key]
        public string Id { get; set; }
        public string UserName { get; set; }
       // public List<Tasks> Tasks { get; set; }
    }
}
