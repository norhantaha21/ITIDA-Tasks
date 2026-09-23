import { Link } from "react-router-dom";
import { memo, useContext } from "react";
import type { Movie } from "../types/Movie";
import { MoviesContext } from "../contexts/MoviesContext";

interface MovieCardProps {
  movie: Movie;
}

function MovieCard({ movie }: MovieCardProps) {
  const context = useContext(MoviesContext);

  if (!context) {
    throw new Error();
  }
  const { deleteMovie } = context;

  return (
    <div className="movie-card">
      <img src={movie.poster} alt={movie.title} />

      <div className="movie-info">
        <h2>{movie.title}</h2>

        <p>Genre: {movie.genre}</p>

        <p>Year: {movie.releaseYear}</p>

        <p>⭐ {movie.rating}</p>

        <div className="buttons">
          <Link to={`/movies/${movie.id}`} className="details-btn">
            View Details
          </Link>

          <button className="delete-btn" onClick={() => deleteMovie(movie.id)}>
            Delete
          </button>
        </div>
      </div>
    </div>
  );
}

export default memo(MovieCard);
