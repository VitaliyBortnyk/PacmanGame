using System.Collections.Generic;

namespace Pacman
{
    static class SortResults
    {
        public static List<Result> SortDescending(List<Result> resultsList)
        {
            Result temp;

            for (int i = 0; i < resultsList.Count; i++)
            {
                for (int j = i + 1; j < resultsList.Count; j++)
                {
                    if (resultsList[i].score < resultsList[j].score)
                    {
                        temp = resultsList[i];
                        resultsList[i] = resultsList[j];
                        resultsList[j] = temp;
                    }
                    else if (resultsList[i].score.Equals(resultsList[j].score))
                       SortAscending(resultsList, i, j);
                }           
            }
            return resultsList;
        }

        private static List<Result> SortAscending(List<Result> results, int i, int j)
        {
            Result temp;

            if (results[i].attempt > results[j].attempt)
            {
                temp = results[i];
                results[i] = results[j];
                results[j] = temp;
            }
            return results;
        }
    }
}
