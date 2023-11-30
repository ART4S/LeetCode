public class Solution {
    public int[][] IntervalIntersection(int[][] firstList, int[][] secondList)
    {
        int i = 0;
        int j = 0;

        var res = new List<int[]>();

        while (i < firstList.Length && j < secondList.Length)
        {
            if (firstList[i][1] < secondList[j][0])
            {
                i++;
            }
            else if (secondList[j][1] < firstList[i][0])
            {
                j++;
            }
            else
            {
                res.Add(new []
                {
                    Math.Max(firstList[i][0], secondList[j][0]),
                    Math.Min(firstList[i][1], secondList[j][1])
                });

                if (firstList[i][1] < secondList[j][1])
                {
                    i++;
                }
                else if (secondList[j][1] < firstList[i][1])
                {
                    j++;
                }
                else
                {
                    i++;
                    j++;
                }
            }
        }

        return res.ToArray();
    }
}