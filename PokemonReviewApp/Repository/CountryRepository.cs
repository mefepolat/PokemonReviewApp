using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext context;

        public CountryRepository(DataContext context)
        {
            this.context = context;
        }
        public bool CountryExists(int countryId)
        {
            return context.Countries.Any(c => c.Id == countryId);
        }

        public ICollection<Country> GetCountries()
        {
            return context.Countries.ToList();
        }

        public Country GetCountry(int countryId)
        {
            return context.Countries.Where(c => c.Id == countryId).FirstOrDefault();
        }

        public Country GetCountryByOwner(int ownerId)
        {
            return context.Owners.Where(o => o.Id == ownerId).Select(c => c.Country).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnersByCountryId(int countryId)
        {
            return context.Owners.Where(c => c.Country.Id == countryId).ToList();
        }
    }
}
