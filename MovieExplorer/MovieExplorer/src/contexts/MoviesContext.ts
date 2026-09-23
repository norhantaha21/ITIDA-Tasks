import { createContext } from "react";
import type { Movie } from "../types/Movie";

type MoviesContextType = {
  movies: Movie[];
  deleteMovie: (id: number) => void;
};

export const MoviesContext = createContext<MoviesContextType | null>(null);
