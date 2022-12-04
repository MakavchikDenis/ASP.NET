using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Repo.EF;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace API.Controllers
{
    [Controller]
    [Route("[Controller]")]
    public class Main : ControllerBase
    {
        IRepository repo;

        public Main(Repository _repo) => repo = _repo;



        /// <summary>
        /// All data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetPeople()
        {
            IEnumerable<Person> Persons = ((Repository)repo).Person.Include(x => x.Adresses).Include(x => x.Kurses);
            return Ok(Persons.ToList());

        }


        /// <summary>
        /// Extra person
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetPerson(string id) {
            var Person = repo.Get<Person>().Where(x => x.Id == Int32.Parse(id)).FirstOrDefault();

            if (Person==default)
            {
                return NotFound();
            }
            return Ok(Person);
            

        }

        [HttpPost("Added")]
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


        [HttpPut("Updata/{id},{newSurname}")]
        public IActionResult UpdataAction(string id, string newSurname) {
            try
            {
                Person person = repo.Get<Person>().Where(x => x.Id == Int32.Parse(id)).FirstOrDefault();
                if (person == default) { throw new Exception($"Client -{id} doesn't search"); }
                person.Surname = newSurname;
                repo.Updata<Person>(person);
                return Ok();

            }
            catch (Exception e) {
                return BadRequest (e.Message);
            
            }
        
        }

        [HttpDelete]
        public ContentResult DeleteAction([FromQuery]string id) {
            try
            {
                Person person = repo.Get<Person>().Where(x => x.Id == Int32.Parse(id)).FirstOrDefault();
                if (person == default) { throw new Exception($"Client -{id} doesn't search"); }
                repo.Delete<Person>(person);
                return Content("Ok");

            }
            catch (Exception e)
            {
                return new ContentResult { Content = "Error", ContentType = "application/json,charset=utf-8" };

            }

        }


    }
}
