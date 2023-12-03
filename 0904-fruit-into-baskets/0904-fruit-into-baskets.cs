public class Solution {
    public int TotalFruit(int[] fruits)
    {
        int maxFruitsCount = 0;

        var basket = new Dictionary<int, int>();

        for (int i = 0, j = 0; i < fruits.Length; i++)
        {
            basket.TryAdd(fruits[i], 0);

            basket[fruits[i]]++;

            while (basket.Count > 2)
            {
                if (--basket[fruits[j]] == 0)
                {
                    basket.Remove(fruits[j]);
                }

                j++;
            }

            maxFruitsCount = Math.Max(maxFruitsCount, i - j + 1);
        }

        return maxFruitsCount;
    }
}