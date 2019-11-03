namespace ToDo.Models
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }    
        public bool Done { get; set; }  
    }
}