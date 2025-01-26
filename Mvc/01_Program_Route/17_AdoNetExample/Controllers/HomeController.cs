using _17_AdoNetExample.DbService.Abstract;
using _17_AdoNetExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace _17_AdoNetExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDbService _dbService;

        public HomeController(IDbService dbService)
        {
            _dbService = dbService;//Dependency Injection ile IDbservice nesnesi alýnýr.
        }

        public IActionResult Index()
        {
            return View();//anasayfayý dönder
        }
        [HttpPost]
        public IActionResult AddData()
        {
            //Veritabanýnda veri eklemek için basit bir Sql sorgusu oluþturma
            string query = "insert into Students (FirstName,LastName,Age)Values('Erkan','Türk',30)";
            _dbService.ExecuteNonQuery(query);
            return RedirectToAction("Index");//Ýþlem sonrasýnda tekrardan Anasayfaya yönlendirilir.
        }
        [HttpPost]
        public IActionResult AddDataSecure([FromForm] Student model)
        {
            string query = "insert into Students (FirstName,LastName,Age) Values(@FirstName,@LastName,@Age)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@FirstName",model.FirstName),
                new SqlParameter("@LastName",model.LastName),
                new SqlParameter("@Age",model.Age),

            };
            _dbService.ExecuteNonQuery(query, parameters);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult GetData()
        {
            //Tüm öðrencilerin ad,soyad ve yaþ bilgilerini almak için sql sorgusu oluþturulur.
            string query = "Select FirstName,LastName,Age From Students";
            var data = _dbService.ExecuteReader(query);
            return View(data);
        }
        [HttpGet]
        public IActionResult GetCount()
        {
            //Öðrenci sayýsýný almak için Sql Sorgusu oluþturulur.
            string query = "Select Count(*) From Students";
            var count = _dbService.ExecuteScalar(query);
            return View(count);//Öðrenci sayýsýný View gönderilir
        }


    }
}
