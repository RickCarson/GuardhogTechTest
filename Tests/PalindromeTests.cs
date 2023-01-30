
namespace GuardhogTechTest.Tests;

[TestFixture]
public class PalindromeTests
{
    [Test]
    public async Task GetHighestPalindromeForDefaultValue()
    {
        Assert.IsTrue(PalindromeService.GetPalindrome() == 906609);
    }

    [Test]
    public async Task GetHighestPalindromeFor1Digit()
    {
        Assert.IsTrue(PalindromeService.GetPalindrome(1) == 9);
    }

    [Test]
    public async Task GetHighestPalindromeFor2Digit()
    {
        Assert.IsTrue(PalindromeService.GetPalindrome(2) == 9009);
    }


    [Test]
    public async Task GetHighestPalindromeFor3Digit()
    {
        Assert.IsTrue(PalindromeService.GetPalindrome(3) == 906609);
    }


    [Test]
    public async Task GetHighestPalindromeFor4Digit()
    {
        Assert.IsTrue(PalindromeService.GetPalindrome(4) == 99000099);
    }

    [Test]
    public async Task ExceptionThrownLengthPassedIsTooSmall()
    {
        var exception = Assert.Throws<Exception>(() => PalindromeService.GetPalindrome(0));
        Assert.That(exception.Message, Is.EqualTo("Number size is too small"));
    }

    [Test]
    public async Task ExceptionThrownLengthPassedIsTooHigh()
    {
        var exception = Assert.Throws<Exception>(() => PalindromeService.GetPalindrome(5));
        Assert.That(exception.Message, Is.EqualTo("Number size is too large"));
    }
}
