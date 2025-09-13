namespace _21_FinalWork
{
    internal class Program
    {
        static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> TempArr = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int diff = target - nums[i];
                if (TempArr.ContainsKey(diff))
                {
                    return new int[] { TempArr[diff], i };
                }
                TempArr[nums[i]] = i;

            }
            return new int[] { };

        }
        static void Main(string[] args)
        {
            int[] nums = { 3,3,3,3,2, 7, 11, 15 };
            int target = 9;
            int[] result = TwoSum(nums, target);

            Console.WriteLine($"{nums[result[0]]} + {nums[result[1]]} = {target}");

        }

    }
}