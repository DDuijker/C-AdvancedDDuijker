namespace AirBnB.Services
{
    using AirBnB.Models;
    using Microsoft.EntityFrameworkCore;

    public class SearchService
    {
        private readonly AirBnBContext _context;

        public SearchService(AirBnBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Location>> SearchLocations(string searchQuery, int Rooms, int PricePerDay, string locationType)
        {
            var locations = await _context.Locations
                .Where(l => l.Title.Contains(searchQuery) || l.SubTitle.Contains(searchQuery))
                .ToListAsync();

            return locations;
        }
    }
}
