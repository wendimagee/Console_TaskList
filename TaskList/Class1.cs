using System;
using System.Collections.Generic;
using System.Text;

namespace TaskList
{
    class Task
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string DueDate { get; set; }
        public bool Status { get; set; }

        public Task(string Name, string Description, string DueDate, bool Status)
        {
            this.Name = Name;
            this.Description = Description;
            this.DueDate = DueDate;
            this.Status = Status;
        }
    }
}
