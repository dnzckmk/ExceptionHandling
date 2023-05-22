using System;
using Task3.DoNotChange;
using Task3.Exceptions;

namespace Task3
{
    public class UserTaskService
    {
        private readonly IUserDao userDao;

        public UserTaskService(IUserDao userDao)
        {
            this.userDao = userDao;
        }

        /// <summary>
        /// Add task for the user.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="task">UserTask object to add to user's tasks.</param>
        /// <exception cref="ArgumentException">If the userId is not in valid form or the user is not found, throws ArgumentException.</exception>
        /// <exception cref="InvalidOperationException">If the task is already exists, throws InvalidOperationException.</exception>
        public void AddTaskForUser(int userId, UserTask task)
        {
            if (userId < 0)
            {
                throw new ArgumentException("Invalid userId");
            }

            var user = this.userDao.GetUser(userId) ?? throw new ArgumentException("User not found");

            var tasks = user.Tasks;
            foreach (var t in tasks)
            {
                if (string.Equals(task.Description, t.Description, StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException("The task already exists");
                }
            }

            tasks.Add(task);
        }
    }
}