using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRManagerWeb.Models;
using System.Net.Http;

namespace HRManagerWeb.Utils
{
    public class UserUtilities
    {
        public UserUtilities()
        { }
        public static string GetUsermameForUser(long id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri("http://localhost:9080");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("/HRManager-web/api/user/" + id).Result;

            user user = response.Content.ReadAsAsync<user>().Result;
            return user.login;

        }
    }
}