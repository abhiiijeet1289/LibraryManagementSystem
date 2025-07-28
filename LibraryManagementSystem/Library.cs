using System;
using System.Collections.Generic;
using System.Linq;


public class Library
{
    public List<Book> Books { get; private set; } = new List<Book>();
    public List<Borrower> Borrowers { get; private set; } = new List<Borrower>();

    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    public void RegisterBorrower(Borrower borrower)
    {
        Borrowers.Add(borrower);
    }

    public void BorrowBook(string isbn, string libraryCardNumber)
    {
        var book = Books.FirstOrDefault(b => b.ISBN == isbn && !b.IsBorrowed);
        var borrower = Borrowers.FirstOrDefault(b => b.LibraryCardNumber == libraryCardNumber);
        if (book != null && borrower != null)
        {
            borrower.BorrowBook(book);
        }
    }

    public void ReturnBook(string isbn, string libraryCardNumber)
    {
        var book = Books.FirstOrDefault(b => b.ISBN == isbn);
        var borrower = Borrowers.FirstOrDefault(b => b.LibraryCardNumber == libraryCardNumber);
        if (book != null && borrower != null)
        {
            borrower.ReturnBook(book);
        }
    }

    public void ViewBooks()
    {
        foreach (var book in Books)
        {
            Console.WriteLine($"{book.Title} by {book.Author} (ISBN: {book.ISBN}) - {(book.IsBorrowed ? "Borrowed" : "Available")}");
        }
    }

    public void ViewBorrowers()
    {
        foreach (var borrower in Borrowers)
        {
            Console.WriteLine($"{borrower.Name} (Card: {borrower.LibraryCardNumber}) - Borrowed: {string.Join(", ", borrower.BorrowedBooks.Select(b => b.Title))}");
        }
    }
}
