public class Solution {
    public int[] FindDiagonalOrder(IList<IList<int>> nums)
    {
        var que = new Queue<int[]>();

        que.Enqueue(new []{0, 0});

        var res = new List<int>();

        while (que.TryDequeue(out var cur))
        {
            int i = cur[0];
            int j = cur[1];

            res.Add(nums[i][j]);

            if (i + 1 < nums.Count && j == 0)
            {
                que.Enqueue(new []{ i + 1, j });
            }

            if (j + 1 < nums[i].Count)
            {
                cur[1]++;

                que.Enqueue(cur);
            }
        }

        return res.ToArray();
    }
}