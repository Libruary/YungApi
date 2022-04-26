using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YungApi.Models
{
    public interface IClerk
    {
        //JAddClerk_outData AddClerk(string IData);
        //JUpdateClerkPS_outData UpdateClerkPS(string IData);
    }   
        public class JAddClerk_inData
        {
            public string ClerkNo = "";
            public string Password = "";
            public string ClerkName = "";
            public string Dept = "";
            public string Email = "";
        }

        public class JAddClerk_outData
        {
            public string Status = "";
            public string Desc = "";
            public string ClerkNo = "";
        }
        public class JUpdateClerkPS_inData
        {
        public string ClerkNo = "";
        public string Password = "";
        public string ClerkName = "";
        public string Dept = "";
        public string Email = "";
    }
        public class JUpdateClerkPS_outData
        {
        public string Status = "";
        public string Desc = "";
        public string ClerkNo = "";
        }
        public class JRemoveClerkPS_inData
        {
        public string ClerkNo = "";
        }
        public class JRemoveClerkPS_outData
        {
        public string Status = "";
        public string Desc = "";
        }
    public class GetClerk_outData
        {
        public string ClerkNo = "";
        public string Password = "";
        public string ClerkName = "";
        public string Dept = "";
        public string Email = "";
        public string Status = "";
        public string Desc = "";
    }
}