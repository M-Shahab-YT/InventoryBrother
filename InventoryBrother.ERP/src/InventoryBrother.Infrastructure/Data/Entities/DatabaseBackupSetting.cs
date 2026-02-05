using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InventoryBrother.Domain.Common;

namespace InventoryBrother.Infrastructure.Data.Entities;

[Table("ImisTblDatabaseBackupAndRestoreSetting")]
public partial class DatabaseBackupSetting : BaseEntity
{
    [Key]
    public int Sno { get; set; }

    public string? BackupPath { get; set; }

    public bool? AutoBackup { get; set; }
}
