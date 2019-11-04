using System.Collections.Generic;

namespace ArrayListHome
{
    class ListOperations
    {
        public static bool RemoveEven(List<int> list)
        {
            bool hasEven = false;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] % 2 == 0)
                {
                    list.RemoveAt(i);
                    hasEven = true;
                    i--;
                }
            }

            return hasEven;
        }

        public static List<int> GetListWithoutRepeats(List<int> list)
        {
            List<int> result = new List<int>(list.Count);

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
