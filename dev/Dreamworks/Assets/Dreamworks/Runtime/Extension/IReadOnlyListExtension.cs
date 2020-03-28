using System.Collections.Generic;

namespace DreamMachineGameStudio.Dreamworks.Extension
{
    public static class IReadOnlyListExtension
    {
        public static int IndexOf<T>(this IReadOnlyList<T> list, T item) where T : class
        {
            for (int i = 0; i < list.Count; ++i)
            {
                if (list[i] == item)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}