using System;
using System.Collections.Generic;

namespace RevFIT.Context.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public byte[] PassworkEcyp { get; set; } = null!;

    public byte[]? SaltEcyp { get; set; }

    public DateTime DateCreated { get; set; }
}
