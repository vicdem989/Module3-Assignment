
using System.Text.Json;
using System.Text.Json.Serialization;


public class FlattenTheNumbers {
    public static List<object> deserializedArray = new List<object>();
    static void Main(string[] args)
    {
        Console.WriteLine("Flattened Array: ");
        foreach(int number in  FlattenTheNumbers.Flatten()) {
            Console.Write(number + ", ");
        }
    }


    #region Functions

    
    public static int[] Flatten() {
        
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
        
        List<int> result = DeserializeJsonToList(jsonContent);
        DeserializeJsonToList(jsonContent);

        int[] flattenedArray = result.ToArray();

        return flattenedArray;
    }    
    private static List<int> DeserializeJsonToList(string json) {
        List<int> result = new List<int>();
        JsonDocument doc = JsonDocument.Parse(json);
        JsonElement root = doc.RootElement;
        TraverseJsonArray(root, result);
        return result;
    }

     private static void TraverseJsonArray(JsonElement element, List<int> result) {
        if (element.ValueKind == JsonValueKind.Array) {
            foreach (JsonElement child in element.EnumerateArray()) {
                if (child.ValueKind == JsonValueKind.Array) {
                   TraverseJsonArray(child, result);
                } else if (child.ValueKind == JsonValueKind.Number) {
                    result.Add(child.GetInt32());
                }
            }
        }
    }
    
    #endregion
}
    