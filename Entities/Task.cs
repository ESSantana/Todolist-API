using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo.Entities
{
    [Table("TASK")]
    public class Task
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("TITLE")]
        public string Title { get; set; }
        [Column("DESCRIPTION")]
        public string Description { get; set; }
        [Column("PRIORITY")]
        public string Priority { get; set; }    
        [Column("DONE")]
        public bool Done { get; set; }         
    }
}