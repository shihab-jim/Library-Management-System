using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class BorrowRecord
{
    public int BorrowRecordId { get; set; }

    public int StudentId { get; set; }

    public int BookId { get; set; }

    public DateTime BorrowDate { get; set; }

    public DateTime DueDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public string Status { get; set; } = null!;

    public decimal FineAmount { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
