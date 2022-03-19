using MVCToDoList_Api.Models;
using MVCToDoList_Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCToDoList_Api.Controllers
{
    public class ToDoListApiController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            ToDoListService _service = new ToDoListService();
            List<ToDoList> DataList = new List<ToDoList>();
            try
            {
                DataList = _service.GetAllToDoList();

                if (DataList != null)
                {
                    result.Add("Message", "succ");
                    result.Add("Data", DataList);
                }
                else
                {
                    result.Add("Message", "succ");
                    result.Add("Data", null);
                }
            }catch(Exception e)
            {
                result.Add("Message", e.Message.ToString());
                result.Add("Data", null);
            }
            return Ok<Dictionary<string, object>>(result);
        }

        #region 新增
        [HttpPost]
        public IHttpActionResult Post(ToDoList data)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            ToDoListService _service = new ToDoListService();
            List<ToDoList> DataList = new List<ToDoList>();
            try
            {
                int qty = _service.InsertToDoList(data);

                if (qty > 0)
                {
                    result.Add("Message", "新增成功");
                }
                else
                {
                    result.Add("Message", "新增失敗");
                }
            }
            catch (Exception e)
            {
                result.Add("Message", e.Message.ToString());
            }
            return Ok<Dictionary<string, object>>(result);
        }
        #endregion

        #region 刪除
        [HttpDelete]
        public IHttpActionResult Delete(int Id)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            ToDoListService _service = new ToDoListService();
            try
            {

                int qty = _service.DeleteToDoList(Id);
                if (qty > 0)
                {
                    result.Add("Message", "刪除完成");
                }
                else
                {
                    result.Add("Message", "刪除失敗");
                }

            }
            catch (Exception e)
            {
                result.Add("Message", e.Message.ToString());
            }

            return Ok<Dictionary<string, object>>(result);
        }
        #endregion
    }
}
