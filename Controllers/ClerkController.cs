using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YungApi.Models;

namespace YungApi.Controllers
{
    public class ClerkController : Controller
    {

        //查詢Clerk
        public GetClerk_outData GetClerk(string ClerkNo)
        {
            GetClerk_outData OutPut = new GetClerk_outData();   //先New初始回傳內容
            try
            {
                YungService YungService = new YungService();
                if (YungService.GetClerk(ClerkNo, ref OutPut))  //查詢
                {
                }
                return OutPut;
            }
            catch (Exception ex)
            {
                OutPut.Status = "9998";     //錯誤代碼
                OutPut.Desc= ex.Message;  //返回錯誤原因
                return OutPut;
            }
        }
        //新增Clerk
        public JAddClerk_outData  AddClerk(string IData) 
        {
            JAddClerk_outData OutPut = new JAddClerk_outData(); //先New初始回傳內容
            try
            {
                JAddClerk_inData InputData = JsonConvert.DeserializeObject<JAddClerk_inData>(IData);    //反序列化
                YungService YungService = new YungService();    
                if (YungService.AddClerk(InputData, ref OutPut))    //新增
                {
                }
                return OutPut;
            }
            catch (Exception ex)
            {
                OutPut.Status = "9998";     //錯誤代碼
                OutPut.Desc = ex.Message;  //返回錯誤原因
                return OutPut;
            }
        }
        //修改Clerk
        public JUpdateClerkPS_outData UpdateClerk(string IData)
        {
            JUpdateClerkPS_outData OutPut = new JUpdateClerkPS_outData();   //先New初始回傳內容
            try
            {
                JUpdateClerkPS_inData InputData = JsonConvert.DeserializeObject<JUpdateClerkPS_inData>(IData);    //反序列化
                YungService YungService = new YungService();
                if (YungService.UpdateClerk(InputData, ref OutPut))     //修改
                {
                }
                return OutPut;
            }
            catch (Exception ex)
            {
                OutPut.Status = "9998";     //錯誤代碼
                OutPut.Desc = ex.Message;  //返回錯誤原因
                return OutPut;
            }
        }
        //移除Clerk
        public JRemoveClerkPS_outData RemoveClerk(string ClerkNo)
        {
            JRemoveClerkPS_outData OutPut = new JRemoveClerkPS_outData();   //先New初始回傳內容
            try
            {
                YungService YungService = new YungService();
                if (YungService.RemoveClerk(ClerkNo, ref OutPut))   //移除
                {
                }
                return OutPut;
            }
            catch (Exception ex)
            {
                OutPut.Status = "9998";     //錯誤代碼
                OutPut.Desc = ex.Message;  //返回錯誤原因
                return OutPut;
            }
        }
    }

}