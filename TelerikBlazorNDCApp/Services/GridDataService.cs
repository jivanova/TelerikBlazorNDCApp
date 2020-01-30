using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TelerikBlazorNDCApp.Models;

namespace TelerikBlazorNDCApp.Services
{
    public class GridDataService
    {
        public static string[] LectureTitles = new[]
        {
            "Keynote: We are the Guardians of our Future", "SignalR Deep Dive: Building Servers", "Securing Serverless Applications in Azure", "Capability Mapping", "Serverless: Five Key Things you need to Know", "Empowering Soft Skills with Team Dynamics/Communication Skills (Software/Engineering Team/Projects)", "Workshop: Better, cleaner React with hooks: Part 1/2 ", "Make your custom .NET GC", "OpenID Connect & OAuth 2.0 – Security Best Practices", "Controlling Wildfires While Only Getting Singed.", "Shor's Algorithm is Scary NOW", "Delightful Durable Function Patterns", "Workshop: Better, cleaner React with hooks. Part 2/2", "Lightning Talks", "Application Diagnostics in .NET Core 3.1", "EVE Online: Defending our players from hackers and the evolution of account security", "Cynicism Doesn’t Build Products", "How To Secure Your MicroServices", "An introduction to Machine Learning using LEGO", "Workshop: Event-driven microservices: making sure each messages is processed exactly once. Part 1/2", "The OWASP Top Ten Proactive Controls 2018", "There are no snow days when you work remote.", "A Developer’s Introduction to Kubernetes", "Modernizing the enterprise desktop application", "Frontend in F#? Hold my beer!", "Workshop: Event-driven microservices: making sure each messages is processed exactly once. Part 2/2", "Rip It Up And Start Again?", "What you always wanted to know about Deep Learning, but were afraid to ask", "From WCF to gRPC", "Frictionless Frontends for Backend Developers", "Micro Frontends – a strive for fully verticalized systems", "Workshop: A Deep Dive in to Machine Learning in .NET. Part 1/2", "Blazor, a new framework for browser-based .NET apps", "How to Steal an Election", "There’s an Imposter in this room!", "A Developer's Introduction to Electronics", "Can TypeScript really make infrastructure management easy?", "Workshop: A Deep Dive in to Machine Learning in .NET. Part 2/2", "The Internet of Pwned Things", "From the OWASP Top Ten(s) to the OWASP ASVS", "The State of Vue.js in 2020 - Why You Should Make The Leap", "Predictive Maintenance - How Does Data Science Revolutionize the World of Machines?", "3D printed Bionic Hand a little IOT and a Xamarin Mobile App", "Workshop: Building an educational game with .NET Core and Unity3D. Part 1/2", "Machine Learning for .NET developers", "Blazor in more depth", "Introduction to GitHub Actions", "Angular and The Case for RxJS", "Building a real-time serverless app in Blazor using AWS", "Workshop: Building an educational game with .NET Core and Unity3D. Part 2/2", "Everything is Cyber-broken 2", "Keep it Clean: Why Bad Data Ruins Projects and How to Fix it", "Wait, I have to test the front end too?", "Real World Guide to Web API authentication on Azure", "How to hire great engineers", "Lightning Talks", "Beyond REST with GraphQL in .Net core", "Best practices for securing CI/CD pipeline", "Solving Tricky Coordination Problems in Stateless .NET Services", "Ordering the chaos - cleaning logs and ordering events in microservices", "How does designing your culture help your code?", "Workshop: gRPC with ASP.NET Core Workshop. Part 1/2", "Why Kubernetes is Not Enough", "25 Years of SSL - Secure(ish) Sockets Layer", "Svelte, cybernetically enhanced web apps", "Sprinkle some sparkle on it: Teaching Xamarin with Selfies", "Serverless containers with Knative and Cloud Run", "Workshop: gRPC with ASP.NET Core Workshop. Part 2/2", "DDD Really Matters!", "Turbocharged: Writing High-Performance C# and .NET Code", "Effective Microservice Communication and Conversation Patterns", "Challenges of Managing CoreFX repo", "Anatomy of a DDoS", "Change your habits: Modern techniques for modern C#", "Shrink The Web: How To Get Happier By Removing Crap", "How to code music?", "Alexa, ask Cortana to tell Google to...", "Single Page Architectures with VueJS and ASP.NET Core", "NDC Party + .NET Rocks Live Panel", "Building Trust in Teams", "Crash, bang, wallop: miscellaneous lessons from exploring a drum kit", "ML and the IoT: Living on the Edge", "The Perimeter Has Been Shattered: Attacking and Defending Mobility and IoT on the Enterprise Network", "Modernizing Large Frontends with Web Components", "Workshop: Learning Feedback with LEGO: The Buildin…Blocks of Giving and Receiving Feedback. Part 1/2", "Navigating microservices with .NET Core", "The Rise of Klintwalker – Mastering Your Inner Developer Part 2", "Common API Security Pitfalls", "Getting the best out of Entity Framework Core", "Deep Dive on Server-Side Blazor", "Workshop: Learning Feedback with LEGO: The Buildin…Blocks of Giving and Receiving Feedback. Part 2/2", "Drinking a river of IoT data with Akka.NET", "UX Design Fundamentals: What do your users really see", "Breaking black-box AI", "Big Data Analytics in Near-Real-Time with Apache Kafka Streams", "Fighting Back Against a Distracted World - Increasing your Focus and Self-motivation", "Workshop: Build your first real-world Svelte app. Part 1/2", "Lightning Talks", "Reinventing the Transaction Script", "Continuous Integration and Delivery for Databases"
        };

        private static readonly int ItemsCount = 200000;

        private static readonly List<string> CompanyNames = new List<string> { "Bottom-Dollar Markets", "FISSA Fabrica Inter. Salchichas S.A.", "Hanari Carnes", "LILA-Supermercado", "Que Delícia", "QUICK-Stop", "Romero y tomillo", "Suprêmes délices", "Vins et alcools Chevalier", "Wartian Herkku", "Folies gourmandes", "Ricardo Adocicados", "Rattlesnake Canyon Grocery", "Familia Arquibaldo", "Laughing Bacchus Wine Cellars", "Mère Paillarde", "Morgenstern Gesundkost", "Queen Cozinha", "The Cracker Box", "Blondel père et fils", "Centro comercial Moctezuma", "Frankenversand", "France restauration", "Galería del gastrónomo", "Great Lakes Food Market" };
        private static readonly List<string> ContactNames = new List<string> { "Elizabeth Lincoln", "Diego Roel", "Mario Pontes", "Carlos González", "Bernardo Batista", "Horst Kloss", "Alejandra Camino", "Pascale Cartrain", "Paul Henriot", "Pirkko Koskitalo", "Martine Rancé", "Janete Limeira", "Paula Wilson", "Aria Cruz", "Yoshi Tannamuri", "Jean Fresnière", "Alexander Feuer", "Lúcia Carvalho", "Liu Wong", "Frédérique Citeaux", "Francisco Chang", "Peter Franken", "Carine Schmitt", "Eduardo Saavedra", "Howard Snyder" };
        private static readonly List<string> ContactTitles = new List<string> { "Software Developer", "Front-end Developer", "Partner", "Manager", "Software Developer", "Front-end Developer", "Partner", "Manager", "Software Developer", "Front-end Developer", "Partner", "Manager", "Software Developer", "Front-end Developer", "Partner", "Manager", "Software Developer", "Front-end Developer", "Partner", "Manager", "Software Developer", "Front-end Developer", "Partner", "Manager", "Software Developer" };
        private static readonly List<string> Addresses = new List<string> { "23 Tsawassen Blvd.", "C/ Moralzarzal, 86", "Rua do Paço, 67", "Carrera 52 con Ave. Bolívar #65-98 Llano Largo", "Rua da Panificadora, 12", "Taucherstraße 10", "Gran Vía, 1", "Boulevard Tirou, 255", "59 rue de l'Abbaye", "Torikatu 38", "184, chaussée de Tournai", "Av. Copacabana, 267", "2817 Milton Dr.", "Rua Orós, 92", "1900 Oak St.", "43 rue St. Laurent", "Heerstr. 22", "Alameda dos Canàrios, 891", "55 Grizzly Peak Rd.", "24, place Kléber", "Sierras de Granada 9993", "Berliner Platz 43", "54, rue Royale", "Rambla de Cataluña, 23", "2732 Baker Blvd." };
        private static readonly List<string> Cities = new List<string> { "Tsawassen", "Madrid", "Rio de Janeiro", "Barquisimeto", "Rio de Janeiro", "Cunewalde", "Madrid", "Charleroi", "Reims", "Oulu", "Lille", "Rio de Janeiro", "Albuquerque", "São Paulo", "Vancouver", "Montréal", "Leipzig", "São Paulo", "Butte", "Strasbourg", "México D.F.", "München", "Nantes", "Barcelona", "Eugene" };
        private static readonly List<string> Countries = new List<string> { "Canada", "Spain", "Brazil", "Venezuela", "Brazil", "Germany", "Spain", "Belgium", "France", "Finland", "France", "Brazil", "USA", "Brazil", "Canada", "Canada", "Germany", "Brazil", "USA", "France", "Mexico", "Germany", "France", "Spain", "USA" };
        private static readonly List<string> Phones = new List<string> { "(604) 555-4729", "(91) 555 94 44", "(21) 555-0091", "(9) 331-6954", "(21) 555-4252", "0372-035188", "(91) 745 6200", "(071) 23 67 22 20", "26.47.15.10", "981-443655", "20.16.10.16", "(21) 555-3412", "(505) 555-5939", "(11) 555-9857", "(604) 555-3392", "(514) 555-8054", "0342-023176", "(11) 555-1189", "(406) 555-5834", "88.60.15.31", "(5) 555-3392", "089-0877310", "40.32.21.21", "(93) 203 4560", "(503) 555-7555" };

        public async Task<List<Attendee>> GetAttendeesAsync()
        {
            Debug.Assert(CompanyNames.Count == ContactNames.Count);
            Debug.Assert(ContactNames.Count == ContactTitles.Count);
            Debug.Assert(ContactTitles.Count == Addresses.Count);
            Debug.Assert(Addresses.Count == Cities.Count);
            Debug.Assert(Cities.Count == Countries.Count);
            Debug.Assert(Countries.Count == Phones.Count);

            return await Task.FromResult(GetAttendees(ItemsCount).ToList());
        }

        public IEnumerable<Attendee> GetAttendees(int count)
        {
            Random rnd = new Random();
            for (int i = 0; i < count; i++)
            {
                int index = rnd.Next(0, CompanyNames.Count);

                yield return new Attendee
                {
                    Id = i,
                    Address = Addresses[index],
                    City = Cities[index],
                    CompanyName = CompanyNames[index],
                    ContactName = ContactNames[index],
                    ContactTitle = ContactTitles[index],
                    Country = Countries[index],
                    Phone = Phones[index],
                    Lectures = GenerateRandomLectures()
                };
            }
        }

        public List<Lecture> GenerateRandomLectures()
        {
            return Enumerable.Range(1, 8).Select(index => GenerateLecture()).ToList();
        }

        public Lecture GenerateLecture()
        {
            var rng = new Random();
            var baseDate = new DateTime(2020, 1, 30, 8, 0, 0);
            var startDate = baseDate.AddHours(rng.Next(0, 12));

            return new Lecture()
            {
                Title = LectureTitles[rng.Next(LectureTitles.Length)],
                Start = startDate,
                End = startDate.AddHours(1),
                IsAllDay = false
            };
        }
    }
}
