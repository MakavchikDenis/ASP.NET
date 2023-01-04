using API.Models;
using API.Repo.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Text.Json;

namespace API.Controllers
{
    [Controller]
    [Route("Home")]
    public class HomeController : ControllerBase
    {
        IRepository repo;

        public HomeController(Repository _repo) => repo = _repo;



        /// <summary>
        /// Список всех учеников
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<Person>),200)]
        [ProducesErrorResponseType(typeof(BadRequestObjectResult))]
        public IActionResult GetPeople()
        {
            try
            {
                //throw new Exception();
                IEnumerable<Person> Persons = ((Repository)repo).Person.Include(x => x.AdressPerson).Include(x => x.Course);
                return Ok(Persons.ToList());
            }
            catch (Exception e) {
                BadRequestObjectResult result = new BadRequestObjectResult("Неизвестная ошибка системы");
                result.StatusCode = 520;
                return result;
            
            }
        }


        /// <summary>
        /// Вернуть данные ученика по значению Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetId/{id}")]
        [ProducesResponseType(typeof(Person), 200 )]
        [ProducesErrorResponseType(typeof(BadRequestObjectResult))]
        public IActionResult GetPerson(string id) {
            try
            {
                var Person = repo.Get<Person>().Where(x => x.Id == Int32.Parse(id)).FirstOrDefault();
                return Ok(Person);
            }
            catch (Exception e) { 
                return BadRequest("Систеная ошибка");
            
            }

        }

        /// <summary>
        /// Добавление нового ученика
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost("Added")]
        [ProducesResponseType(200)]
        [ProducesErrorResponseType(typeof(BadRequestObjectResult))]
        public IActionResult AddedAction([FromBody]Person person) {
            try
            {
                
                repo.Added<Person>(person);
                return Ok();

            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
            
        
        }

        /// <summary>
        /// обновляем фамилию по ученику
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newSurname"></param>
        /// <returns></returns>
        [HttpPut("Updata/{id},{newSurname}")]
        [ProducesResponseType(200)]
        [ProducesErrorResponseType(typeof(BadRequestObjectResult))]
        public IActionResult UpdataAction(string id, string newSurname) {
            try
            {
                Person person = repo.Get<Person>().Where(x => x.Id == Int32.Parse(id)).FirstOrDefault();
                if (person == default) { throw new Exception($"Клиент -{id} не найден"); }
                person.Surname = newSurname;
                repo.Updata<Person>(person);
                return Ok();

            }
            catch (Exception e) {
                return BadRequest (e.Message);
            
            }
        
        }

        [HttpDelete("Delete")]
        [ProducesResponseType(typeof(ContentResult),200)]
        [ProducesErrorResponseType(typeof(ContentResult))]
        public ContentResult DeleteAction([FromQuery]string id) {
            try
            {
                Person person = repo.Get<Person>().Where(x => x.Id == Int32.Parse(id)).FirstOrDefault();
                if (person == default) { throw new Exception($"Клиент -{id} не найден"); }
                repo.Delete<Person>(person);
                return Content(JsonSerializer.Serialize<String>("Ок"), contentType:"application/json", contentEncoding: System.Text.Encoding.UTF8);

            }
            catch (Exception e)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(string));
                string result = default;

                using (StringWriter writer = new StringWriter()) {
                    serializer.Serialize(writer,e.Message);
                    result = writer.ToString();
                }
                
                return new ContentResult { Content = result, ContentType = "application/xml,charset=utf-8" };

            }

        }


    }
}
