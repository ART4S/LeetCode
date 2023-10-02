public class Solution {
    public int MaxArea(int[] height)
    {
        int l = 0;
        int r = height.Length - 1;
        int maxSquare = int.MinValue;

        while (l < r)
        {
            int h = Math.Min(height[l], height[r]);
            int w = r - l;
            int s = h * w;

            maxSquare = Math.Max(maxSquare, s);

            if (height[l] > height[r]) r--;
            else if (height[l] < height[r]) l++;
            else if (height[l + 1] > height[r - 1]) l++;
            else r--;
        }

        return maxSquare;
    }
}