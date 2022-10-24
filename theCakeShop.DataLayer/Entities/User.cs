using System;
using System.Collections.Generic;

namespace theCakeShop.DataLayer.Database;

public partial class User
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? UserId { get; set; }

    public virtual Cart? Cart { get; set; }
}
