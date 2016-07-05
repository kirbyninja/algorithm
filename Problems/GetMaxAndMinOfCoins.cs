// 題目：
// 有n種硬幣，面值分別為V1, V2, V3, ...，Vn，每種硬幣都有無限多。給定非負整數S，可以選用多少個硬幣，使得面值之和剛好為S？
// 輸出硬幣數目的最小值(Min)和最大值(Max)。 1 ≦ n ≦ S，0 ≦ S ≦ 10000，1 ≦ Vi ≦ S。

// Input：
// n S
// V1 V2 V3 ... Vn

// Output：
// Max Min

// 輸入樣例1：
// 4 10         <=輸入為兩行，第一行為 n 跟 S
// 2 3 5 7      <=第二行為V1, V2, V3, ...，Vn

// 輸出樣例1：
// 5 2          <=輸出為一行

// 輸入樣例2：
// 2 13
// 2 3

// 輸入樣例2：
// 6 5

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Problems
{
    internal class GetMaxAndMinOfCoins
    {
        public static void Run()
        {
            int sum = int.Parse(Console.ReadLine().Split(' ')[1]);
            int[] values = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
            Dictionary<int, Tuple<int, int>> numberOfCoins = new Dictionary<int, Tuple<int, int>>(sum);

            for (int tempSum = values[0]; tempSum <= sum; ++tempSum)
            {
                int max = 0, min = sum;
                if (values.Contains(tempSum)) max = min = 1;
                for (int i = 0; i < values.Length && values[i] <= tempSum / 2; ++i)
                    if (numberOfCoins.ContainsKey(values[i]) && numberOfCoins.ContainsKey(tempSum - values[i]))
                    {
                        max = Math.Max(max, numberOfCoins[values[i]].Item1 + numberOfCoins[tempSum - values[i]].Item1);
                        min = Math.Min(min, numberOfCoins[values[i]].Item2 + numberOfCoins[tempSum - values[i]].Item2);
                    }
                if (max > 0) numberOfCoins.Add(tempSum, new Tuple<int, int>(max, min));
            }
            if (numberOfCoins.ContainsKey(sum))
                Console.WriteLine("{0} {1}", numberOfCoins[sum].Item2, numberOfCoins[sum].Item1);
            else
                Console.WriteLine("0 0");
        }
    }
}