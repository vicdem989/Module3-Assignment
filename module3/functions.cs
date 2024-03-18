namespace functions;

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


