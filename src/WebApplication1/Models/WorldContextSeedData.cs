using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class WorldContextSeedData
    {
        private WorldContext _context;
        private UserManager<WorldUser> _userManager;

        public WorldContextSeedData(WorldContext context, UserManager<WorldUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task EnsureDataSeed()
        {
            if(await _userManager.FindByEmailAsync("adampap@hotmail.com")== null)
            {
                var user = new WorldUser()
                {
                    UserName = "Adampap111",
                    Email = "adampap@hotmail.com"
                };
               await _userManager.CreateAsync(user, "Pasw@r0ld!");
            }

            if (!_context.Trips.Any())
            {
                var usTrip = new Trip()
                {
                    DateCreated = DateTime.Now,
                    Name = "Ustrip",
                    UserName = "adampap",
                    Stops = new List<Stop>()
                    {
                        new Stop() {Name="Chicago", Arrival= new DateTime(2014,6,4),Latitude =33.121,Longitude= 21.31, Order=0 },
                         new Stop() {Name="New York", Arrival= new DateTime(2014,6,4),Latitude =33.121,Longitude= 21.31, Order=1 },
                          new Stop() {Name="Atlanta", Arrival= new DateTime(2014,6,4),Latitude =33.121,Longitude= 21.31, Order=2 }
                    }
                };
                _context.Trips.Add(usTrip);
                _context.Stops.AddRange(usTrip.Stops);

                var worldTrip = new Trip()
                {
                    DateCreated = DateTime.Now,
                    Name = "worldTrip",
                    UserName = "adampap",
                    Stops = new List<Stop>()
                    {
                        new Stop() {Name="Budapest", Arrival= new DateTime(2014,6,4),Latitude =33.121,Longitude= 21.31, Order=0 },
                         new Stop() {Name="Bangkok", Arrival= new DateTime(2014,6,4),Latitude =33.121,Longitude= 21.31, Order=1 },
                          new Stop() {Name="Bukarest", Arrival= new DateTime(2014,6,4),Latitude =33.121,Longitude= 21.31, Order=2 }
                    }
                };
                _context.Trips.Add(worldTrip);
                _context.Stops.AddRange(worldTrip.Stops);

                await _context.SaveChangesAsync();
            }
        }
    }
}
