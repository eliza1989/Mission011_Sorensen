using System;
using System.Collections.Generic;

namespace Mission011_Sorensen.Models;

public partial class Book
{
    public required int BookId { get; set; }

    public required string Title { get; set; } 

    public required string Author { get; set; }

    public required string Publisher { get; set; }

    public required string Isbn { get; set; }

    public required string Classification { get; set; }

    public required string Category { get; set; }

    public required int PageCount { get; set; }

    public required double Price { get; set; }
}
