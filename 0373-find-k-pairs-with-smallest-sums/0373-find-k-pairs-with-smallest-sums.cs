public class Solution {
    public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
    {
        var res = new List<IList<int>>();

        var pque = new PriorityQueue<(int i, int j), int>();

        var visited = new HashSet<(int, int)> { (0, 0) };

        pque.Enqueue((0, 0), nums1[0] + nums2[0]);

        while (res.Count < k && pque.Count > 0)
        {
            var cell = pque.Dequeue();

            res.Add(new []{ nums1[cell.i], nums2[cell.j] });

            var ncell = cell with { i = cell.i + 1 };

            if (ncell.i < nums1.Length && visited.Add(ncell))
            {
                pque.Enqueue(ncell, nums1[ncell.i] + nums2[ncell.j]);
            }

            ncell = cell with { j = cell.j + 1 };

            if (ncell.j < nums2.Length && visited.Add(ncell))
            {
                pque.Enqueue(ncell, nums1[ncell.i] + nums2[ncell.j]);
            }
        }

        return res;
    }
}