using System;
using System.Collections.Generic;

class Program {
    static void Main() {

        System.Console.WriteLine("Enter words:");

        string input = System.Console.ReadLine();

        string[] words = input.Split(" ");

        string result = "";

        foreach (var x in words) {
            result+=x[0].ToString().ToUpper();
        }

        System.Console.WriteLine(result);

    }
}