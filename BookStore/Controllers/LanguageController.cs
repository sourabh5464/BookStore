using BookStore.Data;
using BookStore.Db;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        [Route("GetLangaueFilter")]
        public IActionResult GetLangaueFilter([FromQuery] string Name, [FromQuery] string? description)
        {
            //for filter 2 data
            //var dd= _connection.Languages.Where(x=>x.Title==Name && x.Description==description).FirstOrDefault();


            //FILTER 
            var dd = _connection.Languages.Where(x => x.Title == Name && (string.IsNullOrEmpty(description) || x.Description == description)).FirstOrDefault();

            //get multiple recored which name is same 
            var ddd = _connection.Languages.Where(x => x.Title == Name).ToList();


            return Ok(dd);
        }

        [HttpPost]
        public async Task<IActionResult> GetAllLanga([FromBody] List<int> obj)
        {
            //it is used when user send dyname multiple ids and we have to get multiple recoreds according to that
            var result= await _connection.Languages.Where(x=>obj.Contains(x.Id)).ToListAsync();

            //using select we can selet the table colum which is reired so time will be minimize 
            //in select querry we are manullay mapping data to obj before useing select we are writing query like select * now select id ,title
            var result1 = await _connection.Languages.Where(x => obj.Contains(x.Id)).Select(x=>new Language() {Id=x.Id, Title=x.Title}).ToListAsync();

            return Ok(result1);
        }

        //to insert a single record
        [HttpPost]
        [Route("AddLanguge")]
        public async Task<IActionResult> AddLanguge([FromBody] Language lang)
        {
            //to insert a single record data from model 
            _connection.Languages.Add(lang);// here data is not added in database it store in entity it uses a trackerpoint to track 
            await _connection.SaveChangesAsync();//here dada is add indb

            return Ok();
        }

        //to insert a multiplerecord
        [HttpPost]
        [Route("AddLangugemul")]
        public async Task<IActionResult> AddLanguge([FromBody] List<Language> lang)
        {
            await _connection.Languages.AddRangeAsync(lang);

            await _connection.SaveChangesAsync();


            return Ok();
        }



        // how to add data in multiple table at same time liek book has auther id so in both table i have to add data 
        //it will increse performance bec we are not calling db every time so.
        [HttpPost]
        [Route("AddBOOK")]
        public async Task<IActionResult> AddBOOK([FromBody] Book bookobj)
        {
            //added hardcoded new obj auther in table book author author obj and pass to add method we can pass dymanicaly in obj format
            //and directly we can add that obj

            
            Author obj = new Author()
            {
                Name="sourabh tapase",
                Email="sourabhtapase051@gmail.com"

            };

            bookobj.Author=obj;



            //to insert a single record data from model 
            _connection.Books.Add(bookobj);// here data is not added in database it store in entity it uses a trackerpoint to track 
            await _connection.SaveChangesAsync();//here dada is add indb

            return Ok();
        }

    }
}
