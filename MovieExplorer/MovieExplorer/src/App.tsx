import { Link, Route, Routes } from "react-router-dom";
import Home from "./pages/Home";
import MovieDetails from "./pages/MovieDetails";
import { MoviesContext } from "./contexts/MoviesContext";
import { useMovies } from "./hooks/useMovies";

function App() {
  const { movies, deleteMovie } = useMovies();

  return (
    <MoviesContext.Provider value={{ movies, deleteMovie }}>
      <nav>
        <Link to="/">Movie Explorer</Link>
      </nav>

      <Routes>
        <Route path="/" element={<Home />} />

        <Route path="/movies/:id" element={<MovieDetails />} />
      </Routes>
    </MoviesContext.Provider>
  );
}

export default App;
