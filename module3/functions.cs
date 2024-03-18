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


        //Using built in functionaly such as Math library

        
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


/*

Create the following functions:

A function that returns the square of a number
A function that returns a length in mm assuming it has been given a length in inches.
A function that returns the root of a number
A function that returns the cube of a number
A function that returns the area of a circle given the radius.
A function that returns a greeting, given a name.

*/
