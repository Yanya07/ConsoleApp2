using System;
using System.Collections.Generic;
using System.Linq;

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }

    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
    }
}

class Library
{
    private List<Book> books = new List<Book>();

    public void AddBook(Book book)// Метод для добавления книги
    {
        books.Add(book);
        Console.WriteLine($"Книга '{book.Title}' добавлена в библиотеку.");
    }

    public void RemoveBook(string title)// Метод для удаления книги
    {
        Book bookToRemove = books.FirstOrDefault(b => b.Title == title);
        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
            Console.WriteLine($"Книга '{title}' удалена из библиотеки.");
        }
        else
        {
            Console.WriteLine($"Книга '{title}' не найдена.");
        }
    }

    public List<Book> SearchByAuthor(string author)// Метод для поиска книги по автору
    {
        return books.Where(b => b.Author.Equals(author, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public void SortByYear()// Метод для сортировки книг по году издания
    {
        books = books.OrderBy(b => b.Year).ToList();
        Console.WriteLine("Книги отсортированы по году издания.");
    }

    public void DisplayBooks()// Метод для отображения всех книг
    {
        Console.WriteLine("Книги в библиотеке:");
        foreach (var book in books)
        {
            Console.WriteLine($"- {book.Title} (Автор: {book.Author}, Год: {book.Year})");
        }
    }
}

class Program
{
    static void Main()
    {
        Library library = new Library();

        // Добавляем книги
        library.AddBook(new Book("Война и мир", "Лев Толстой", 1869));
        library.AddBook(new Book("1984", "Джордж Оруэлл", 1949));
        library.AddBook(new Book("Преступление и наказание", "Федор Достоевский", 1866));

        library.DisplayBooks();// Отображаем все книги

        var foundBooks = library.SearchByAuthor("Лев Толстой");// Ищем книги по автору
        Console.WriteLine("Найденные книги:");
        foreach (var book in foundBooks)
        {
            Console.WriteLine($"- {book.Title}");
        }

        library.RemoveBook("1984");// Удаляем книгу
        library.SortByYear();// Сортируем книги по году
        library.DisplayBooks();// Отображаем оставшиеся книги
        Console.ReadLine();
    }
}
