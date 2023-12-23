public class Solution {
    public int[] FindDiagonalOrder(IList<IList<int>> nums)
    {
        return FindDiagonalOrder_Queue(nums);
    }

    private int[] FindDiagonalOrder_Queue(IList<IList<int>> nums)
    {
        var que = new Queue<(int i, int j)>();

        que.Enqueue((0, 0));

        var res = new List<int>();

        while (que.TryDequeue(out var cur))
        {
            res.Add(nums[cur.i][cur.j]);

            if (cur.i + 1 < nums.Count && cur.j == 0)
            {
                que.Enqueue(cur with { i = cur.i + 1 });
            }

            if (cur.j + 1 < nums[cur.i].Count)
            {
                que.Enqueue(cur with { j = cur.j + 1 });
            }
        }

        return res.ToArray();
    }
}