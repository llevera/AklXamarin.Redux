using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Redux.Models;

namespace Redux.Store
{
    public class State
    {
        public ImmutableArray<Movie> Movies { get; }

        public State(ImmutableArray<Movie> movies)
        {
            Movies = movies;
        }
    }
}