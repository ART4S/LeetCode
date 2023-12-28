public class Solution {
    // n logn
    public int[] AdvantageCount(int[] nums1, int[] nums2)
    {
        var n = nums1.Length;

        var n1sorted = nums1.ToArray();
        var n2sorted = nums2.Select((x, i) => (Num: x, Ind: i)).ToArray();

        Array.Sort(n1sorted);
        Array.Sort(n2sorted, (a, b) => a.Num - b.Num);

        for (int i = 0, l = 0, r = n - 1; i < n; i++)
        {
            if (n1sorted[i] > n2sorted[l].Num)
                nums1[n2sorted[l++].Ind] = n1sorted[i];
            else
                nums1[n2sorted[r--].Ind] = n1sorted[i];
        }

        return nums1;
    }
}