using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext context;
        public ReviewRepository(DataContext context) { 
            this.context = context;
        }

        public bool CreateReview(Review review)
        {
            context.Add(review);
            return Save();
        }

        public Review GetReview(int reviewId)
        {
            return context.Reviews.Where(r => reviewId == r.Id).FirstOrDefault();
        }

        public ICollection<Review> GetReviews()
        {
            return context.Reviews.ToList();
        }

        public ICollection<Review> GetReviewsofAPokemon(int pokeId)
        {
            return context.Reviews.Where(r => r.Pokemon.Id == pokeId).ToList();
        }

        public bool ReviewExists(int reviewId)
        {
            return context.Reviews.Any(r => r.Id == reviewId);
        }

        public bool Save()
        {
            var saved = context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
