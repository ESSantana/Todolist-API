using Microsoft.EntityFrameworkCore;
using ToDo.Entities;

namespace ToDo.Repository
{
    public class TodoContext : DbContext
    {
        #region Constructor

        public TodoContext(DbContextOptions<TodoContext> options) 
            : base(options)
        { }

        #endregion

        #region Context

        public DbSet<Task> Tasks { get; set; }
    
        #endregion
    }
}