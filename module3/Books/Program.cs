
using System.Security.Cryptography;
using booksFunctions;

namespace booksProgram;
class booksProgram
{
    static void Main(string[] args)
    {
        List<Books.Book> BooksStartingWith = Books.FindBookStartingWith("The");
        foreach(Books.Book book in BooksStartingWith) {
            //Console.WriteLine(book.title);
        }

        List<Books.Book> BooksWrittenByAuthor = Books.FindBookWhereAuthorNameContainsLetter('t');
        foreach(Books.Book book in BooksWrittenByAuthor) {
            //Console.WriteLine(book.author + " and " + book.title);
        }

        Console.WriteLine("There are " + Books.AmountBooksBeforeOrAfterSpecificYear(1992, "after") + " written after 1992");

        Console.WriteLine("There are " + Books.AmountBooksBeforeOrAfterSpecificYear(2004, "before") + "written before 2004");

        List<string> ISBNForAGivenAuthor = Books.GetBooksFromGivenAuthor("Terry Pratchett");
        foreach(string isbn in ISBNForAGivenAuthor) {
            //Console.WriteLine("ISBN: " + isbn);
        }

        List<Books.Book> AscendingOrderAlphabethically = Books.SortAlphabetically("ascending");
        foreach(Books.Book books in AscendingOrderAlphabethically) {
            //Console.WriteLine(books.title);
        }

        List<Books.Book> DescendingOrderAlphabethically = Books.SortAlphabetically("descending");
        foreach(Books.Book books in AscendingOrderAlphabethically) {
            //Console.WriteLine(books.title);
        }

        List<Books.Book> YearAssending = Books.SortYear("ascending");
        foreach(Books.Book books in YearAssending) {
            //Console.WriteLine(books);
        }

        List<Books.Book> YearDessending = Books.SortYear("descending");
        foreach(Books.Book books in YearDessending) {
            Console.WriteLine(books.title);
        }

        
    }

}