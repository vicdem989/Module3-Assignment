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
            double pi = 3.14;
            return pi * radiusOfCircle * radiusOfCircle;
        }

        public static string Greetings(string name) {
            return "Greetings " + name + "!";
        }

    }
        
    public class Array {
        public static void FlattenArray() {
            
        }
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
                        // Path to your JSON file
                        string filePath = "books.json";

                        // Read the entire file content
                        string jsonString = File.ReadAllText(filePath);

                        // Deserialize the JSON string to a list of Book objects
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
             foreach (var book in books) {
                Console.WriteLine($"Title: {book.title}");
                Console.WriteLine($"Publication year: {book.publication_year}");
                Console.WriteLine($"Author: {book.author}");
                Console.WriteLine($"ISBN {book.isbn}");
                Console.WriteLine(); // Add an empty line for better readability
            }
        }

        public static List<Book> ReturnAmountBookStartingWith(string bookStartsWith) {
            
        }

    }
}

