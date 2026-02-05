using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

[Table("DoctorInformation")] // Check table name? Assuming match or mapped in DbContext. Grep showed "DoctorInformations"? No, Grep 1948 showed file.
public partial class DoctorInformation : BaseEntity // Extends BaseEntity
{
    [Key]
    public long DoctorId { get; set; }

    public string? DoctorName { get; set; }

    public string? DoctorMobile { get; set; }

    public string? DoctorAdddress { get; set; }

    public string? DoctorDescription { get; set; }

    // UserId and SystemDate removed, using BaseEntity properties
}
