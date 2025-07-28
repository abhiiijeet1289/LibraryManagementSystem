using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem.Tests
{
    [TestClass]
    public class LibraryTests
    {
        private Library _library;

        [TestInitialize]
        public void Setup()
        {
            _library = new Library();
        }

        [TestMethod]
        public void AddBook_ShouldAddBookToLibrary()
        {
            var book = new Book { Title = "Test Book", Author = "Author A", ISBN = "123" };
            _library.AddBook(book);

            Assert.AreEqual(1, _library.Books.Count);
            Assert.AreEqual("Test Book", _library.Books[0].Title);
        }

        [TestMethod]
        public void RegisterBorrower_ShouldAddBorrowerToLibrary()
        {
            var borrower = new Borrower { Name = "John", LibraryCardNumber = "ABC123" };
            _library.RegisterBorrower(borrower);

            Assert.AreEqual(1, _library.Borrowers.Count);
            Assert.AreEqual("John", _library.Borrowers[0].Name);
        }

        [TestMethod]
        public void BorrowBook_ShouldMarkBookAsBorrowed_AndAddToBorrower()
        {
            var book = new Book { Title = "Book A", Author = "Author A", ISBN = "ISBN001" };
            var borrower = new Borrower { Name = "Alice", LibraryCardNumber = "CARD01" };
            _library.AddBook(book);
            _library.RegisterBorrower(borrower);

            _library.BorrowBook("ISBN001", "CARD01");

            Assert.IsTrue(book.IsBorrowed);
            Assert.IsTrue(borrower.BorrowedBooks.Contains(book));
        }

        [TestMethod]
        public void ReturnBook_ShouldMarkBookAsAvailable_AndRemoveFromBorrower()
        {
            var book = new Book { Title = "Book A", Author = "Author A", ISBN = "ISBN001" };
            var borrower = new Borrower { Name = "Alice", LibraryCardNumber = "CARD01" };
            _library.AddBook(book);
            _library.RegisterBorrower(borrower);
            _library.BorrowBook("ISBN001", "CARD01");

            _library.ReturnBook("ISBN001", "CARD01");

            Assert.IsFalse(book.IsBorrowed);
            Assert.IsFalse(borrower.BorrowedBooks.Contains(book));
        }

        [TestMethod]
        public void ViewBooks_ShouldDisplayBookStatus()
        {
            var book1 = new Book { Title = "Book 1", Author = "Author 1", ISBN = "B1" };
            var book2 = new Book { Title = "Book 2", Author = "Author 2", ISBN = "B2" };
            _library.AddBook(book1);
            _library.AddBook(book2);
            _library.BorrowBook("B2", "CARD");

            // No assertion here because ViewBooks writes to console,
            // but you can refactor to return strings for easier testing.
        }

        [TestMethod]
        public void ViewBorrowers_ShouldDisplayBorrowerDetails()
        {
            var borrower = new Borrower { Name = "Sam", LibraryCardNumber = "LIB123" };
            var book = new Book { Title = "Book X", Author = "Author X", ISBN = "X1" };
            _library.AddBook(book);
            _library.RegisterBorrower(borrower);
            _library.BorrowBook("X1", "LIB123");

            // Same as above: refactor ViewBorrowers to return values for better testability
        }
    }
}
