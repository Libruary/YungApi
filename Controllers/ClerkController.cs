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
        // GET: Clerk
        public ActionResult Index()
        {
            return View();
        }
        public GetClerk_outData GetClerk(string ClerkNo)
        {
            GetClerk_outData OutPut = new GetClerk_outData();
            YungService YungService = new YungService();
            if (YungService.GetClerk(ClerkNo,ref OutPut))
            {
            }
            return OutPut;
        }
        public JAddClerk_outData  AddClerk(string IData) 
        {
            JAddClerk_inData InputData = JsonConvert.DeserializeObject<JAddClerk_inData>(IData);    //反序列化
            JAddClerk_outData OutPut = new JAddClerk_outData();
            YungService YungService = new YungService();
            if (YungService.AddClerk(InputData, ref OutPut))
            {
            }
            return OutPut;
        }
        public JUpdateClerkPS_outData UpdateClerk(string IData)
        {
            JUpdateClerkPS_inData InputData = JsonConvert.DeserializeObject<JUpdateClerkPS_inData>(IData);    //反序列化
            JUpdateClerkPS_outData OutPut = new JUpdateClerkPS_outData();
            YungService YungService = new YungService();
            if (YungService.UpdateClerk(InputData, ref OutPut))
            {
            }
            return OutPut;
        }
        public JRemoveClerkPS_outData RemoveClerk(string IData)
        {
            JRemoveClerkPS_inData InputData = JsonConvert.DeserializeObject<JRemoveClerkPS_inData>(IData);    //反序列化
            JRemoveClerkPS_outData OutPut = new JRemoveClerkPS_outData();
            YungService YungService = new YungService();
            if (YungService.RemoveClerk(InputData, ref OutPut))
            {
            }
            return OutPut;
        }
    }

}