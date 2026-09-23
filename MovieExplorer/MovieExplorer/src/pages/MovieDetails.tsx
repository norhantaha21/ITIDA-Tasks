import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { moviesData } from "../data/movies";
import type { Movie } from "../types/Movie";

function MovieDetails() {
  const { id } = useParams();
  const navigate = useNavigate();

  const [movie, setMovie] = useState<Movie | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState("");

  useEffect(() => {
    try {
      setLoading(true);
      setError("");

      const movieId = Number(id);

      const foundMovie = moviesData.find((movie) => movie.id === movieId);

      if (!foundMovie) {
        setError("Movie not found.");
        return;
      }

      setMovie(foundMovie);
    } catch {
      setError("Something went wrong while loading the movie.");
    } finally {
      setLoading(false);
    }
  }, [id]);

  if (loading) {
    return <h2 className="message">Loading...</h2>;
  }

  if (error) {
    return (
      <div className="message">
        <h2>{error}</h2>

        <button onClick={() => navigate("/")}>Back to Movies</button>
      </div>
    );
  }

  if (!movie) {
    return null;
  }

  return (
    <div className="details-container">
      <button className="back-btn" onClick={() => navigate("/")}>
        ← Back to Movies
      </button>

      <div className="details-card">
        <img src={movie.poster} alt={movie.title} />

        <div>
          <h1>{movie.title}</h1>

          <p>
            <strong>Genre:</strong> {movie.genre}
          </p>

          <p>
            <strong>Release Year:</strong> {movie.releaseYear}
          </p>

          <p>
            <strong>Rating:</strong> {movie.rating}
          </p>

          <p>
            <strong>Description:</strong>
          </p>

          <p>{movie.description}</p>
        </div>
      </div>
    </div>
  );
}

export default MovieDetails;
