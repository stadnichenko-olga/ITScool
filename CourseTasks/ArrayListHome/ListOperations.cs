using System.Collections.Generic;

namespace ArrayListHome
{
    class ListOperations
    {
        public static bool RemoveEven(ref List<int> list)
        {
            if (list.Count == 0)
            {
                return false;
            }

            int n = list.Count;
            bool result = false;

            for (int i = 0; i < n; i++)
            {
                if (list[i] % 2 == 0)
                {
                    list.RemoveAt(i);
                    result = true;
                    n--;
                    i--;
                }
            }

            return result;
        }

        public static List<int> RemoveAlliteration(List<int> list)
        {
            List<int> result = new List<int>();
            result.Capacity = list.Count;

            foreach (int item in list)
            {
                if (!result.Contains(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }
    }
}
