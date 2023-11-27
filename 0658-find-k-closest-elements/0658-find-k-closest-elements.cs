public class Solution {
    public IList<int> FindClosestElements(int[] arr, int k, int x)
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
