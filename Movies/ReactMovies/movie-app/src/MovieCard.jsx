import React, { useState } from "react";
import styles from "./MovieCard.module.css"; // Підключення CSS-модуля

function MovieCard(props) {
  const [expanded, setExpanded] = useState(false);

  return (
    <div
      className={`${styles.movieCard} ${expanded ? styles.expanded : ""}`}
      onMouseEnter={() => setExpanded(true)}
      onMouseLeave={() => setExpanded(false)}
    >
      <img
        className={styles.movieImage}
        src={`https://image.tmdb.org/t/p/w500/${props.poster_path}`}
        alt={props.title}
      />
      <div className={styles.movieInfo}>
        <p
          className={`${styles.movieOverview} ${
            expanded ? styles.expandedOverview : ""
          }`}
        >
          {props.overview}
        </p>
        <h2 className={styles.movieTitle}>{props.title}</h2>
      </div>
    </div>
  );
}

export default MovieCard;
