using UnityEngine;
using System.Collections.Generic;
using System;

namespace SplashAndSolve
{
    public static class Extensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            System.Random rng = new System.Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static T SelectRandom<T>(this IList<T> list)
        {
            return list[UnityEngine.Random.Range(0, list.Count - 1)];
        }

        public static List<T> GetRandomElements<T>(this IList<T> list, int n)
        {
            if (list.Count < n)
            {
                throw new ArgumentException($"List must contain at least {n} elements");
            }

            List<T> randomElements = new List<T>();

            list.Shuffle();
            for (int i = 0; i < n; i++)
            {
                randomElements.Add(list[i]);
            }

            return randomElements;
        }
    }
}