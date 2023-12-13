public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        int i = 0;
        int j = 0;
        int n = nums1.Length;
        int m = nums2.Length;
        int nm = n + m;

        int merged = 0;
        int median = nm / 2 + 1;

        int cur = 0;
        int prev = 0;

        while (merged < median)
        {
            if (i < n && j < m)
            {
                if (nums1[i] < nums2[j])
                    (cur, prev) = (nums1[i++], cur);
                else
                    (cur, prev) = (nums2[j++], cur);
            }
            else if (i < n)
            {
                (cur, prev) = (nums1[i++], cur);
            }
            else
            {
                (cur, prev) = (nums2[j++], cur);
            }

            merged++;
        }

        if (nm % 2 == 0)
        {
            return (prev + cur) / 2d;
        }

        return cur;
    }
}