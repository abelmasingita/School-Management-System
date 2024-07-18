namespace DataAccessLayer.Models
{
    public class Grade
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public Student Student { get; set; }
        public int SubjectID { get; set; }
        public Subject Subject { get; set; }
        public string GradeValue { get; set; }
    }
}
