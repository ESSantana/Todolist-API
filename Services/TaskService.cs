using System.Collections.Generic;
using ToDo.Entities;
using ToDo.Exception;
using ToDo.Repository;

namespace ToDo.Services
{
    public class TaskService : ITaskService
    {
        #region Attributes

        private readonly ITaskRepository taskRepository;

        #endregion

        #region Constructor

        public TaskService(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        #endregion

        #region Methods

        public List<Task> Get()
        {
            var result = taskRepository.Get();

            if (result == null)
            {
                throw new ContentException("No Task registered!");
            }

            return result;
        }

        public Task GetTask(int id)
        {
            var result = taskRepository.GetTask(id);

            if (result == null)
            {
                throw new ContentException("Any Task found!");
            }

            return result;

        }

        public bool Post(Task task)
        {
            if (!string.IsNullOrEmpty(task.Description)
                && !string.IsNullOrEmpty(task.Priority))
            {
                if(taskRepository.Post(task) == null)
                    throw new ContentException("Internal Error: Cannot save data!");
            }
            return true;
        }

        public bool Update(Task task)
        {
            if (task.Id > 0
                && !string.IsNullOrEmpty(task.Description)
                && !string.IsNullOrEmpty(task.Priority))
                {
                    if(taskRepository.Update(task) == null)
                        throw new ContentException("Cannot find register id!");
                }
            return true;
        }

        public bool Delete(int id)
        {
            if(id <= 0)
            {
                return false;
            } 
            return taskRepository.Delete(id);
        }

        #endregion
    }
}