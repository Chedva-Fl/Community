using Microsoft.Extensions.Logging;

namespace Community
{
    public class FakeContext:IDataContext
    {
        public List<Teacher> Teacher { get; set; }
        public List<User> User { get; set; }
        public List<Courses> Courses { get; set; }
        public FakeContext() {
            Teacher=new List<Teacher>{new Teacher{name="miri",description="miri is a good teacher!!!" ,coursName="fitness"} };
        }
    }
}
