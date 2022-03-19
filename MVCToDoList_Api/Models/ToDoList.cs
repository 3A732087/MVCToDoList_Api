using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCToDoList_Api.Models
{
    public class ToDoList
    {
        public int Id { get; set; }
        [DisplayName("項目名稱")]
        [Required(ErrorMessage = "項目名稱")]
        [StringLength(50, ErrorMessage = "項目名稱不可大於50字元")]
        public string Title { get; set; }

        [DisplayName("重要層級")]
        [Required(ErrorMessage = "重要層級")]
        [StringLength(50, ErrorMessage = "重要層級不可大於50字元")]
        public string Level { get; set; }

        [DisplayName("截止日期")]
        [Required(ErrorMessage = "截止日期")]
        public DateTime Deadline { get; set; }
    }
}