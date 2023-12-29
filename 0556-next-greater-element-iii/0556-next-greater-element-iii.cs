public class Solution {
    public int NextGreaterElement(int n)
    {
        return NextGreaterElement_Count(n);
    }

    // n
    private int NextGreaterElement_Count(int n)
    {
        var num = new List<int>();

        for (int nn = n; nn != 0; nn /= 10)
        {
            num.Add(nn % 10);
        }

        var count = new int[10];

        for (int i = 0; i < num.Count; i++)
        {
            int next = -1;

            for (int j = num[i] + 1; j <= 9; j++)
            {
                if (count[j] > 0)
                {
                    next = j;
                    break;
                }
            }

            count[num[i]]++;

            if (next != -1)
            {
                num[i] = next;

                count[next]--;

                for (int j = 9, k = 0; j >= 0; j--)
                {
                    while (count[j]-- > 0)
                    {
                        num[k++] = j;
                    }
                }

                break;
            }
        }

        int m = 0;

        for (int i = num.Count - 1; i >= 0; i--)
        {
            m = m * 10 + num[i];
        }

        return m > n ? m : -1;
    }

    // n^2 + n logn
    private int NextGreaterElement_BruteForce(int n)
    {
        var num = new List<int>();

        for (int nn = n; nn != 0; nn /= 10)
        {
            num.Add(nn % 10);
        }

        for (int i = 0; i < num.Count; i++)
        {
            int k = -1;

            for (int j = 0; j < i; j++)
            {
                if (num[j] > num[i] && (k == -1 || num[j] < num[k]))
                {
                    k = j;
                }
            }

            if (k != -1)
            {
                (num[i], num[k]) = (num[k], num[i]);

                num.Sort(0, i, Comparer<int>.Create((x, y) => y - x));

                break;
            }
        }

        int m = 0;

        for (int i = num.Count - 1; i >= 0; i--)
        {
            m = m * 10 + num[i];
        }

        return m > n ? m : n;
    }
}