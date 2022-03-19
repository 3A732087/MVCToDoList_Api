using MVCToDoList_Api.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCToDoList_Api.Services
{
    public class ToDoListService
    {
        //連線字串
        private readonly static string cnstr = ConfigurationManager.ConnectionStrings["ToDoListApi"].ConnectionString;

        //資料庫連線
        private readonly SqlConnection conn = new SqlConnection(cnstr);

        #region 查詢所有待辦事項
        public List<ToDoList> GetAllToDoList()
        {
            List<ToDoList> DataList = new List<ToDoList>();
            string sql = @"select m.* from ToDoList m";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ToDoList Data = new ToDoList();
                    Data.Id = Convert.ToInt32(dr["Id"]);
                    Data.Title = dr["Title"].ToString();
                    Data.Level = dr["Level"].ToString();
                    Data.Deadline = Convert.ToDateTime(dr["Deadline"]);

                    DataList.Add(Data);
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
            return DataList;

        }
        #endregion

        #region 查詢一筆待辦事項
        public ToDoList GetToDoListById(int Id)
        {
            ToDoList Data = new ToDoList();

            string sql = $@"select m.* from ToDoList m where 1=1 and m.Id = {Id}";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                Data.Id = Convert.ToInt32(dr["Id"]);
                Data.Title = dr["Title"].ToString();
                Data.Level = dr["Level"].ToString();
                Data.Deadline = Convert.ToDateTime(dr["Deadline"]);
            }
            catch(Exception e)
            {
                Data = null;
            }
            finally
            {
                conn.Close();
            }
            return Data;

        }
        #endregion

        #region 新增待辦事項
        public int InsertToDoList(ToDoList newData)
        {
            string sql = $@"insert into ToDoList (Title, Level, Deadline) values ('{newData.Title}','{newData.Level}','{DateTime.Now.ToString("yyyy/MM/dd")}')";
            int res = 0;

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                res = cmd.ExecuteNonQuery();

            }
            catch(Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
            return res;
        }
        #endregion

        #region 刪除待辦事項
        public int DeleteToDoList(int Id)
        {
            string sql = $@"delete from ToDoList where 1=1 and Id = {Id}";
            int res = 0;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                res = cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
            return res;
        }
        #endregion
    }
}