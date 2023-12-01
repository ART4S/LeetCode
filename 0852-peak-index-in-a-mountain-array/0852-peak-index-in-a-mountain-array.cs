public class Solution {
    public int PeakIndexInMountainArray(int[] arr)
    {
        return PeakIndexInMountainArray_LeftBinSearch(arr);
    }

    private int PeakIndexInMountainArray_BinSearch(int[] arr)
    {
        int l = 1;
        int r = arr.Length - 2;

        while (l <= r)
        {
            int m = l + (r - l) / 2;

            if (arr[m - 1] < arr[m] && arr[m] > arr[m + 1])
            {
                return m;
            }

            if (arr[m - 1] < arr[m])
                l = m + 1;
            else 
                r = m - 1;
        }

        return -1;
    }

    private int PeakIndexInMountainArray_LeftBinSearch(int[] arr)
    {
        int l = 1;
        int r = arr.Length - 2;

        while (l < r)
        {
            int m = l + (r - l) / 2;

            if (arr[m] > arr[m + 1])
                r = m;
            else 
                l = m + 1;
        }

        return l;
    }

    private int PeakIndexInMountainArray_RightBinSearch(int[] arr)
    {
        int l = 1;
        int r = arr.Length - 2;

        while (l < r)
        {
            int m = l + (r - l) / 2 + 1;

            if (arr[m - 1] < arr[m])
                l = m;
            else
                r = m - 1;
        }

        return r;
    }
}