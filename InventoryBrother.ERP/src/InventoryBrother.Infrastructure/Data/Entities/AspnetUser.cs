using System;
using System.Collections.Generic;

namespace InventoryBrother.Infrastructure.Data.Entities;

public partial class AspnetUser
{
    public Guid ApplicationId { get; set; }

    public Guid UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string LoweredUserName { get; set; } = null!;

    public string? MobileAlias { get; set; }

    public bool IsAnonymous { get; set; }

    public DateTime LastActivityDate { get; set; }

    public string? RegistrationNumber { get; set; }

    public string? FullName { get; set; }

    public int? StoreId { get; set; }

    public virtual AspnetApplication Application { get; set; } = null!;

    public virtual AspnetMembership? AspnetMembership { get; set; }

    public virtual ICollection<AspnetPersonalizationPerUser> AspnetPersonalizationPerUsers { get; set; } = new List<AspnetPersonalizationPerUser>();

    public virtual AspnetProfile? AspnetProfile { get; set; }

    public virtual ICollection<AspnetRole> Roles { get; set; } = new List<AspnetRole>();
}
