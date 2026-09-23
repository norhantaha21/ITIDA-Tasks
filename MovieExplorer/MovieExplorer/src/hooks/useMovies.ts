import { useCallback, useState } from "react";
import type { Movie } from "../types/Movie";
import { moviesData } from "../data/movies";

export function useMovies() {
  const [movies, setMovies] = useState<Movie[]>(moviesData);

  const deleteMovie = useCallback((id: number) => {
    setMovies((currentMovies) =>
      currentMovies.filter((movie) => movie.id !== id),
    );
  }, []);

  return {
    movies,
    deleteMovie,
  };
}