using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoWebAPI.Data
{
    public enum TodoPriorityTypes
    {
        ImportantUrgent = 1,
        ImportantNotUrgent = 2,
        NotImportantUrgent = 3,
        NotImportantNotUrgent = 4
    }
    public class TodoPriorityType
    {
        [Key]
        public int Id
        {
            get
            {
                return (int)todoPriorityType;
            }
            set
            {
                todoPriorityType = (TodoPriorityTypes)value;
            }
        }

        public TodoPriorityTypes todoPriorityType { get; set; }
    }
}
