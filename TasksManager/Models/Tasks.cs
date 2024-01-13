using System.ComponentModel.DataAnnotations.Schema;

namespace TasksManager.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public string Priority { get; set; }
        public string UserId { get; set; }
        //[ForeignKey("Id")]
       // public AspNetUsers User { get; set; }

    }
}
