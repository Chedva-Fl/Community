namespace Community
{
    public interface IDataContext
    {
        public List<Teacher> Teacher { get; set; }
        public List<User> User { get; set; }
        public List<Courses> Courses { get; set; }
    }
}
