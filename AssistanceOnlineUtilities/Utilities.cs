﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using AssistanceOnlineUtilities.Enums;
using System.Net.Mail;
using System.Data.SqlClient;
using AssistanceOnlineDAL;
using AssistanceOnlineDAL.Enums;
using System.Threading;

namespace AssistanceOnlineUtilities
{
    public static class Utilities
    {
        //public static bool verifyReCapchat(string response)
        //{
        //    try
        //    {
        //        string secretKey = KeyBLL.selectKey(TypesKeys.secretKey).value;
        //        var client = new WebClient();

        //        var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
        //        var obj = JObject.Parse(result);
        //        return (bool)obj.SelectToken("success");
        //    }
        //    catch (WebException ex)
        //    {

        //        throw ex;
        //    }
        //}

       

    }
}
