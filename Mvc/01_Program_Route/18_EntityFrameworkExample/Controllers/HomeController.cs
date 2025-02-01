using _18_EntityFrameworkExample.Data;
using _18_EntityFrameworkExample.Extensions;
using _18_EntityFrameworkExample.Models;
using _18_EntityFrameworkExample.ViewModels;
using EFCore.BulkExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace _18_EntityFrameworkExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly SchoolContext _context;

        public HomeController(SchoolContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Student> students = _context.Students.ToList();
            return View(students);
        }

        // öðrenci detaylarýný gösterme
        public IActionResult Details(int id)
        {
            // Ýd ye göre öðrenciyi bul 
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Age,Department")] Student student)
        {
            if (ModelState.IsValid)
            {
                // model geçerli ise yeni öðreci ekle
                _context.Add(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }
        public IActionResult Edit(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Age,Department")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    if (!StudentExists(student.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(student);
        }
        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
        //Sorgu söz dizimi ile sql den yaþý 18 den büyük olan öðrencileri listeleme iþlemi
        //Select * from Students where Age>18
        public IActionResult QuerySyntax()
        {
            var students = (from s in _context.Students
                            where s.Age > 18
                            select s).ToList();

            return View(students);

        }
        //Method söz dizimi 
        public IActionResult MethodSyntax()
        {
            var students = _context.Students.Where(s => s.Age < 18).ToList();
            return View(students);
        }

        public IActionResult Join()
        {
            var studentCourses = (from student in _context.Students
                                  join course in _context.Courses on student.Id equals course.StudentId
                                  select new
                                  {
                                      StudentName = student.Name,
                                      CourseTitle = course.Title
                                  }).ToList();
            return View(studentCourses);
        }
        public IActionResult GetStudentsByDepartment()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetStudentsByDepartment(string department)
        {
            var students = new List<Student>();
            try
            {
                students = _context.Students
                         .FromSqlInterpolated($"Exec GetStudentsByDepartment{department}").ToList();
            }
            catch (Exception)
            {

                students = new List<Student>();
            }
            ViewData["Students"] = students;
            return View();
        }
        public IActionResult GroupByDepartment()
        {
            var groupedStudents = _context.Students
                .GroupBy(s => s.Department)
                .Select(g => new GroupedStudentViewModel
                {
                    Department = g.Key,
                    Students = g.ToList()
                }).ToList();
            return View(groupedStudents);
        }
        [HttpPost("Transaction")]
        public IActionResult AddStudentsWithTransaction([FromBody] List<Student> students)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.Students.AddRange(students);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();

                return StatusCode(500, "Öðrenci eklenirken bir hata oluþtu");
            }
            return Ok();

        }
        public IActionResult RawSql()
        {
            var students = _context.Students.FromSqlRaw("Select * from Students where age>18").ToList();
            return View("Index", students);


        }
        public IActionResult CustomExtensionMethod()
        {
            var students = _context.Students.ToList();
            var groupedStudentByAge = students.GroupByAgeRange();
            return View(groupedStudentByAge);
        }
        public IActionResult BulkInsert()
        {
            var students = new List<Student>()
            {
                new Student{Name="Bulk 1", Age=20,Department="Bulk Bölüm1"},
                new Student{Name="Bulk 2", Age=22,Department="Bulk Bölüm2"}
            };
            _context.BulkInsert(students);
            return View("Index", students);
        }
    }
}
