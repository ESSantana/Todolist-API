using System.Collections.Generic;
using ToDo.Entities;

namespace ToDo.Repository
{
    public interface ITaskRepository
    {
        Task GetTask(int id);
        List<Task> Get();
        Task Post(Task task);
        Task Update(Task task);
        bool Delete(int id);
    }
}