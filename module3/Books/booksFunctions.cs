using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;

namespace booksFunctions;

public class Books {
        public static List<Book> books = new List<Book>();

        public class Book
            {
                public string title { get; set; }
                public int publication_year { get; set; }
                public string author { get; set; }
                public string isbn { get; set; }
            }
        public static void ReadJSONFile() {
            
            try
            {
                string filePath = "books.json";

                string jsonString = File.ReadAllText(filePath);
                books = JsonSerializer.Deserialize<List<Book>>(jsonString);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
            }
            catch (JSException)
            {
                Console.WriteLine("Invalid JSON format.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public static void OutputStuffInFile() {
            ReadJSONFile();
            if(books.Count <= 0) {
                Console.WriteLine("There are no books in the library!");
            }
             foreach (Book book in books) {
                Console.WriteLine($"Title: {book.title}");
                Console.WriteLine($"Publication year: {book.publication_year}");
                Console.WriteLine($"Author: {book.author}");
                Console.WriteLine($"ISBN {book.isbn}");
                Console.WriteLine(); 
            }
        }

        public static List<Book> FindBookStartingWith(string bookName) {
            ReadJSONFile();
            List<Book> desiredBooks = new List<Book>();
            foreach (Book book in books) {
                if(book.title.Contains(bookName)) { 
                    string[] arrayOfWordsInBookTitle = book.title.Split(' ');
                    if(arrayOfWordsInBookTitle[0] == bookName) {
                        desiredBooks.Add(book);
                    }
                }
            }
            return desiredBooks;
        }

        public static List<Book> FindBookWhereAuthorNameContainsLetter(char specificChar) {
            ReadJSONFile();
            List<Book> desiredBooks = new List<Book>();
            foreach (Book book in books) {
                if(book.author.Contains(specificChar)) { 
                    desiredBooks.Add(book);
                }
            }
            return desiredBooks;
        }

        public static int AmountBooksBeforeOrAfterSpecificYear(int year, string beforeOrAfter) {
            ReadJSONFile();
            int amountBooks = 0;
            beforeOrAfter.ToLower();
            foreach(Book book in books) {
                if(book.publication_year > year && beforeOrAfter == "after") {
                    amountBooks++;
                } else if(book.publication_year < year && beforeOrAfter == "before") {
                    amountBooks++;
                }
            }
            return amountBooks;
        }

        public static List<string> GetBooksFromGivenAuthor(string author) {
            ReadJSONFile();
            List<string> isbnFromAuthor = new List<string>();
            foreach(Book book in books) {
                if(book.author == author) {
                    isbnFromAuthor.Add(book.isbn);
                }
            }            
            return isbnFromAuthor;
        }

        public static List<Book> SortAlphabetically(string order) {

            ReadJSONFile();
            SortAlphabetically(books, order);
            
            foreach (var book in books) {
                    Console.WriteLine(book.title);
            }

            return books;
        }

        public static List<Book> SortYear(string order) {

            ReadJSONFile();
            SortByYear(books, order);
            
            foreach (var book in books) {
                    Console.WriteLine(book.title);
            }

            return books;
        }
    
        static void SortAlphabetically(List<Book> books, string order) {
            int n = books.Count;
            order.ToLower();

            for (int i = 0; i < n - 1; i++) {
                int minMaxIndex = i;
                for (int j = i + 1; j < n; j++) {
                    if ((order == "ascending" && books[j].title.CompareTo(books[minMaxIndex].title) < 0) ||
                        (order == "descending" && books[j].title.CompareTo(books[minMaxIndex].title) > 0)) {
                        minMaxIndex = j;
                    }
                }
                if (minMaxIndex != i) {
                    Book temp = books[i];
                    books[i] = books[minMaxIndex];
                    books[minMaxIndex] = temp;
                }
            }
        }

        static void SortByYear(List<Book> books, string order) {
            int n = books.Count;
            order.ToLower();
            for (int i = 0; i < n - 1; i++) {
                int minMaxIndex = i;
                for (int j = i + 1; j < n; j++) {
                    if (order == "descending") {
                        if (books[j].publication_year > books[minMaxIndex].publication_year) {
                            minMaxIndex = j;
                        }
                    } else {
                        if (books[j].publication_year < books[minMaxIndex].publication_year) {
                            minMaxIndex = j;
                        }
                    }
                }
                if (minMaxIndex != i) {
                    Book temp = books[i];
                    books[i] = books[minMaxIndex];
                    books[minMaxIndex] = temp;
                }
            }
        }
        
    }