using TaskManagementAPI.DTOs;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Services
{
    public interface ITaskService
    {
        IEnumerable<TaskDto> GetAll();
        TaskDto GetById(int id);
        TaskDto Add(TaskItem task);
        TaskDto Update(TaskItem task);
        bool Delete(int id);
    }
}
