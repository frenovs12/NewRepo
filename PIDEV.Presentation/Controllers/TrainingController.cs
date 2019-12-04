using PIDEV.Domain;
using PIDEV.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace PIDEV.Presentation.Controllers
{
    public class TrainingController : Controller
    {
        ITrainingService service;
        IUserService userService;
        public TrainingController()
        {
            service = new TrainingService();
            userService = new UserService();
        }
        // GET: Training
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080/PIDev-web/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("api/trainings/liste").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<training>>().Result;

            }
            else
            {
                ViewBag.result = "error1";
            }
            return View();
        }

        public ActionResult stat()
        {
            var t = service.GetTrainingBySubject("Soft Skills").Count();
            var f = service.GetTrainingBySubject("Hard Skills").Count();

            ViewBag.t = t;
            ViewBag.f = f;

            return View(service.GetMany().ToList());

        }

        // GET: Training/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Training/Create
        public ActionResult Create()
        {
             var users = userService.GetMany();
             ViewBag.listUsers = new SelectList(users, "id", "firstName");
             return View();

         /*   HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080/PIDev-web/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("api/trainings/listeU").Result;
            if (response.IsSuccessStatusCode)
            {
                var res= response.Content.ReadAsAsync<IEnumerable<user>>().Result;
                ViewBag.listUsers = new SelectList(res, "Id", "firstName");

            }
            else
            {
                ViewBag.result = "error1";
               
            }
            */

          //  return View();
        }

        // POST: Training/Create
        [HttpPost]
        public ActionResult Create(training t)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080/PIDev-web/");
            HttpContent content = new StringContent("");
            Client.PostAsJsonAsync("api/trainings/add/" +t.subject+"/"+t.description + "/ 2019-12-12 /" + t.duration + "/" + t.nbr + "/" +t.room + t.trainer_id, content).
                ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

            return RedirectToAction("Index", "Training");
        }

        // GET: Training/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Training/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Training/Delete/5
        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080/PIDev-web/");
            client.DeleteAsync("api/trainings/delete/" + id).ContinueWith((deleteTask) => deleteTask.Result.EnsureSuccessStatusCode());

            return RedirectToAction("Index", "Training");
        }

        // POST: Training/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
