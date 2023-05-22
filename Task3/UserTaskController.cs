using System;
using Task3.DoNotChange;
using Task3.Exceptions;

namespace Task3
{
    public class UserTaskController
    {
        private readonly UserTaskService taskService;

        public UserTaskController(UserTaskService taskService)
        {
            this.taskService = taskService;
        }

        /// <summary>
        /// Add task for the user with the provided userId.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="description">Task description.</param>
        /// <param name="model">Response model.</param>
        /// <returns>Returns true if operation successfully done, returns false with exception messages.</returns>
        public bool AddTaskForUser(int userId, string description, IResponseModel model)
        {
            try
            {
                var task = new UserTask(description);
                this.taskService.AddTaskForUser(userId, task);
                return true;
            }
            catch (ArgumentException ex)
            {
                model.AddAttribute("action_result", ex.Message);
                return false;
            }
            catch (InvalidOperationException ex)
            {
                model.AddAttribute("action_result", ex.Message);
                return false;
            }
        }
    }
}