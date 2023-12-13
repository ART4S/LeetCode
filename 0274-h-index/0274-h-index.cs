public class Solution {
    public int HIndex(int[] citations) {
        Array.Sort(citations, (x, y) => y - x);

        int h = 0;

        for (int i = 0; i < citations.Length && citations[i] > i; i++)
        {
            h++;
        }

        return h;
    }
}