using System;

namespace TaskManager.Service.DTOs
{
    public class TaskOperationModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsDone { get; set; }
        public int UserId { get; set; }
    }
}
