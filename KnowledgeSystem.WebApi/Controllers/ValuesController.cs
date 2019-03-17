using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnowledgeSystem.DAL.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ValuesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPost]
        [Route("AddUser")]
        public void Post(string firstName, string lastName, string pass)
        {
            _unitOfWork.Users.Add(new DAL.Abstractions.Entities.User()
            {
                FirstName = firstName,
                LastName = lastName,
                Password = pass
            });
            _unitOfWork.Save();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
