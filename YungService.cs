using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using YungApi.Models;

namespace YungApi
{
    public class YungService
    {      
        //查詢
        public bool GetClerk(string ClerkNo,ref GetClerk_outData OutData )
        {
            try
            {
                DataTable OutputTab = new DataTable("Clerk");
                OutData = new GetClerk_outData();
                string ConnectStr = ConfigurationManager.ConnectionStrings["Yung"].ConnectionString;// "data source=" + DBPath;
                using (var Conn = new SqliteConnection(ConnectStr))
                {
                    Conn.Open();
                    string sqlStr = "SELECT * FROM CLERK WHERE CLERK_NO='" + ClerkNo + "'";
                    var res = Conn.Query(sqlStr);
                    OutputTab = (DataTable)res;
                    OutData.ClerkNo = (string)OutputTab.Rows[0]["CLERK_NO"];
                    OutData.Password = (string)OutputTab.Rows[0]["PASSWORD"];
                    OutData.ClerkName = (string)OutputTab.Rows[0]["CLERK_NAME"];
                    OutData.Dept = (string)OutputTab.Rows[0]["CLERK_DEPT"];
                    OutData.Email = (string)OutputTab.Rows[0]["EMAIL"];
                    WriteOneLineLog("YungService", "[GetClerk] Success :" + OutData.ClerkNo);
                    return true;
                }
            }
            catch (Exception ex)
            {
                OutData.Status = "9999";    //錯誤代碼
                OutData.Desc = ex.Message;  //返回錯誤原因
                WriteOneLineLog("YungService", "[GetClerk] Failed :" + ex.Message);
                return false;
            }
        }
        //新增
        public bool AddClerk(JAddClerk_inData inData, ref JAddClerk_outData OutData)
        {
            try
            {
                DataTable OutputTab = new DataTable("Clerk");
                OutData = new JAddClerk_outData();
                string ConnectStr = ConfigurationManager.ConnectionStrings["Yung"].ConnectionString;
                using (var Conn = new SqliteConnection(ConnectStr))
                {
                    Conn.Open();
                    string sqlStr = "INSERT INTO CLERK VALUES('" + inData.ClerkNo + "','" + inData.Password + "','" + inData.ClerkName + "','" + inData.Dept + "','" + inData.Email + "')";
                    Conn.Execute(sqlStr);
                    OutData.Status = "0000";    //成功
                    WriteOneLineLog("YungService", "[AddClerk] Success :" + inData.ClerkNo);
                    return true;
                }
            }
            catch (Exception ex)
            {
                OutData.Status = "9999";    //錯誤代碼
                OutData.Desc = ex.Message;  //返回錯誤原因
                WriteOneLineLog("YungService", "[AddClerk] Failed :" + ex.Message);
                return false;
            }
        }
        //修改
        public bool UpdateClerk(JUpdateClerkPS_inData inData, ref JUpdateClerkPS_outData OutData)
        {
            try
            {
                DataTable OutputTab = new DataTable("Clerk");
                OutData = new JUpdateClerkPS_outData();
                string ConnectStr = ConfigurationManager.ConnectionStrings["Yung"].ConnectionString;// "data source=" + DBPath;
                using (var Conn = new SqliteConnection(ConnectStr))
                {
                    Conn.Open();
                    string sqlStr = "UPDATE  CLERK  SET PASSWORD='" + inData.Password + "',CLERK_NAME='" + inData.ClerkName + "',DEPT='" + inData.Dept + "',EMAIL='" + inData.Email + "') WHERE CLERK_NO='" + inData.ClerkNo + "'";
                    Conn.Execute(sqlStr);
                    OutData.Status = "0000";    //成功
                    WriteOneLineLog("YungService", "[UpdateClerk] Success :" + inData.ClerkNo);
                    return true;
                }
            }
            catch (Exception ex)
            {
                OutData.Status = "9999";    //錯誤代碼
                OutData.Desc = ex.Message;  //返回錯誤原因
                WriteOneLineLog("YungService", "[UpdateClerk] Failed :" + ex.Message);
                return false;
            }
        }
        //刪除
        public bool RemoveClerk(String ClerkNo, ref JRemoveClerkPS_outData OutData)
        {
            try
            {
                DataTable OutputTab = new DataTable("Clerk");
                OutData = new JRemoveClerkPS_outData();
                string ConnectStr = ConfigurationManager.ConnectionStrings["Yung"].ConnectionString;// "data source=" + DBPath;
                using (var Conn = new SqliteConnection(ConnectStr))
                {
                    Conn.Open();
                    string sqlStr = "DELETE FROM CLERK WHERE CLERK_NO='" + ClerkNo + "'";
                    Conn.Execute(sqlStr);
                    OutData.Status = "0000";    //成功
                    WriteOneLineLog("YungService", "[RemoveClerk] Success :" + ClerkNo);
                    return true;
                }
            }
            catch (Exception ex)
            {
                OutData.Status = "9999";    //錯誤代碼
                OutData.Desc = ex.Message;  //返回錯誤原因
                WriteOneLineLog("YungService", "[RemoveClerk] Failed :" + ex.Message);
                return false;
            }
        }
        //寫LOG
        public void WriteOneLineLog(string FileName, string Lk_String)
        {
            // 寫一行到檔案中
            try
            {
                string ToDay = Strings.Format(DateTime.Now.Date, "yyyyMMdd");
                System.IO.FileStream LogFile;
                StreamWriter StreamWriter;
                string WkFileName = "";
                string FileDir = "";

                FileDir = @"\YungService\log\" + ToDay;
                WkFileName = FileDir + @"\" + FileName + ".TXT";

                if (Directory.Exists(FileDir) == false)
                    Directory.CreateDirectory(FileDir);

                LogFile = new System.IO.FileStream(WkFileName, FileMode.Append, FileAccess.Write);
                StreamWriter = new StreamWriter(LogFile, System.Text.Encoding.Default);
                StreamWriter.BaseStream.Seek(0, SeekOrigin.End);
                StreamWriter.WriteLine(DateAndTime.Now.ToString() + " " + Lk_String);
                StreamWriter.Close();
            }
            catch (Exception ex)
            {

            }
        }

    }

}