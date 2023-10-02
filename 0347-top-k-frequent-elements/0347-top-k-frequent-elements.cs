public class Solution {
    public int[] TopKFrequent(int[] nums, int k)
    {
        var map = new Dictionary<int, int>();

        foreach (var num in nums)
        {
            if (!map.TryAdd(num, 1))
            {
                map[num]++;
            }
        }

        var arr = map.Select(x => (Num: x.Key, Freq: x.Value)).ToArray();

        QuickSelectAlgorithm<(int Num, int Freq)>.Sort(arr, k, (a, b) => b.Freq - a.Freq);

        var res = new int[k];

        for (int i = 0; i < k; i++)
        {
            res[i] = arr[i].Num;
        }

        return res;
    }
}

public static class QuickSelectAlgorithm<T>
{
    public static void Sort(T[] arr, int k, Comparison<T> comparer)
    {
        Sort(arr, 0, arr.Length - 1, k - 1, comparer);
    }

    private static void Sort(T[] arr, int start, int end, int k, Comparison<T> comparer)
    {
        while (true)
        {
            int partition = Partition(arr, start, end, comparer);

            if (partition == k) return;

            if (partition < k)
                start = partition + 1;
            else
                end = partition - 1;
        }
    }

    private static int Partition(T[] nums, int start, int end, Comparison<T> comparer)
    {
        int mid = start + (end - start) / 2;

        (nums[end], nums[mid]) = (nums[mid], nums[end]);

        int pivot = start;

        for (int i = start; i < end; i++)
        {
            if (comparer(nums[i], nums[end]) < 0)
            {
                (nums[pivot], nums[i]) = (nums[i], nums[pivot]);

                pivot++;
            }
        }

        (nums[pivot], nums[end]) = (nums[end], nums[pivot]);

        return pivot;
    }
}