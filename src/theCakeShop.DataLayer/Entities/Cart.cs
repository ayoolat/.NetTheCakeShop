using System;
using System.Collections.Generic;

namespace theCakeShop.DataLayer.Database;

public partial class Cart
{
    public int Id { get; set; }

    public int UserProfileId { get; set; }

    public int CakeId { get; set; }

    public bool? Paid { get; set; }

    public bool? Delivered { get; set; }

    public virtual User Id1 { get; set; } = null!;

    public virtual Cake IdNavigation { get; set; } = null!;
}
