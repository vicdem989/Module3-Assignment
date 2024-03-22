namespace functions {
    using System;
    using System.ComponentModel.Design;
    using System.IO;
    using System.Net.Http.Json;
    using System.Runtime.InteropServices;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks.Dataflow;

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
        

    public class LeftAndRight {

        public static string jsonString = string.Empty; 
           
        public static int GetTotalSumOfStructure() {
            try
            {
                string filePath = "nodes.json";
                jsonString = File.ReadAllText(filePath);   
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

            int sumOfStructure = 0;

            using (JsonDocument doc = JsonDocument.Parse(jsonString))
            {
                JsonElement rootElement = doc.RootElement;
                sumOfStructure = CalculateSumOfValues(rootElement);
            }
            return sumOfStructure;

            
            
        }

        public static int CalculateSumOfValues(JsonElement element) {            
            if (element.ValueKind == JsonValueKind.Object) {
                int sum = 0;
                foreach (var property in element.EnumerateObject()) {
                    if (property.Name == "value" && property.Value.ValueKind == JsonValueKind.Number) {
                        sum += property.Value.GetInt32(); 
                    } else {
                        sum += CalculateSumOfValues(property.Value);
                    }
                }
                return sum;
            } else if (element.ValueKind == JsonValueKind.Array) {
                int sum = 0;
                foreach (var item in element.EnumerateArray()) {
                    sum += CalculateSumOfValues(item);
                }
                return sum;
            } else {
                return 0;
            }
        }
    }




    public class FlattenTheNumbers {
        //public static int[][] jaggedArray;
        public static int[] Flatten() {

            List<object> deserializedArray = new List<object>();

            string filePath = "arrays.json";

            string jsonContent = File.ReadAllText(filePath);
             try
            {
                
                deserializedArray = JsonSerializer.Deserialize<List<object>>(jsonContent);
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
            
            //Console.WriteLine(jsonContent);

            List<int> result = DeserializeJsonToList(jsonContent);
            DeserializeJsonToList(jsonContent);
            int[] flattenedArray = result.ToArray();
            /*foreach(int item in result) {
                Console.WriteLine(item);
            }*/

            return flattenedArray;
        }    

        static List<int> DeserializeJsonToList(string json) {
            List<int> result = new List<int>();

            JsonDocument doc = JsonDocument.Parse(json);
            JsonElement root = doc.RootElement;

            TraverseJsonArray(root, result);

            return result;
        }

         static void TraverseJsonArray(JsonElement element, List<int> result)
            {
                if (element.ValueKind == JsonValueKind.Array)
                {
                    foreach (JsonElement child in element.EnumerateArray())
                    {
                        if (child.ValueKind == JsonValueKind.Array)
                        {
                            TraverseJsonArray(child, result);
                        }
                        else if (child.ValueKind == JsonValueKind.Number)
                        {
                            result.Add(child.GetInt32());
                        }
                    }
                }
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

        public static List<Book> ListBooks(string sortingOrder) {

        //Work in progress, figoure out how to sort by parameter
            ReadJSONFile();
            List<Book> sortedList = new List<Book>();
            foreach(Book book in books) {
                sortedList.Add(book);
            }
            sortedList.Sort();
            return sortedList;
        }
    }
}

