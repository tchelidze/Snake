using UnityEngine;

namespace Assets
{
    public static class TupleExtensions
    {
        public static Vector2 ToVector2(this Tuple<int, int> what)
        {
            return new Vector2(what.Item1, what.Item2);
        }
    }
}