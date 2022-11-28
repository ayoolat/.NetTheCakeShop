using System;
using System.Collections.Generic;

namespace theCakeShop.DataLayer.Database;

public partial class Cake
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual Cart? Cart { get; set; }
}
