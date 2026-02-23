using OnlineCV.Models;

namespace OnlineCV.ViewModels
{
    public class CVViewModel
    {
        public PersonalInfo PersonalInfo { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Project> Projects { get; set; }
        public List<Education> Education { get; set; }
        public List<Experience> Experiences { get; set; }
        public List<Certification> Certifications { get; set; }
        public List<Volunteering> Volunteerings { get; set; }
        public List<Interest> Interests { get; set; }
    }
}