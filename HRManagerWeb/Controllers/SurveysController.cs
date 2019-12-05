using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Net.Http;
using HRManager.data;
using HRManager.domain.Entities;
using HRManager.service;
using HRManagerWeb.Models;

namespace HRManagerWeb.Controllers
{
    public class SurveysController : Controller
    {
        private HRManagerContext db = new HRManagerContext();
        ISurveyService surveyService;
        IResponseService responseService;
        public SurveysController()
        {
            surveyService = new SurveyService();
            responseService = new ResponseService();
        }
        // TODO : fix
        public ActionResult Index()
        {
            user current = Session["User"] as user;
            if (current.role == "ADMINISTRATOR")
            {
                var surveys = surveyService.GetAll().Where(Survey => Survey.Type == SurveyType.Template);

                return View(surveys);
            }
            else
            {
                IEnumerable<Response> responses = responseService.GetAll().Where(response => response.UserId == current.id);
                IEnumerable<Survey> surveys = surveyService.GetAll();
                if (responses.Count() > 0)
                {
                    foreach (Response response in responses)
                    {

                        surveys.ToList().RemoveAll(survey => survey == response.Survey);


                    }
                }

                return View(surveys);
            }
        }


        public string getRole()
        {
            user user = Session["user"] as user;
            return user.role;
        }
        public ActionResult Eval()
        {
            if (getRole() == "ADMINISTRATOR")
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new System.Uri("http://localhost:9080");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("/HRManager-web/api/eval").Result;
                if (response.IsSuccessStatusCode)
                {
                    IEnumerable<evaluation> evalList = response.Content.ReadAsAsync<IEnumerable<evaluation>>().Result;
                    return View(evalList);
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Eval", "Surveys");
            }
        }

        [System.Web.Mvc.HttpGet]    
        public async Task<ActionResult> DeleteEval(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri("http://localhost:9080");
            var response = client.DeleteAsync("/HRManager-web/api/eval/" + id).Result;


            return RedirectToAction("Eval", "Surveys");

        }
        public async Task<ActionResult> EvalUpdate(evaluation ev)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri("http://localhost:9080");
            var response = client.PutAsJsonAsync("/HRManager-web/api/eval", ev).Result;

            return RedirectToAction("Eval", "Surveys");

        }
        // GET: Surveys/Details/5


        // GET: Surveys/Create
        public ActionResult Create(long id)
        {
            Survey Survey = new Survey();
            Survey.UserId = int.Parse(id.ToString());
          
            return View(Survey);
        }
        public ActionResult Add(Survey survey)
        {
            if (survey.Title != null && survey.Title != "")
            {
                Survey survey1 = new Survey();
                survey1.Title = survey.Title;
                survey1.Type = SurveyType.Template;
                surveyService.Add(survey1);

                surveyService.Commit();
                return RedirectToAction("Index");
            }
            else
            {

                return RedirectToAction("Create", "Surveys", new { id = (Int64)survey.UserId });
            }
        }
        public ActionResult FillSurvey(int SurveyId, long userId)
        {
            var Response = new Response();
            Response.UserId = int.Parse(userId.ToString());
            Response.Survey = surveyService.GetById(SurveyId);
            Response.Survey.Date = DateTime.Today;
            return View(Response);
        }

        public ActionResult SubmitSurvey(Response model)
        {
            Survey survey = model.Survey;
            survey.Type = SurveyType.Submitted;
            survey.SurveyId = 0;
            surveyService.Add(survey);
            surveyService.Commit();
            responseService.Add(model);
            responseService.Commit();
            return RedirectToAction("Index", "Surveys");
        }

        public ActionResult Question(int SurveyId)
        {
            Survey Survey = surveyService.GetById(SurveyId);
            Criterion criterion = new Criterion();
            Session["SurveyId"] = SurveyId.ToString() as string;
            criterion.Description = "";
            Survey.Criteria.Add(criterion);

            return View(Survey.Criteria);


        }
        public ActionResult AddQuestion(List<Criterion> model)
        {
            if (!string.IsNullOrEmpty(Session["SurveyId"] as string))
            {
                int SurveyId = int.Parse(Session["SurveyId"] as string);
                Criterion criterion = model.FindLast(crit => crit.Description != null && crit.Description != "");
                Criterion criterion1 = new Criterion();
                criterion1.Description = criterion.Description;
                surveyService.AddSurveyQuestion(SurveyId, criterion1);
                return RedirectToAction("Question", "Surveys", new { SurveyId });
            }
            else
            {
                return RedirectToAction("Index", "Surveys");
            }
        }

        // GET: Surveys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Survey.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }

        // POST: Surveys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        public ActionResult Details()
        {
            user user = Session["User"] as user;
            if (user.role == "ADMINISTRATOR")
            {
                return View(responseService.GetAll());
            }
            else
            {
                return View(responseService.GetAll().Where(response => response.UserId == user.id));
            }

        }
        // GET: Surveys/Delete/5
        public ActionResult Delete(int SurveyId)
        {
            surveyService.DeleteById(SurveyId);
            return RedirectToAction("Index", "Surveys");
        }


    }
}
