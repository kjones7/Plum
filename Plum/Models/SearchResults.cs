﻿using System.Collections.Generic;
using Plum.Dtos;

namespace Plum.Models
{
    public class SearchResults
    {
        public IList<LibraryDto> Libraries { get; }
        public IList<VideoDto> Videos { get; }

        public int TotalCount => Libraries.Count + Videos.Count;

        public SearchResults(IList<LibraryDto> libraries, IList<VideoDto> videos)
        {
            Libraries = libraries;
            Videos = videos;
        }
    }
}
