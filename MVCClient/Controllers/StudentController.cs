using MVCClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Headers;
using System.Web.Script.Serialization;
using ToeknManager;
using System.Security.Claims;

namespace MVCClient.Controllers
{
    public class StudentController : Controller
    {

        string baseUrl = "https://localhost:44325/api/";
        // GET: Student
        public ActionResult Index()
        {
            IEnumerable<StudentViewModel> students = null;
            Token token = ClsTokenMgr.GetAccessToken("John", "john123");
            ViewBag.name = "Testing";
            using (var client = new HttpClient())
            {
                //Getting Required Data from Identity(App Cookie)
                var identity = (ClaimsIdentity)User.Identity;

                //var token = identity.Claims.Where(c => c.Type == "AcessToken")
                       //     .Select(c => c.Value).FirstOrDefault();
                //Passing service base url  
                client.BaseAddress = new Uri(baseUrl);


                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);

                //Token token = ClsTokenMgr.GetAccessToken("John", "john123");
               // client.BaseAddress = new Uri(baseUrl);
               // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
                //HTTP GET
                var responseTask = client.GetAsync("GetStudents").Result;


                if (responseTask.IsSuccessStatusCode)
                {
                    var JsonContent = responseTask.Content.ReadAsStringAsync().Result;
                    students = JsonConvert.DeserializeObject<IEnumerable<StudentViewModel>>(JsonContent);
                }
                else //web api sent error response 
                {
                    //log response status here..

                    students = Enumerable.Empty<StudentViewModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(students);
        }

        public ActionResult SearchStudent()
        {

            IEnumerable<StudentViewModel> students = SearchStudents("Dhoni");
            return View(students);
        }


        public static List<StudentViewModel> SearchStudents(string name)
        {
            Token token = ClsTokenMgr.GetAccessToken("John", "john123");

            List<StudentViewModel> customers = new List<StudentViewModel>();
            string apiUrl = "https://localhost:44325/api/";

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);

            HttpResponseMessage response = client.GetAsync(apiUrl + string.Format("/GetStudentByName?name={0}", name)).Result;
            if (response.IsSuccessStatusCode)
            {
                customers = (new JavaScriptSerializer()).Deserialize<List<StudentViewModel>>(response.Content.ReadAsStringAsync().Result);
            }

            //Post Sample
            if (!string.IsNullOrEmpty(token.AccessToken))
            {
                CallAPIResourcePost(token.AccessToken);
            }
            else
            {
                Console.WriteLine(token.Error);
            }

            return customers;
        }

        public static void CallAPIResourcePost(string AccessToken)
        {
            HttpClientHandler handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
            string baseAddress = "https://localhost:44325/api/";

            var RequestBody = new Dictionary<string, string>
                {
                {"Parameter1", "value1"},
                {"Parameter2", "vakue2"},
                };

            var APIResponse = client.PostAsync(baseAddress + "api/AddStudent", new FormUrlEncodedContent(RequestBody)).Result;

            if (APIResponse.IsSuccessStatusCode)
            {
                var JsonContent = APIResponse.Content.ReadAsStringAsync().Result;
                //Token Message = JsonConvert.DeserializeObject<Token>(JsonContent);  
                Console.WriteLine("APIResponse : " + JsonContent.ToString());
            }
            else
            {
                Console.WriteLine("APIResponse, Error : " + APIResponse.StatusCode);
            }
        }
    }
}