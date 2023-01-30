
// I've used VS 2022 Preview
// Renamed variables to make the code more readable
// Flipped the loop to count down rather than up since we are looking for the highest number
// Changed the start and end boundaries to the highest and lowest 3 digit number to reduce a couple of iterations
// Changed if greater than to Math.Max to be more readable
// Changed start and finish loop values to variables so you only have to change the value in one place.
// Added ability to pass in size, for a bit of fun, but defaults to 3 as per the challenge.
// Changed second loop to start at value of first loop so calculation does not double up e.g. if we have done 999 * 998 we don't need to do 998 * 999
// Added some error handling incase bad data is passed
// Added tests
// Moved code to a Palindrome 'Service' for maintainability and reusability 
// Added calculation to break out of loop once it's not possible to create a higher number
// Using File Scoped Namespace to keep class cleaner
// Using global usings file to keep class cleaner
// I haven't used any DI as there was just use for it in this project using a static class, but if you want to see me demonstrate using it, please let me know.
// I haven't really used any LINQ other than .SequenceEqual(), again if you would like to see me write something to demonstrate using it, please let me know. 

namespace GuardhogTechTest.Services;

public static class PalindromeService
{
    public static int GetPalindrome(int numberSize = 3)
    {
        try
        {
            // Anything bigger than 9999 * 9999 will blow our int
            if (numberSize > 4)
                throw new Exception("Number size is too large");

            if (numberSize < 1)
                throw new Exception("Number size is too small");

            // Get highest and lowest value for numberSize
            var upperBoundaryString = new string(Enumerable.Repeat('9', numberSize).ToArray());
            var lowerBoundaryString = "1" + new string(Enumerable.Repeat('0', numberSize - 1).ToArray());

            // Should be able to guarantee string is a number here so no need to try parse
            var upperBoundary = int.Parse(upperBoundaryString);
            var lowerBoundary = int.Parse(lowerBoundaryString);

            var biggestPalindrome = 0;
            var sqrt = 0;

            // outer will be first loop
            for (int firstNum = upperBoundary; firstNum >= lowerBoundary; firstNum--)
            {
                // go through the numbers from 999 to 100
                for (int secondNum = firstNum; secondNum >= lowerBoundary; secondNum--)
                {
                    // Attempt to break out early if it's not possible to create a higher number
                    if (firstNum <= sqrt)
                        return biggestPalindrome;

                    // work out the product
                    var calculatedNum = firstNum * secondNum;
                    var calculatedString = calculatedNum.ToString();


                    // figure out if this is a palindrome
                    if (calculatedString.SequenceEqual(calculatedString.Reverse()))
                    {
                        biggestPalindrome = Math.Max(calculatedNum, biggestPalindrome);
                        // Largest combination that could possible create a higher number
                        sqrt = Convert.ToInt32(Math.Floor(Math.Sqrt(biggestPalindrome)));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Log exception
            Console.WriteLine(ex);
            throw;
        }

        return 0;
    }

    public static int GetPalindromeAlt(int numberSize = 3)
    {
        try
        {
            // Anything bigger than 9999 * 9999 will blow our int
            if (numberSize > 4)
                throw new Exception("Number size is too large");

            if (numberSize < 1)
                throw new Exception("Number size is too small");

            // Get highest and lowest value for numberSize
            var upperBoundaryString = new string(Enumerable.Repeat('9', numberSize).ToArray());
            var lowerBoundaryString = "1" + new string(Enumerable.Repeat('0', numberSize - 1).ToArray());

            // Should be able to guarantee string is a number here so no need to try parse
            var upperBoundary = int.Parse(upperBoundaryString);
            var lowerBoundary = int.Parse(lowerBoundaryString);

            // Find the biggest posible number as a starting point
            var biggest = upperBoundary * upperBoundary;

            for (int numberToCheck = biggest; numberToCheck >= lowerBoundary; numberToCheck--)
            {
                // Is this a Palindrome
                var stringToCheck = numberToCheck.ToString();
                if (calculatedString.SequenceEqual(calculatedString.Reverse()))
            }


        }
        catch (Exception ex)
        {
            // Log exception
            Console.WriteLine(ex);
            throw;
        }

        return 0;
    }
}
