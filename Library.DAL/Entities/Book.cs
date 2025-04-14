using System;
using System.Collections.Generic;

namespace Library.DAL.Entities;

public partial class Book
{
    public int BookId { get; set; }

    public string? BookName { get; set; }

    public DateTime? Date { get; set; }

    public int? AuthorId { get; set; }

    public string? Description { get; set; }

    public int? GenreId { get; set; }

    public string? Content { get; set; }

    public string? Image { get; set; }

    public virtual Author? Author { get; set; }

    public virtual Genre? Genre { get; set; }
}
