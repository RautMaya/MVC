using Student_Information_App.ExecuteFunction;
using Student_Information_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Student_Information_App.QueryFunction
{
    public class LocationQuery
    {
        Execute execute = new Execute();
        public int InsertData(LocationModel Model)
        {
            string query = "Insert Into Location(LocName,Address,RollNo) values('" + Model.LocName + "','" + Model.Address + " ',";
            query += "'" + Model.Address + "') If(@@Error=0) Select 1 else Select 0";
            int Res = execute.Excuteint(query);
            return Res;
        }
    }
}