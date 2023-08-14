using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'pickingNumbers' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY a as parameter.
     */

    public static int pickingNumbers(List<int> a)
    {
        a.Sort();
        int max_value = 0, min_value =0;
        List<int> temporaryList = new List<int>();
        List<int> counterList = new List<int>();
        for(int i=0; i < a.Count; i++)
        {
            temporaryList.Add(a[i]);
            max_value = temporaryList.Max();
            min_value = temporaryList.Min();
            if((Math.Abs(max_value - min_value)) <= 1)
            {
                counterList.Add(temporaryList.Count);
                continue;
            }
            else
            {
                temporaryList.Remove(a[i]);
                counterList.Add(temporaryList.Count);
                temporaryList.Clear();
                i--;
            }
        }
        return counterList.Max();
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

        int result = Result.pickingNumbers(a);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
