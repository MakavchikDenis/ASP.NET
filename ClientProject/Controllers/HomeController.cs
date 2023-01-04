using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ClientProject.ServiceForApi;
using NLog;
using ClientProject.Repository;
using ClientProject.Models.Logs;
using System;
using System.Text.Json;
using API.Models;
using System.Linq;
using System.Collections.Generic;



namespace ClientProject.Controllers
{

    public class HomeController : Controller
    {
        readonly IContextLogs contextLogs;
        readonly Logger logger;
        /*eadonly IServiceForApi<string> serviceForApi;*/

        public HomeController(IContextLogs _contextLogs, Logger _logger) => (contextLogs, logger) = (_contextLogs, _logger);

        public async Task<IActionResult> Index([FromServices] IServiceForApi<object> serviceForApi)
        {
            try
            {
                var result = IntegrationWithAPI("GetPeople", serviceForApi);
                if (result.GetType() == typeof(Exception)) { throw new Exception(((Exception)result).Message); }
                var resultPreapre = (string)result;

                List<Person> people = JsonSerializer.Deserialize<List<Person>>(resultPreapre);

                await contextLogs.SetToLogsAsync(new InsertToLogs
                {
                    ActionType = nameof(Index),
                    ActionDetails = "get all people",
                    Details = JsonSerializer.Serialize(resultPreapre, resultPreapre.GetType())
                });



                return View(people.ToList());
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                return View("../ErrorPage.cshtml");

            }
        }

        [NonAction]
        private object IntegrationWithAPI(string actionType, IServiceForApi<object> _serviceForApi, params object[] values)
        {
            return actionType switch
            {
                "GetPeople" => _serviceForApi.GetPeopleForApiAsync(),
                _ => ""
            };

        }

    }


}
