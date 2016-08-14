using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public interface IWorldRepository
    {
        IEnumerable<Trip> GetAllTrips();
        Trip GetTripByName(string tripName, string Username);
        void AddTrip(Trip trip);
        void AddStop(string tripName,string username, Stop newStop);
        Task<bool> SaveChangesAsync();
        IEnumerable<Trip> GetUserTrips(string name);

    }
}
