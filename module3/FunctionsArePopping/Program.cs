using functionsArePopping;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("The square of the number 5 is " + FunctionsAreVeryMuchPoppingOff.SquareNumber(5));
       
        Console.WriteLine("5 inches is " + FunctionsAreVeryMuchPoppingOff.GetLengthInMM(5));
       
        Console.WriteLine("The root of 49 is " + FunctionsAreVeryMuchPoppingOff.GetRoot(49));

        Console.WriteLine("The cube of the number 5 is " + FunctionsAreVeryMuchPoppingOff.GetCube(5));

        Console.WriteLine("The area of a circle with a radius of 5 is " + FunctionsAreVeryMuchPoppingOff.GetAreaOfCircle(5));
       
        Console.WriteLine("Greetings " + FunctionsAreVeryMuchPoppingOff.Greetings("Simonsen <3"));
       
    }
}