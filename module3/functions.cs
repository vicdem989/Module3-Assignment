namespace functions {
    using System;
    using System.IO;
    using System.Text.Json;

    public class Functions {
        public static int SquareNumber(int numberToSquare) {
            return numberToSquare * numberToSquare;
        }
        
        public static double GetLengthInMM(double lengthInInches) {
            double mmToInchesRatio = 25.4;
            return lengthInInches * mmToInchesRatio;
        }

        public static double GetRoot(double numberToGetRoot) {        
            return Math.Sqrt(numberToGetRoot); 
        }

        public static int GetCube(int numberToGetCube) {
            return numberToGetCube * numberToGetCube * numberToGetCube;
        }

        public static double GetAreaOfCircle(double radiusOfCircle) {
            return Math.PI * radiusOfCircle * radiusOfCircle;
        }

        public static string Greetings(string name) {
            return "Greetings " + name + "!";
        }

    }
        
    public class Array {

    }

    public class Books {
        public static List<Book> books = new List<Book>();

        public class Book
            {
                public string title { get; set; }
                public int publication_year { get; set; }
                public string author { get; set; }
                public string isbn { get; set; }
                // Add more properties as needed
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
            catch (JsonException)
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
             foreach (var book in books) {
                Console.WriteLine($"Title: {book.title}");
                Console.WriteLine($"Publication year: {book.publication_year}");
                Console.WriteLine($"Author: {book.author}");
                Console.WriteLine($"ISBN {book.isbn}");
                Console.WriteLine(); 
            }
        }

        public static List<Book> FindBookStartingWith(string bookName) {
            ReadJSONFile();
            List<Book> results = new List<Book>();
            foreach (var book in books) {
                if(book.title.Contains(bookName)) { 
                    string[] arrayOfWordsInBookTitle = book.title.Split(' ');
                    if(arrayOfWordsInBookTitle[0] == bookName) {
                        results.Add(book);
                    }
                }
            }
            return results;
        }
    }
}

