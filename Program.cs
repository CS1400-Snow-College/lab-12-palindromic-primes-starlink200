/*************************************
* Name: Caleb Roskelley
* Project: Lab 12 Palindromic Primes
* Date Due: 12/4/2024
*************************************/

internal class Program
{
    private static void Main(string[] args)
    {
        bool validNum = true;
        int num = 0;
        intro();
        do
        {
            Console.WriteLine("What palindromic prime would you like me to find?");
            validNum = int.TryParse(Console.ReadLine(), out num);
        }
        while(!validNum);
        Console.WriteLine($"{nthPrimePalindrome(num)} is the {num}th palindromic prime");
    }

    static void intro()
    {
        Console.WriteLine("Hello! This program will find the nth palindromic prime, which is a number that is the same forwards and backwards and it is only divisible by itself and 1");
        Console.WriteLine("n which palindromic prime you want me to find i.e. find the 10th palindromic prime");
    }

    //IsPrime() will decide if a number is a prime number, return true if it is prime, otherwise return false;
    static bool isPrime(int testNum)
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

        //digit count will keep track of how many digits the number is
        //when deciding if a number is palindromic correct count will be
        //tested to see if its the same as digit count
        int correctCount = 0;
        int digitCount = 0;
        while(num > 0)
        {
            storeNums.Add(num%10);
            num = num / 10;
            digitCount++;
        }

        for(int i = 0; i < storeNums.Count()/2; i++)
        {
            if(storeNums[i] == storeNums[storeNums.Count()-1 - i])
            {
                correctCount++;
            }
            else
            {
                i = storeNums.Count();
            }
        }
        if(correctCount == digitCount/2)
        {
            return true;
        }
        return false;
    }

    //this method will use the IsPrime and isPalindromic methods to then find the specified nth palindromic prime
    static int nthPrimePalindrome(int n)
    {
        int count = 0;
        //num is the number that is being tested
        int num = 1;
        while(count != n)
        {
            num++;
            if(isPrime(num) && isPalidromic(num))
            {
                count++;
            }
        }
        return num;
    }
}