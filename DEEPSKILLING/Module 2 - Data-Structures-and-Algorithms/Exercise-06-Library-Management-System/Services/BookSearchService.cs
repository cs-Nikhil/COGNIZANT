using DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise06LibraryManagementSystem.Models;

namespace DeepSkilling.Module1.DataStructuresAndAlgorithms.Exercise06LibraryManagementSystem.Services;

/// <summary>
/// Provides linear and binary search operations for books by title.
/// </summary>
public class BookSearchService
{
    private readonly Book[] _linearSearchBooks;
    private readonly Book[] _binarySearchBooks;

    public BookSearchService()
    {
        _linearSearchBooks = new[]
        {
            new Book { BookId = 301, Title = "The Alchemist", Author = "Paulo Coelho" },
            new Book { BookId = 302, Title = "Clean Code", Author = "Robert C. Martin" },
            new Book { BookId = 303, Title = "Atomic Habits", Author = "James Clear" },
            new Book { BookId = 304, Title = "The Pragmatic Programmer", Author = "Andrew Hunt" },
            new Book { BookId = 305, Title = "Design Patterns", Author = "Erich Gamma" }
        };

        _binarySearchBooks = _linearSearchBooks
            .OrderBy(book => book.Title, StringComparer.OrdinalIgnoreCase)
            .ToArray();
    }

    public IReadOnlyList<Book> GetAllBooks()
    {
        return _binarySearchBooks;
    }

    public Book? LinearSearchByTitle(string title)
    {
        for (int index = 0; index < _linearSearchBooks.Length; index++)
        {
            Book currentBook = _linearSearchBooks[index];

            if (string.Equals(currentBook.Title, title, StringComparison.OrdinalIgnoreCase))
            {
                return currentBook;
            }
        }

        return null;
    }

    public Book? BinarySearchByTitle(string title)
    {
        int left = 0;
        int right = _binarySearchBooks.Length - 1;

        while (left <= right)
        {
            int middle = left + (right - left) / 2;
            Book currentBook = _binarySearchBooks[middle];
            int comparison = string.Compare(currentBook.Title, title, StringComparison.OrdinalIgnoreCase);

            if (comparison == 0)
            {
                return currentBook;
            }

            if (comparison < 0)
            {
                left = middle + 1;
            }
            else
            {
                right = middle - 1;
            }
        }

        return null;
    }
}
