namespace OnlineCV.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TechStack { get; set; }
        public string GitHubUrl { get; set; }
        public string LiveUrl { get; set; }
        public string ImageUrl { get; set; }
        public int Year { get; set; }
    }
}