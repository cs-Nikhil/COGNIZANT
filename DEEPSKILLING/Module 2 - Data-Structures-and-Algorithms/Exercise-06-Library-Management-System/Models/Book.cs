namespace DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise06LibraryManagementSystem.Models;

/// <summary>
/// Represents a book that can be searched in the library catalog.
/// </summary>
public class Book
{
    public int BookId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Author { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"ID: {BookId}, Title: {Title}, Author: {Author}";
    }
}
