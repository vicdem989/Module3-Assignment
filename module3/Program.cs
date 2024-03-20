
namespace program;
using functions;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine(Books.AmountBooksBeforeOrAfterSpecificYear(2004, "before"));


        //List<Books.Book> booksWhereAuthorHasSpecificLetter = Books.FindBookWhereAuthorNameContainsLetter('t');
        //List<Books.Book> bookStartingWithSpecificWord= Books.FindBookStartingWith("The");
    }
}