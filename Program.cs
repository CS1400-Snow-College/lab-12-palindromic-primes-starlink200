internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine(IsPrime(Convert.ToInt32(Console.ReadLine())));
        Console.WriteLine(isPalidromic(Convert.ToInt32(Console.ReadLine())));
    }

    //IsPrime() will decide if a number is a prime number, return true if it is prime, otherwise return false;
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
    
    //once a prime number has been found, this method will test that
    //by storing the digits in a list and then close in to the middle
    //seeing if each digit matches the other one equal in distants from
    //the nearest edge of the list.
    static bool isPalidromic(int num)
    {
        List<int> storeNums = new List<int>();
        int numCopy = num;
        while(num > 0)
        {
            storeNums.Add(num%10);
            num = num / 10;
        }
        foreach(int number in storeNums)
        {
            Console.Write( number + " " );
        }
        for(int i = 0; i < storeNums.Count()-1; i++)
        {
            if(storeNums[i] == storeNums[storeNums.Count()-1 - i])
            {
                
                return true;
            }
            else
            {
                i = storeNums.Count();
            }
        }
        if(numCopy < 10)
        {
            return true;
        }
        return false;
    }
}