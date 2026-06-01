using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Student
{
    public int StudentId { get; set; }

    public string StudentNo { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual ICollection<BorrowRecord> BorrowRecords { get; set; } = new List<BorrowRecord>();
}
