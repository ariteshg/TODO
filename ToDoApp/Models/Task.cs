using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoApp.Models
{
    //Model Class
    public class Task
    {
        //Getter Setter Methods

        public int Id { get; set; } 

        public string Tasks { get; set; }

        public DateTime dateTime {get; set;}

        public string Status {get; set;}

        public string action { get; set; }
    }
}