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
     * Complete the 'getTotalX' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY a
     *  2. INTEGER_ARRAY b
     */

    public static int getTotalX(List<int> a, List<int> b)
    {
        int quantidadeNumerosQueAtendemAsDuasCondicoes = 0;
        
        int menorArray1 = a.Min();
        int menorArray2 = b.Min();
        int menor = Math.Min(menorArray1, menorArray2);
        
        int maiorArray1 = a.Max();
        int maiorArray2 = b.Max();
        int maior = Math.Max(maiorArray1, maiorArray2);
        
        for(int i = menor; i <= maior; i++){
            bool numeroSatisfazAPrimeiraCondicao = a.All(_ => i % _ == 0);
            bool numeroSatisfazASegundaCondicao = b.All(_ => _ % i == 0);
            
            if(numeroSatisfazAPrimeiraCondicao && numeroSatisfazASegundaCondicao){
                quantidadeNumerosQueAtendemAsDuasCondicoes++;
            }
        }
        
        return quantidadeNumerosQueAtendemAsDuasCondicoes;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int m = Convert.ToInt32(firstMultipleInput[1]);

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        List<int> brr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(brrTemp => Convert.ToInt32(brrTemp)).ToList();

        int total = Result.getTotalX(arr, brr);

        textWriter.WriteLine(total);

        textWriter.Flush();
        textWriter.Close();
    }
}
