import type { Movie } from "../types/Movie";

export const moviesData: Movie[] = [
  {
    id: 1,
    title: "Inception",
    genre: "Sci-Fi",
    description:
      "A thief who steals corporate secrets through dream-sharing technology is given the task of planting an idea into someone's mind.",
    poster: "https://image.tmdb.org/t/p/w500/oYuLEt3zVCKq57qu2F8dT7NIa6f.jpg",
    releaseYear: 2010,
    rating: 8.8,
  },

  {
    id: 2,
    title: "The Dark Knight",
    genre: "Action",
    description:
      "Batman faces a criminal mastermind who plunges Gotham City into chaos.",
    poster: "https://image.tmdb.org/t/p/w500/qJ2tW6WMUDux911r6m7haRef0WH.jpg",
    releaseYear: 2008,
    rating: 9.0,
  },

  {
    id: 3,
    title: "Interstellar",
    genre: "Sci-Fi",
    description:
      "A group of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.",
    poster: "https://image.tmdb.org/t/p/w500/gEU2QniE6E77NI6lCU6MxlNBvIx.jpg",
    releaseYear: 2014,
    rating: 8.7,
  },

  {
    id: 4,
    title: "The Hangover",
    genre: "Comedy",
    description:
      "Three friends wake up after a wild bachelor party with no memory of what happened.",
    poster: "https://image.tmdb.org/t/p/w500/uluhlXubGu1VxU63X9VHCLWDAYP.jpg",
    releaseYear: 2009,
    rating: 7.7,
  },

  {
    id: 5,
    title: "Titanic",
    genre: "Romance",
    description:
      "A young couple from different social backgrounds fall in love aboard the Titanic.",
    poster: "https://image.tmdb.org/t/p/w500/9xjZS2rlVxm8SFx8kPC3aIGCOYQ.jpg",
    releaseYear: 1997,
    rating: 7.9,
  },
];
