using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Data;
using Data.Enums;

namespace DAL
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        public DbInitializer()
        {
            
        }
        protected override void Seed(DataContext context)
        {
            var user = new User {Email = "adm@adm.adm", Login = "admin", Role = Role.Admin, Password = "111"};

            var child1_1Activities = new Collection<Activity>
            {
                new Activity {Date = DateTime.Now, Amount = 2, SpentTime = 2.5 },
                new Activity {Date = DateTime.Now, Amount = 2, SpentTime = 1},
                new Activity {Date = DateTime.Now, Amount = 2, SpentTime = 2}
            };

            var child2_1Activities = new Collection<Activity>
            {
                new Activity {Date = DateTime.Now, Amount = 2, SpentTime = 3.25},
                new Activity {Date = DateTime.Now, Amount = 2, SpentTime = 5}
            };

            var child1Tasks = new Collection<Task>
            {
                new Task {Name = "Child1_1", Priority = Priority.High, Activities = child1_1Activities, HasEndPoint =  false, TrackAmount =  false, TrackTime = true, User = user},
                new Task {Name = "Child1_2", Priority = Priority.High, Activities = null, HasEndPoint =  false, TrackAmount =  false, TrackTime = true,User = user}
            };
            var child2Tasks = new Collection<Task>
            {
                new Task {Name = "Child2_1", Priority = Priority.High, Activities = child2_1Activities, HasEndPoint =  false, TrackAmount =  false, TrackTime = true,User = user}
            };

            var parentTasks = new Collection<Task>
            {
                new Task {Name = "Parent1", Priority = Priority.High, Activities = null, HasEndPoint =  false, TrackAmount =  false, TrackTime = true, ChildTasks = child1Tasks,User = user},
                new Task {Name = "Parent2", Priority = Priority.High, Activities = null, HasEndPoint =  false, TrackAmount =  false, TrackTime = true, ChildTasks = child2Tasks,User = user},
                new Task {Name = "Parent3", Priority = Priority.High, Activities = null, HasEndPoint =  false, TrackAmount =  false, TrackTime = true,User = user}
            };
            context.Tasks.AddRange(parentTasks);
            base.Seed(context);
        }
    }
}
