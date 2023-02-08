using System;
using System.Collections.Generic;

namespace MuseumDemoAPI.Models;

public partial class Account
{
    public int AccountId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }
}
