public class Solution {
    public IList<int> FindClosestElements(int[] arr, int k, int x)
    {
        return FindClosestElements_BinarySearch(arr, k, x);
    }

    private IList<int> FindClosestElements_BinarySearch(int[] arr, int k, int x)
    {
        int l = 0;
        int r = arr.Length - 1;

        while (l < r)
        {
            int m = l + (r - l) / 2;

            if (arr[m] < x)
                l = m + 1;
            else
                r = m;
        }

        l--;

        var deque = new LinkedList<int>();

        while (k-- > 0)
        {
            if (l >= 0 && r < arr.Length)
            {
                if (Math.Abs(arr[l] - x) <= Math.Abs(arr[r] - x))
                    deque.AddFirst(arr[l--]);
                else
                    deque.AddLast(arr[r++]);
            }
            else if (l >= 0)
                deque.AddFirst(arr[l--]);
            else
                deque.AddLast(arr[r++]);
        }

        return deque.ToArray();
    }

    private IList<int> FindClosestElements_TwoPointers(int[] arr, int k, int x)
    {
        int j = k - 1;

        for (int i = k; i < arr.Length; i++)
        {
            if (Math.Abs(arr[i] - x) < Math.Abs(arr[i - k] - x))
            {
                j = i;
            }
        }

        return arr[(j - k + 1)..(j + 1)];
    }
}