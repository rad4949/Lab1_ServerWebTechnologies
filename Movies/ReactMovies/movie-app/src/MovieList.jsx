import React, { useState, useEffect } from "react";
import MovieCard from "./MovieCard";
import axios from "axios";

const MovieList = () => {
  const [movies, setMovies] = useState([]);

  useEffect(() => {
    axios
      .get("https://localhost:7218/api/movies/popular")
      .then((response) => {
        console.log(response.data);
        setMovies(response.data);
      })
      .catch((error) => console.error("Error fetching data:", error));
  }, []);

  const mystyle = {
    display: "flex",
    flexWrap: "wrap",
    justifyContent: "center",
  };

  return (
    <div className="movie-list" style={mystyle}>
      {movies.map((movie) => (
        <MovieCard
          key={movie.id}
          poster_path={movie.poster_path}
          title={movie.title}
          overview={movie.overview}
        />
      ))}
    </div>
  );
};

export default MovieList;
