namespace Prularia.Filters
{
    public class LoggedInUserData
    {
        public int UserId { get; set; }
        public IEnumerable<string> SecurityGroepen { get; set; }
    }
}
