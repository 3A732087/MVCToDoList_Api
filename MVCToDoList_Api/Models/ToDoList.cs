using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCToDoList_Api.Models
{
    public class ToDoList
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Level { get; set; }

        public DateTime Deadline { get; set; }
    }
}