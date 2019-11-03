using System.Collections.Generic;
using ToDo.Entities;

namespace ToDo.Services
{
    public interface ITaskService
    {
        Task GetTask(int id);
        List<Task> Get();
        bool Post(Task task);
        bool Update(Task task); 
        bool Delete(int id);     
    }
}