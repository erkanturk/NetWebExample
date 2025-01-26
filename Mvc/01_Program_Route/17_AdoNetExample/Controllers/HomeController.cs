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
            _dbService = dbService;//Dependency Injection ile IDbservice nesnesi al�n�r.
        }

        public IActionResult Index()
        {
            return View();//anasayfay� d�nder
        }
        [HttpPost]
        public IActionResult AddData()
        {
            //Veritaban�nda veri eklemek i�in basit bir Sql sorgusu olu�turma
            string query = "insert into Students (FirstName,LastName,Age)Values('Erkan','T�rk',30)";
            _dbService.ExecuteNonQuery(query);
            return RedirectToAction("Index");//��lem sonras�nda tekrardan Anasayfaya y�nlendirilir.
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
            //T�m ��rencilerin ad,soyad ve ya� bilgilerini almak i�in sql sorgusu olu�turulur.
            string query = "Select FirstName,LastName,Age From Students";
            var data = _dbService.ExecuteReader(query);
            return View(data);
        }
        [HttpGet]
        public IActionResult GetCount()
        {
            //��renci say�s�n� almak i�in Sql Sorgusu olu�turulur.
            string query = "Select Count(*) From Students";
            var count = _dbService.ExecuteScalar(query);
            return View(count);//��renci say�s�n� View g�nderilir
        }


    }
}
