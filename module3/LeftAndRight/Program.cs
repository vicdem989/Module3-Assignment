using System.Text.Json;

class LeftAndRight
{
    static void Main(string[] args)
    {
        Console.WriteLine("The sum of the total structure is: " + GetTotalSumOfStructure());

        Console.WriteLine("The deepest level of the structure is: " + GetDeepestLevelOfStructure());

        Console.WriteLine("There are: " + GetAmountNodesInStructure() + " nodes in the structure");
    }

    public static string jsonString = string.Empty; 

    #region Functions

        private static void ReadJsonFile() {
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
        }
           
        public static int GetDeepestLevelOfStructure() {
            ReadJsonFile();

            int deepestLevelOfStructure = 0;

            using (JsonDocument doc = JsonDocument.Parse(jsonString)) {
                JsonElement rootElement = doc.RootElement;
                deepestLevelOfStructure = CalculateDeepestLevelOfStructure(rootElement);
            }
            return deepestLevelOfStructure;
        }
        
        public static int GetTotalSumOfStructure() {
            ReadJsonFile();

            int sumOfStructure = 0;

            using (JsonDocument doc = JsonDocument.Parse(jsonString)) {
                JsonElement rootElement = doc.RootElement;
                sumOfStructure = CalculateSumOfValues(rootElement);
            }
            return sumOfStructure;
        }

        public static int GetAmountNodesInStructure() {
            ReadJsonFile();

            int amountOfNodes = 0;

            using (JsonDocument doc = JsonDocument.Parse(jsonString)) {
                JsonElement rootElement = doc.RootElement;
                amountOfNodes = CountNodes(rootElement);
            }
            return amountOfNodes;
        }

        private static int CountNodes(JsonElement element) {
            if (element.ValueKind != JsonValueKind.Object)
                return 0;

            int count = 1; 
            foreach (var property in element.EnumerateObject()) {
                if (property.Value.ValueKind == JsonValueKind.Object) {
                    count += CountNodes(property.Value); 
                }
            }
            return count;
        }

        private static int CalculateDeepestLevelOfStructure(JsonElement element) {
            if (element.ValueKind != JsonValueKind.Object)
                return 1;

            int amountOfLevels = 1;
            foreach (var property in element.EnumerateObject()) {
                if (property.Value.ValueKind == JsonValueKind.Object) {
                    int depth = 1 + CalculateDeepestLevelOfStructure(property.Value);
                    amountOfLevels = Math.Max(amountOfLevels, depth);
                }
            }
            return amountOfLevels;
        }        

        private static int CalculateSumOfValues(JsonElement element) {            
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

    #endregion

}
        