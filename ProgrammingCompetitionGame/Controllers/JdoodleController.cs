using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using Newtonsoft.Json;
using ProgrammingCompetitionGame.Domain.Entities.DTOs;
using ProgrammingCompetitionGame.Services;
using ProgrammingCompetitionGame.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingCompetitionGame.Controllers
{
    [Route("api/Challange")]
    [ApiController]
    public class JdoodleController : ControllerBase
    {
        private readonly string clientId = "a7e1f813ebe514bc59dbfb9fde50fa5a";
        private readonly string clientSecret = "27870ebee6caf92a90fac6b57320782494c3a0c2a35002b5676e817e876cad13";
        private readonly string versionIndex = "0";
        private readonly IServiceClass _service;
        static HttpClient client = new HttpClient();
        private string _baseadres = "https://api.jdoodle.com/v1/execute";

        public JdoodleController(IServiceClass service) {
            _service = service;
            if (client.BaseAddress == null)
            {
                client.BaseAddress = new Uri(_baseadres);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
            }
        }

        [HttpPost]
        [Route("submitTask")]
        public async Task submitTaskAsync([FromBody] ParticipantDTO view)
        {
            try
            {
                JsonModel jsonModel = new JsonModel();
                jsonModel.ClientId = clientId;
                jsonModel.ClientSecret = clientSecret;
                jsonModel.Script = view.SolutionCode;
                jsonModel.Language = view.Task.ToLower();
                jsonModel.VersionIndex = versionIndex;
                string myJson = "{'clientId': " + clientId + ",'clientSecret':" + clientSecret+ ",'script':" +view.SolutionCode + ",'language':" + view.Task.ToLower() + ",'versionIndex':" +versionIndex + "}";
                using (var client = new HttpClient())
                {
                    var uri = new Uri("https://api.jdoodle.com/v1/execute");
                    var json1 = new JavaScriptSerializer().Serialize(jsonModel);
                    var stringContent = new StringContent(json1, Encoding.UTF8, "application/json");
                    var response =  client.PutAsync(uri, stringContent).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        string b = responseContent.ToLower();
                        var jsonResponseModel = new JavaScriptSerializer().Deserialize<JsonResponseModel>(responseContent);
                        _service.RateSolution(jsonResponseModel, view);
                    }
                    else
                    {
                         BadRequest("request is incorrect");
                    }
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
