using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LordBreakerX.Utilities.Collections
{
    public static class ArrayUtility
    {
        public static void Shuffle<T>(this T[] array)
        {
            int n = array.Length;
            while (n > 1) 
            {
                n--;
                int k = Random.Range(0, n + 1);
                T temp = array[k];
                array[k] = array[n];
                array[n] = temp;
            }
        }
    }
}
