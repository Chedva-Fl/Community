using System.ComponentModel.DataAnnotations;

namespace Community.core.Models
{
    public class Courses
    {
        [Key]
        public int coursId { get; set; }
        public String name { get; set; }
        public String description { get; set; }
        public List<User> Users { get; set; }
        public Teacher Teacher { get; set; }

    }
}
