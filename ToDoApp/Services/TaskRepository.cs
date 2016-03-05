using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoApp.Models;

namespace ToDoApp.Services
{
    public class TaskRepository
    {
        private const string CacheKey = "TaskStore";

        public TaskRepository()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                if (ctx.Cache[CacheKey] == null)//Intially When the Cache is Empty
                {
                    var Tasks = new Task[]{ //Creating Object of Model Class
                        new Task{
                                   Id=1,Tasks="Waking Up",dateTime=new DateTime(),Status="Pending"
                                }
                    };

                    ctx.Cache[CacheKey] = Tasks;
                }
            }
        }


        public Task[] GetAllTasks() //This Method return all the Tasks available
        {
            var ctx = HttpContext.Current;

            if (ctx != null)      //Checking if Http request Exists for Current
            {
                return (Task[])ctx.Cache[CacheKey];
            }

            return new Task[] //If no task is available then it will create a new task as a Demo
            {
                new Task{
                Id = 0,
                Tasks = "Demo",
                dateTime = new DateTime(),
                Status = "Pending"
                }
            };
                    

        }


        public bool saveTask(Task task) //This Method Saves the Task
        {
            var ctx = HttpContext.Current; // It return the Current HTTP request Information

            if (ctx != null)         //Checking if Http request Exists for Current
            {
                try
                {
                    var currentData = ((Task[])ctx.Cache[CacheKey]).ToList(); //Converting into list
                    currentData.Add(task); //Adding of New Task
                    ctx.Cache[CacheKey] = currentData.ToArray(); // Converting into Array

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }

            }
            return false;
        }

        public bool removeTask(Task task) //This Method Removes the Task
        {
            var ctx = HttpContext.Current; // It return the Current HTTP request Information

            if (ctx != null) //Checking if Http request Exists for Current
            {
                try
                {
                    var itemToRemove = ((Task[])ctx.Cache[CacheKey]).ToList().SingleOrDefault(Task => Task.Id == task.Id); //This statement tells which item is to be removed on the basis of Task ID.

                    if (itemToRemove != null) // If the task id exists then it is removed
                    {
                        var currentData = ((Task[])ctx.Cache[CacheKey]).ToList();  //Converting into the List
                        currentData.Remove(itemToRemove); //Removing the Task from the List
                        ctx.Cache[CacheKey] = currentData.ToArray();   //Converting into the Array
                        
                    }

                    return true;
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }

            }
            return false;
        }


        public bool updateStatusTask(Task task)  //This Method Updates the Task
        {
            var ctx = HttpContext.Current;  // It return the Current HTTP request Information

            if (ctx != null)    //Checking if Http request Exists for Current
            {
                try
                {
                    var itemToUpdate = ((Task[])ctx.Cache[CacheKey]).ToList().SingleOrDefault(Task => Task.Id == task.Id);   // Item to Update on the basis of the Task ID

                    if (itemToUpdate != null)
                    {
                        var currentData = ((Task[])ctx.Cache[CacheKey]).ToList();
                        itemToUpdate.Status = "DONE"; //Changing the Status
                        ctx.Cache[CacheKey] = currentData.ToArray();

                    }
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }

            }
            return false;
        }



    }
}