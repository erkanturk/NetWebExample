using _12_Dependecy_Injection.Models;
using _12_Dependecy_Injection.Services.Abstract;

namespace _12_Dependecy_Injection.Services.Concrete
{
    public class MyService : IMyService
    {
        public List<Student> GetStudents()
        {
            return new List<Student>()
            {
               new Student { Id = 1, Name = "Hakan", Age = 25 },
               new Student { Id = 2, Name = "İsmail", Age = 23 },
               new Student { Id = 3, Name = "Serhan", Age = 14 }
            };
           
        }
    }
}
