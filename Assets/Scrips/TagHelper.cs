using System;
using System.Linq;
using UnityEditorInternal;

namespace Assets.Scrips
{
    public static class TagHelper
    {
        public static string Get(string which)
        {
            var all = InternalEditorUtility.tags;
            if (all.Any(it => it == which))
                return which;

            string misspelledTag;
            if (!string.IsNullOrEmpty(misspelledTag = all.FirstOrDefault(it => it.ToLower() == which.ToLower())))
                return misspelledTag;

            throw new InvalidOperationException("Invalid tag name : " + which);
        }
    }
}