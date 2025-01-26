namespace _18_EntityFrameworkExample.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int StudentId { get; set; }// öğrenci kimliği foreign key 
        public Student Student { get; set; }//Navigation Property
    }
}
