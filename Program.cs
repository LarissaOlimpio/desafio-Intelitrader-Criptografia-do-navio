using System;


public class Program
{
    public static void Main()
    {
        string message = "10010110 11110111 01010110 00000001 00010111 00100110 01010111 00000001 " +
                        "00010111 01110110 01010111 00110110 11110111 11010111 01010111 00000011";

        Console.WriteLine(Decrypt(message));
        Console.ReadLine();
    }

    static string SwapLastTwoBits(string byteStr)
    {
        string firstSixBits = byteStr.Substring(0, 6);
        string lastTwoSwapped = byteStr[6] == '0' ? "1" : "0";
        lastTwoSwapped += byteStr[7] == '0' ? "1" : "0";
        return firstSixBits + lastTwoSwapped;
    }

    static string SwapEveryFourBits(string byteStr)
    {
        return byteStr.Substring(4, 4) + byteStr.Substring(0, 4);
    }

    static string BinaryToText(string[] binary)
    {
        string text = "";
        foreach (string letter in binary)
        {
            char character = (char)Convert.ToInt32(letter, 2);
            text += character;
        }
        return text;
    }

    static string Decrypt(string message)
    {
        string[] byteStr = message.Split(' ');
        for (int i = 0; i < byteStr.Length; i++)
        {
            byteStr[i] = SwapLastTwoBits(byteStr[i]);
            byteStr[i] = SwapEveryFourBits(byteStr[i]);
        }
        return BinaryToText(byteStr);
    }
}

