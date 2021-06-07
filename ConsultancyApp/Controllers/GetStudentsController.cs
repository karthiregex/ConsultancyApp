using EntityDataLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToeknManager;

namespace ConsultancyApp.Controllers
{
    public class GetStudentsController : ApiController
    {
        private static string baseAddress = "https://localhost:44325/";
        public static Token GetAccessToken(string username, string password)
        {
            Token token = new Token();
            HttpClientHandler handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            var RequestBody = new Dictionary<string, string>
                {
                {"grant_type", "password"},
                {"username", username},
                {"password", password},
                };
            var tokenResponse = client.PostAsync(baseAddress + "token", new FormUrlEncodedContent(RequestBody)).Result;

            if (tokenResponse.IsSuccessStatusCode)
            {
                var JsonContent = tokenResponse.Content.ReadAsStringAsync().Result;
                token = JsonConvert.DeserializeObject<Token>(JsonContent);
                token.Error = null;
                //Session[""] = token.AccessToken;
            }
            else
            {
                token.Error = "Not able to generate Access Token Invalid usrename or password";
            }
            return token;
        }

        [Route("api/GetStudentByName")]
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public List<StudentDetail> GetStudentByName(string name)
        {
            DataBaseEntities entities = new DataBaseEntities();

            //  entities.StudentDetails.Select(s => s.FirstName.Equals(name)).FirstOrDefault();

            return (from c in entities.StudentDetails.Take(10)
                    where c.FirstName.StartsWith(name) || string.IsNullOrEmpty(name)
                    select c).ToList();
        }

        [Route("api/GetStudents")]
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public List<StudentDetail> GetStudents()
        {
            DataBaseEntities entities = new DataBaseEntities();
            return entities.StudentDetails.ToList();
        }
    }
}
