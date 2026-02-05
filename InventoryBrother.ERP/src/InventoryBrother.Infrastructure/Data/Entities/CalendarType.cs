using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

[Table("LookupTblCalendarType")]
public partial class CalendarType : BaseEntity
{
    [Key]
    public int CalendarId { get; set; }

    public string? CalendarName { get; set; }
}
