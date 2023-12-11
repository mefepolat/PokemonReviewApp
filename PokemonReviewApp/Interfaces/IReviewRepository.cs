﻿using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        
        Review GetReview(int reviewId);

        ICollection<Review> GetReviewsofAPokemon(int pokeId);

        bool ReviewExists(int reviewId);
    }
}
