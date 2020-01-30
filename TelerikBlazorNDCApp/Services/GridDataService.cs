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
                };
            }
        }
    }
}
