using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets
{
    public static class RandomExtensions
    {
        public static Vector2 RandomPosition(
            int startingXPosition,
            int endingXPosition,
            int startingYPosition,
            int endingYPosition,
            params Vector2[] excludedPositions)
        {
            var allPosition =
                from possibleX in Enumerable.Range(startingXPosition, endingXPosition)
                from possibleY in Enumerable.Range(startingYPosition, endingYPosition)
                select new Vector2(possibleX, possibleY);
            return allPosition.Except(excludedPositions).RandomElement();
        }

        public static int RandomInRangeExcept(int from, int to, params int[] except)
        {
            return Enumerable
                .Range(from, to)
                .Except(except)
                .RandomElement();
        }

        public static T RandomElement<T>(this IEnumerable<T> @in)
        {
            var randomIndex = Random.Range(0, @in.Count());
            return @in.ElementAt(randomIndex);
        }
    }
}