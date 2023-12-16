public class Solution {
    public int MinMutation(string startGene, string endGene, string[] bank)
    {
        if (startGene == endGene) return 0;

        var bk = new HashSet<string>(bank);

        if (!bk.Contains(endGene)) return -1;

        var vis = new HashSet<string>() { startGene };

        var que = new Queue<string>();

        que.Enqueue(startGene);

        int dist = 0;

        while (que.Count > 0)
        {
            int n = que.Count;

            while (n-- > 0)
            {
                var cur = que.Dequeue();

                if (cur == endGene) return dist;

                var curArr = cur.ToCharArray();

                for (int i = 0; i < 8; i++)
                {
                    var temp = curArr[i];

                    foreach (var mut in "ACGT")
                    {
                        curArr[i] = mut;

                        var next = new string(curArr);

                        if (bk.Contains(next) && vis.Add(next))
                        {
                            que.Enqueue(next);
                        }
                    }

                    curArr[i] = temp;
                }
            }

            dist++;
        }

        return -1;
    }
}