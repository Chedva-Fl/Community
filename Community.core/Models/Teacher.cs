namespace Community.core.Models

{
    public class Teacher
    {
        public int teacherId { get; set; }
        public String name { get; set; }
        public String description { get; set; }
        public String coursName  { get; set; }
        public int CoursesId { get; set; }
        public Courses courses { get; set; }
    }
}
