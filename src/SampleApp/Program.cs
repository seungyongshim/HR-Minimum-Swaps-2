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
using FluentAssertions;

class Solution
{
    

    // Complete the maxSubsetSum function below.
    static int maxSubsetSum(int[] arr)
    {
        var dp = new int[100005];

        dp[0] = Math.Max(arr[0], 0);

        if (arr.Length == 1)
        {
            return dp[0];
        }

        for (int i = 1; i < arr.Length; i++)
        {
            dp[i] = Math.Max(dp.ElementAtOrDefault(i - 2), Math.Max(dp[i - 1], dp.ElementAtOrDefault(i - 2) + arr[i]));
        }

        int n = arr.Length;

        return Math.Max(dp[n - 1], dp[n - 2]);

    }

    static void Main(string[] args)
    {
        maxSubsetSum(new int[] { 3, 7, 4, 6, 5 }).Should().Be(13);
        maxSubsetSum(new int[] { -1 }).Should().Be(-1);
    }
}
