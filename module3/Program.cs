
namespace program;

using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using System.Text;
using functions;

class Program
{
    static void Main(string[] args)
    {
        List<Books.Book> thingy = Books.ListBooks("descending");
        foreach (Books.Book book in thingy)
        {
            Console.WriteLine(book.title);
        }        

       //Console.WriteLine(LeftAndRight.GetAmountNodesInStructure());


        //Console.WriteLine(Books.AmountBooksBeforeOrAfterSpecificYear(2004, "before"));


        //List<Books.Book> booksWhereAuthorHasSpecificLetter = Books.FindBookWhereAuthorNameContainsLetter('t');
        //List<Books.Book> bookStartingWithSpecificWord= Books.FindBookStartingWith("The");
        //List<string> booksISBNFromGivenAuthor= Books.GetBooksFromGivenAuthor("Richard Kadrey");
        //List<Books.Book> listBooks = Books.ListBooks("ascending");
    
        /*foreach(int number in  FlattenTheNumbers.Flatten()) {
            Console.WriteLine(number);
        }*/
        /*int[] flattenedArray = FlattenTheNumbers.Flatten();
        Console.WriteLine("Flattened array:");
        foreach(int num in flattenedArray) {
            Console.Write(um+ ", ");
        }n
*/

    }
}