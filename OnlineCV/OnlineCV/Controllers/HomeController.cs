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
            // You would implement PDF generation here
            // For now, redirect back to home
            return RedirectToAction("Index");
        }
    }
}