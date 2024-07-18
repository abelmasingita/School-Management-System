namespace DataAccessLayer.Models
{
    public class Subject
    {
        public int ID { get; set; }
        public string SubjectName { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }

}
