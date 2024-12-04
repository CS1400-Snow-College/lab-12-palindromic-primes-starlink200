internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine(IsPrime(Convert.ToInt32(Console.ReadLine())));
    }
    static bool IsPrime(int testNum)
    {
        int count = 0;

        //start count at 0, since a number won't be tested against itself or 1
        count = 2;
        for (int i = 2; i <= Math.Sqrt(testNum); i++)
        {
            if (testNum % i == 0)
            {
                count++;
            }
            if (count >= 3)
            {
                i = testNum + 1;
            }
        }
        if (count <= 2 && testNum != 1 && testNum != 0)
        {
            return true;
        }
        return false;
    }
}