using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoWebAPI.Data
{ 
        public enum TodoStatus {
            Initial,
            InProgress,
            Done
        }
       
    public class TodoItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        public DateTime CreateAt { get; set; }

        [Required]
        public string Title { get; set; }

        public TodoStatus status { get; set; }
        public int priorityTypeId { get; set; }
        public TodoPriorityType priorityType { get; set; }

        public TodoItem()
        {
            CreateAt = DateTime.UtcNow;
        }
    }
}
