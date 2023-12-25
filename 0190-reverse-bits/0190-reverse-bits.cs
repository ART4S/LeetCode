public class Solution
{
    public uint reverseBits(uint n)
    {
        uint res = 0;
        uint mask = 0b10_0000000000_0000000000_0000000000; // 2 ^ 31
        uint p = 0;

        for (int i = 0; i < 32; i++)
        {
            p = p == 0 ? 1 : p * 2;

            res += ((n & mask) > 0 ? 1u : 0u) * p;

            n <<= 1;
        }

        return res;
    }
}