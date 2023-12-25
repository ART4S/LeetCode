public class Solution {
    public int RangeBitwiseAnd(int left, int right)
    {
        int mask = 0b1_0000000000_0000000000_0000000000; // 2 ^ 31

        int num = 0;

        bool flag = false;

        for (int i = 31; i > 0; i--, left <<= 1, right <<= 1)
        {
            num <<= 1;

            int lbit = left & mask;
            int rbit = right & mask;

            if (lbit == rbit)
            {
                if (!flag && lbit != 0)
                {
                    num++;
                }
            }
            else
            {
                flag = true;
            }

        }

        return num;
    }
}