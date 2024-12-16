using BookStore.Db;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/Language")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ApplicationDbContext _connection;
        public LanguageController(ApplicationDbContext applicationdb)
        {
            _connection=applicationdb;
        }

        [HttpGet]
        [Route("getallL")]
        public IActionResult GetAllLang()
        {

           var languge= _connection.Languages.ToList();


            return Ok(languge);
        }

        [HttpGet("{id:int}")]
        public IActionResult getLang([FromRoute] int id)
        {
            // find method use only get by id primary only 
            var lan =_connection.Languages.Find(id);

            return Ok(lan);
        }

        [HttpGet("{Name}")]
        public IActionResult getLang([FromRoute] string Name)
        {
            //get by without primary key id  it is use when we wabt to get by name like that 

            var FoD = _connection.Languages.Where(x=>x.Title==Name).FirstOrDefault();//by using this if the value/id is not there then it shows null in output 
                                            //here values serch oneby one in table which takes time

            var FoD1 = _connection.Languages.FirstOrDefault(x => x.Title == Name);
            //here values first time find so it does not serch on near table which saves time

          var fir = _connection.Languages.First(x => x.Title == Name);//by using this if the value/id is not there then it shows exception  in output 


            var single = _connection.Languages.Single(x => x.Title == Name);////by using this if the value/id is not there then it shows exception  in output 


            var Sod = _connection.Languages.SingleOrDefault(x => x.Title == Name);//by using this if the value/id is not there then it shows null in output 


            return Ok(Sod);
        }




    }
}
