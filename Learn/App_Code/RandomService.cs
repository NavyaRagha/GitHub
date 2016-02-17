using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RandomService
/// </summary>
public static  class RandomService
{
    static RandomService()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static List<int?> GenerateRandom()
    {
        Random r = new Random();
        List<int?> randomNumbers = new List<int?>();

        for (int i = 0; i < 3; i++)
        {
            int number;

            do number = r.Next(0, 5); while (randomNumbers.Contains(number));

            randomNumbers.Add(number);
        }
        return randomNumbers;
    }
}