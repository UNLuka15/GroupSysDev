using System;
using System.Collections.Generic;

namespace MuseumDemoAPI.Models;

public partial class RatingLevel
{
    public int RatingLevelId { get; set; }

    public string? Name { get; set; }

    public int? Rank { get; set; }
}
