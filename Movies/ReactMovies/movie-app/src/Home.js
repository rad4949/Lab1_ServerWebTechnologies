import React from "react";
import MovieList from "./MovieList";

function Home() {
  return (
    <div className="main" style={{ textAlign: "center" }}>
      <h1>Popular Movies</h1>
      <MovieList />
    </div>
  );
}

export default Home;
