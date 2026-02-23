using Microsoft.AspNetCore.Mvc;
using OnlineCV.Models;
using OnlineCV.ViewModels;
using DinkToPdf;
using DinkToPdf.Contracts;
using System.Text;

namespace OnlineCV.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConverter _converter;

        public HomeController(IConverter converter)
        {
            _converter = converter;
        }

        public IActionResult Index()
        {
            var viewModel = new CVViewModel
            {
                PersonalInfo = new PersonalInfo
                {
                    FullName = "Sih-Jin Lee",
                    Title = "Final-Year IT Student",
                    AboutMe = "I'm a passionate IT student with a love for creating elegant solutions to complex problems. Currently focusing on full-stack development with ASP.NET Core and modern JavaScript frameworks. I enjoy turning ideas into reality through code and continuously learning new technologies.",
                    Email = "leesihjin@gmail.com",
                    GitHubUrl = "https://github.com/Lee-SihJin",
                    Location = "Johannesburg, South Africa"
                },

                Skills = new List<Skill>
                {
                    // Languages
                    new Skill { Category = "Languages", Name = "Java" },
                    new Skill { Category = "Languages", Name = "C#" },
                    new Skill { Category = "Languages", Name = "Kotlin" },
                    new Skill { Category = "Languages", Name = "JavaScript" },
                    new Skill { Category = "Languages", Name = "SQL" },
                    
                    // Frameworks
                    new Skill { Category = "Frameworks", Name = "ASP.NET Core" },
                    new Skill { Category = "Frameworks", Name = "Entity Framework" },
                    new Skill { Category = "Frameworks", Name = "Bootstrap" },
                    
                    // Tools
                    new Skill { Category = "Tools", Name = "Git" },
                    new Skill { Category = "Tools", Name = "VS Code" },
                    new Skill { Category = "Tools", Name = "Visual Studio" },
                    new Skill { Category = "Tools", Name = "Android Studio" },
                    
                    // Soft Skills
                    new Skill { Category = "Soft Skills", Name = "Team Collaboration" },
                    new Skill { Category = "Soft Skills", Name = "Problem Solving" },
                    new Skill { Category = "Soft Skills", Name = "Communication" },
                    new Skill { Category = "Soft Skills", Name = "Time Management" },
                },

                Projects = new List<Project>
                {
                    new Project
                    {
                        Id = 1,
                        Name = "Contract Monthly Claim System",
                        Description = "A comprehensive ASP.NET Core web application for managing monthly contract claims in an academic environment.",
                        TechStack = "C#, ASP.NET Core, SQL Server, Bootstrap",
                        GitHubUrl = "https://github.com/Lee-SihJin/PROG6212_POE_ST10451904.git",
                        Year = 2025
                    },
                    new Project
                    {
                        Id = 2,
                        Name = "ABC Retailers - E-commerce Platform",
                        Description = "A comprehensive ASP.NET Core e-commerce solution built with Azure cloud services, featuring a modern retail management system with customer shopping cart, order processing, and administrative capabilities.",
                        TechStack = "C#, ASP.NET Core, Azure Functions Core Tools",
                        GitHubUrl = "https://github.com/Lee-SihJin/CLDV6212_POE_ST10451904.git",
                        Year = 2025
                    }
                },

                Education = new List<Education>
                {
                    new Education
                    {
                        Id = 1,
                        Degree = "Bachelor of Computer and Information Sciences in Application",
                        Institution = "Emeris",
                        ExpectedGraduation = "Expected 2026",
                        Modules = "Information Systems, Programming, Introduction to Research for ICT, Cloud Development, Principles of Security, IT Professional Practice, Network Engineering"
                    }
                },

                Experiences = new List<Experience>
                {
                    new Experience
                    {
                        Id = 1,
                        Position = "Tutor",
                        Company = "Private",
                        Duration = "October 2025-Now",
                        Description = "Teaching students schoolwork includes English, Math, and Mandarin."
                    }
                },

                Interests = new List<Interest>
                {
                    new Interest { Id = 1, Name = "Photography", Icon = "📷" },
                    new Interest { Id = 2, Name = "Gaming", Icon = "🎮" }
                }
            };

            return View(viewModel);
        }

        public IActionResult DownloadPDF()
        {
            var viewModel = GetViewModel(); // Reuse your data

            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 20, Bottom = 20, Left = 20, Right = 20 },
                DocumentTitle = $"CV - {viewModel.PersonalInfo.FullName}"
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = GeneratePDFHTML(viewModel),
                WebSettings = {
                    DefaultEncoding = "utf-8",
                    UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "css", "pdf-styles.css")
                },
                HeaderSettings = {
                    FontSize = 9,
                    Right = "Page [page] of [toPage]",
                    Line = true,
                    Spacing = 5
                },
                FooterSettings = {
                    FontSize = 9,
                    Center = $"{viewModel.PersonalInfo.FullName} - CV",
                    Line = true,
                    Spacing = 5
                }
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            var file = _converter.Convert(pdf);
            return File(file, "application/pdf", $"{viewModel.PersonalInfo.FullName.Replace(" ", "_")}_CV.pdf");
        }

        private CVViewModel GetViewModel()
        {
            // Return the same view model as in Index action
            return new CVViewModel
            {
                PersonalInfo = new PersonalInfo
                {
                    FullName = "Sih-Jin Lee",
                    Title = "Final-Year IT Student",
                    AboutMe = "I'm a passionate IT student with a love for creating elegant solutions to complex problems.",
                    Email = "leesihjin@gmail.com",
                    GitHubUrl = "https://github.com/Lee-SihJin",
                    Location = "Johannesburg, South Africa"
                },
                Skills = new List<Skill>
                {
                    new Skill { Category = "Languages", Name = "Java" },
                    new Skill { Category = "Languages", Name = "C#" },
                    new Skill { Category = "Languages", Name = "Kotlin" },
                    new Skill { Category = "Languages", Name = "JavaScript" },
                    new Skill { Category = "Languages", Name = "SQL" },
                    new Skill { Category = "Frameworks", Name = "ASP.NET Core" },
                    new Skill { Category = "Frameworks", Name = "Entity Framework" },
                    new Skill { Category = "Frameworks", Name = "Bootstrap" },
                    new Skill { Category = "Tools", Name = "Git" },
                    new Skill { Category = "Tools", Name = "VS Code" },
                    new Skill { Category = "Tools", Name = "Visual Studio" },
                    new Skill { Category = "Tools", Name = "Android Studio" },
                    new Skill { Category = "Soft Skills", Name = "Team Collaboration" },
                    new Skill { Category = "Soft Skills", Name = "Problem Solving" },
                    new Skill { Category = "Soft Skills", Name = "Communication" },
                    new Skill { Category = "Soft Skills", Name = "Time Management" }
                },
                Projects = new List<Project>
                {
                    new Project
                    {
                        Name = "Contract Monthly Claim System",
                        Description = "A comprehensive ASP.NET Core web application for managing monthly contract claims in an academic environment.",
                        TechStack = "C#, ASP.NET Core, SQL Server, Bootstrap",
                        GitHubUrl = "https://github.com/Lee-SihJin/PROG6212_POE_ST10451904.git",
                        Year = 2025
                    },
                    new Project
                    {
                        Name = "ABC Retailers - E-commerce Platform",
                        Description = "A comprehensive ASP.NET Core e-commerce solution built with Azure cloud services.",
                        TechStack = "C#, ASP.NET Core, Azure Functions Core Tools",
                        GitHubUrl = "https://github.com/Lee-SihJin/CLDV6212_POE_ST10451904.git",
                        Year = 2025
                    }
                },
                Education = new List<Education>
                {
                    new Education
                    {
                        Degree = "Bachelor of Computer and Information Sciences in Application",
                        Institution = "Emeris",
                        ExpectedGraduation = "Expected 2026",
                        Modules = "Information Systems, Programming, Introduction to Research for ICT, Cloud Development, Principles of Security, IT Professional Practice, Network Engineering"
                    }
                },
                Experiences = new List<Experience>
                {
                    new Experience
                    {
                        Position = "Tutor",
                        Company = "Private",
                        Duration = "October 2025-Now",
                        Description = "Teaching students schoolwork includes English, Math, and Mandarin."
                    }
                },
                Interests = new List<Interest>
                {
                    new Interest { Name = "Photography", Icon = "📷" },
                    new Interest { Name = "Gaming", Icon = "🎮" }
                }
            };
        }

        private string GeneratePDFHTML(CVViewModel model)
        {
            var sb = new StringBuilder();

            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html>");
            sb.AppendLine("<head>");
            sb.AppendLine("<meta charset='UTF-8'>");
            sb.AppendLine("<title>CV - " + model.PersonalInfo.FullName + "</title>");
            sb.AppendLine("</head>");
            sb.AppendLine("<body>");

            // Header
            sb.AppendLine("<div class='header'>");
            sb.AppendLine("<h1>" + model.PersonalInfo.FullName + "</h1>");
            sb.AppendLine("<p class='title'>" + model.PersonalInfo.Title + "</p>");
            sb.AppendLine("<p class='location'>" + model.PersonalInfo.Location + "</p>");
            sb.AppendLine("<p>Email: " + model.PersonalInfo.Email + "</p>");
            sb.AppendLine("<p>GitHub: " + model.PersonalInfo.GitHubUrl + "</p>");
            sb.AppendLine("</div>");

            // About
            sb.AppendLine("<div class='section'>");
            sb.AppendLine("<h2>About Me</h2>");
            sb.AppendLine("<p>" + model.PersonalInfo.AboutMe + "</p>");
            sb.AppendLine("</div>");

            // Skills
            sb.AppendLine("<div class='section'>");
            sb.AppendLine("<h2>Skills</h2>");
            foreach (var group in model.Skills.GroupBy(s => s.Category))
            {
                sb.AppendLine("<h3>" + group.Key + "</h3>");
                sb.AppendLine("<p>" + string.Join(", ", group.Select(s => s.Name)) + "</p>");
            }
            sb.AppendLine("</div>");

            // Projects
            sb.AppendLine("<div class='section'>");
            sb.AppendLine("<h2>Projects</h2>");
            foreach (var project in model.Projects)
            {
                sb.AppendLine("<div class='project'>");
                sb.AppendLine("<h3>" + project.Name + " (" + project.Year + ")</h3>");
                sb.AppendLine("<p><strong>Description:</strong> " + project.Description + "</p>");
                sb.AppendLine("<p><strong>Tech Stack:</strong> " + project.TechStack + "</p>");
                sb.AppendLine("<p><strong>GitHub:</strong> " + project.GitHubUrl + "</p>");
                sb.AppendLine("</div>");
            }
            sb.AppendLine("</div>");

            // Education
            sb.AppendLine("<div class='section'>");
            sb.AppendLine("<h2>Education</h2>");
            foreach (var edu in model.Education)
            {
                sb.AppendLine("<h3>" + edu.Degree + "</h3>");
                sb.AppendLine("<p>" + edu.Institution + " - " + edu.ExpectedGraduation + "</p>");
                if (!string.IsNullOrEmpty(edu.Modules))
                {
                    sb.AppendLine("<p><strong>Key Modules:</strong> " + edu.Modules + "</p>");
                }
            }
            sb.AppendLine("</div>");

            // Experience
            if (model.Experiences != null && model.Experiences.Any())
            {
                sb.AppendLine("<div class='section'>");
                sb.AppendLine("<h2>Work Experience</h2>");
                foreach (var exp in model.Experiences)
                {
                    sb.AppendLine("<h3>" + exp.Position + " - " + exp.Company + "</h3>");
                    sb.AppendLine("<p class='date'>" + exp.Duration + "</p>");
                    sb.AppendLine("<p>" + exp.Description + "</p>");
                }
                sb.AppendLine("</div>");
            }

            // Interests
            if (model.Interests != null && model.Interests.Any())
            {
                sb.AppendLine("<div class='section'>");
                sb.AppendLine("<h2>Interests</h2>");
                sb.AppendLine("<p>" + string.Join(" • ", model.Interests.Select(i => i.Icon + " " + i.Name)) + "</p>");
                sb.AppendLine("</div>");
            }

            sb.AppendLine("</body>");
            sb.AppendLine("</html>");

            return sb.ToString();
        }
    }
}