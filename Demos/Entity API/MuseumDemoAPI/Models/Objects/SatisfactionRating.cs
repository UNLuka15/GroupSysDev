using System;
using System.Collections.Generic;

namespace MuseumDemoAPI.Models;

public partial class SatisfactionRating
{
    public int RatingId { get; set; }

    public int? ExhibitId { get; set; }

    public int? RatingLevelId { get; set; }
}
