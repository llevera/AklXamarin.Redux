﻿using System.Collections.Immutable;

namespace Redux.Props
{
    public class MoviesPageProps
    {
        public ImmutableArray<MovieProps> Movies;
        public ImmutableArray<GenreProps> Genres;

        public MoviesPageProps(
            ImmutableArray<MovieProps> movies,
            ImmutableArray<GenreProps> genreProps)
        {
            Movies = movies;
            Genres = genreProps;
        }

        public static MoviesPageProps Default = new MoviesPageProps(ImmutableArray<MovieProps>.Empty,
            ImmutableArray<GenreProps>.Empty);

    }
}