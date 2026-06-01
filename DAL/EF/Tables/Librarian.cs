using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Librarian
{
    public int LibrarianId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}
