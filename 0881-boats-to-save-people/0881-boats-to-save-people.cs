public class Solution {
    // n logn
    public int NumRescueBoats(int[] people, int limit)
    {
        Array.Sort(people);

        int n = people.Length;

        int l = 0;
        int r = n - 1;

        int boats = 0;

        while (l < r)
        {
            boats++;

            if (people[l] + people[r] <= limit)
            {
                l++;
                r--;
            }
            else
            {
                r--;
            }
        }

        if (l == r)
        {
            boats++;
        }

        return boats;
    }
}