
using System.Collections.Generic;
using System.Linq;
using ToDo.Entities;

namespace ToDo.Repository
{
    public class TaskRepository : ITaskRepository
    {
        #region Attributes

        private readonly TodoContext _dbContext;

        #endregion 

        #region Constructor

        public TaskRepository(TodoContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods
        
        public List<Task> Get()
        {
            return _dbContext.Tasks.ToList();
        }

        public Task GetTask(int id)
        {
            return _dbContext.Tasks.Where(t => t.Id == id).FirstOrDefault();
        }

        public Task Post(Task task)
        {
            _dbContext.Tasks.Add(task);
            return _dbContext.SaveChanges() == 1 
            ? task 
            : null;
        }

        public Task Update(Task task)
        {
            var newTask = _dbContext.Tasks.Where(t => t.Id == task.Id).FirstOrDefault();
            if (newTask != null)
            {
                newTask.Title = task.Title;
                newTask.Description = task.Description;
                newTask.Priority = task.Priority;
                newTask.Done = task.Done;

                _dbContext.Update(newTask);
                _dbContext.SaveChanges();
                return newTask;
            }
            return null;
        }
        public bool Delete(int id)
        {
            var task = _dbContext.Tasks.FirstOrDefault(t => t.Id == id);
            if(task != null)
            {
                _dbContext.Remove(task); 
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        #endregion
    }
}