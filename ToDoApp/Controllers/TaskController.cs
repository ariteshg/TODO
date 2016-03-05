using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToDoApp.Services;
using ToDoApp.Models;

namespace ToDoApp.Controllers
{
    public class TaskController : ApiController
    {
        private TaskRepository taskRepository;

        public TaskController(){    //Constructor to initialize      
           this.taskRepository = new TaskRepository();            
        }

        public Task[] Get() //Method to get all Task on HTML Page
        {
            return taskRepository.GetAllTasks();
        }

        public HttpResponseMessage Post(Task task) //Post Method to Perform Operations based on the AJAX request
        {
            if (task.action == "save") //To save the New Task
            {
                //Console.WriteLine("Inside Save");
                this.taskRepository.saveTask(task);
            }
            else if (task.action == "remove") //To Remove the Old Task
            {
                 //Console.WriteLine("Inside Remove");
                 this.taskRepository.removeTask(task);
            }
            else if (task.action == "update") // To Update the Task which is Done
            {
                // Console.WriteLine("Inside Update");
                 this.taskRepository.updateStatusTask(task);
            }

            var response = Request.CreateResponse<Task>(System.Net.HttpStatusCode.Created, task);
            
            return response;

        }

    }
}