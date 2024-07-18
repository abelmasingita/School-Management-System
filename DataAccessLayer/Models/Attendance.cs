namespace DataAccessLayer.Models
{
    public class Attendance
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public Student Student { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }


}
