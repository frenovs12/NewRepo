using HRManager.domain.Entities;
using HRManagerWeb.Models;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Net.Http.Headers;
using System.Text;
using HRManager.service;
using System.IO;
using System.Reflection;
using System.Linq;

namespace HRManagerWeb.Controllers
{

    public class UserController : Controller
    {
        IDayOffService dos;
        public UserController()
        {
            dos = new DayOffService();
        }
        public string getRole()
        {
            user user = Session["user"] as user;
            return user.role;
        }
        public ActionResult Index()
        {
            if (getRole() == "ADMINISTRATOR")
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new System.Uri("http://localhost:9080");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("/HRManager-web/api/user").Result;
                if (response.IsSuccessStatusCode)
                {
                    IEnumerable<user> userList = response.Content.ReadAsAsync<IEnumerable<user>>().Result;
                    return View(userList);
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Profile", "User");
            }
        }
        public ActionResult Profile()
        {
            return View(Session["user"] as user);
        }

        public ActionResult Create()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost, ValidateInput(false)]
        public async Task<ActionResult> Add([FromBody]AddUserViewModel user)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri("http://localhost:9080");
            var response = client.PostAsJsonAsync("/HRManager-web/api/user", user).Result;

            DayOff DayOff = new DayOff();
            DayOff.Balance = 30;
            DayOff.UserId = int.Parse(getAddedUser(user).id.ToString());
            dos.Add(DayOff);
            dos.Commit();
            return RedirectToAction("Index", "User");

        }
        public user getAddedUser(AddUserViewModel user)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri("http://localhost:9080");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("/HRManager-web/api/user/" + user.login + "/" + user.password).Result;
            return response.Content.ReadAsAsync<user>().Result;

        }
        [ChildActionOnly]
        public ActionResult _DaysOffList()
        {
            user current = Session["user"] as user;
            IEnumerable<DayOff> list = dos.getDaysOffForUser(int.Parse(current.id.ToString()));
            return PartialView("_DaysOffList", list);
        }

        public async Task<ActionResult> Update(user user)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri("http://localhost:9080");
            var response = client.PutAsJsonAsync("/HRManager-web/api/user", user).Result;

            return RedirectToAction("Index", "User");

        }


        [System.Web.Mvc.HttpGet]
        public ActionResult Details(int id)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri("http://localhost:9080");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("/HRManager-web/api/user/" + id).Result;

            user user = response.Content.ReadAsAsync<user>().Result;

            return PartialView(user);

        }
        [System.Web.Mvc.HttpGet]
        public async Task<ActionResult> Delete(long id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri("http://localhost:9080");
            var response = client.DeleteAsync("/HRManager-web/api/user/" + id).Result;


            return RedirectToAction("Index", "User");

        }




        public ActionResult Statistics()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri("http://localhost:9080");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("/HRManager-web/api/user").Result;
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<user> userList = response.Content.ReadAsAsync<IEnumerable<user>>().Result;
                userList.ToList().RemoveAll(user => user.role == "ADMINISTRATOR" || user.role == "MANAGER");
                return View(userList.OrderByDescending(user => user.workTime));
            }
            else
            {
                return View();
            }
        }

        public ActionResult StatisticsQ()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri("http://localhost:9080");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("/HRManager-web/api/user").Result;
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<user> userList = response.Content.ReadAsAsync<IEnumerable<user>>().Result;
                userList.ToList().RemoveAll(user => user.role == "ADMINISTRATOR" || user.role == "MANAGER");
                return View(userList.OrderByDescending(user => user.salary));
            }
            else
            {
                return View();
            }
        }









    }
}
