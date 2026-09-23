import { useContext, useState } from "react";
import MovieCard from "../components/MovieCard";
import { MoviesContext } from "../contexts/MoviesContext";

function Home() {
  const context = useContext(MoviesContext);

  if (!context) {
    throw new Error();
  }
  const { movies } = context;

  const [search, setSearch] = useState("");
  const [genre, setGenre] = useState("All");

  const genres = ["All", ...new Set(movies.map((movie) => movie.genre))];

  const filteredMovies = movies.filter((movie) => {
    const matchesSearch = movie.title
      .toLowerCase()
      .includes(search.toLowerCase());

    const matchesGenre = genre === "All" || movie.genre === genre;

    return matchesSearch && matchesGenre;
  });

  return (
    <div className="container">
      <h1>🎬 Movie Explorer</h1>

      <div className="filters">
        <input
          type="text"
          placeholder="Search movie..."
          value={search}
          onChange={(e) => setSearch(e.target.value)}
        />

        <select value={genre} onChange={(e) => setGenre(e.target.value)}>
          {genres.map((genreName) => (
            <option key={genreName} value={genreName}>
              {genreName}
            </option>
          ))}
        </select>
      </div>

      <div className="movies-grid">
        {filteredMovies.length > 0 ? (
          filteredMovies.map((movie) => (
            <MovieCard key={movie.id} movie={movie} />
          ))
        ) : (
          <p>No movies found.</p>
        )}
      </div>
    </div>
  );
}

export default Home;
