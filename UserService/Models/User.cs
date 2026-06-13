namespace UserService.Models
{
    public class User
    {
        public int UserId
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        } = string.Empty;
        public string Email
        {
            get;
            set;
        } = string.Empty;
        public string Password
        {
            get;
            set;
        } = string.Empty;
        public DateTime CreatedDate
        {
            get;
            set;
        } = DateTime.UtcNow;

        public ICollection<Workout> Workouts { get; set; }
        = new List<Workout>();

        public ICollection<Goal> Goals { get; set; } = new List<Goal>();
    }
}
