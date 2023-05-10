using System;
using System.Collections.Generic;

namespace animeAPI.Models;

public partial class RottenTomatoesRating
{
    public int? Rating { get; set; }
    public object Id { get; internal set; }
}
