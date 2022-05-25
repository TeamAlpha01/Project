using Xunit;

public class testclass
{
    [Fact]
    public void TestForADD()
    {
       Assert.Equal(4,Program.Add(2,2));
    }
    [Fact]
    public void TestForSub()
    {
       Assert.NotEqual(1,Program.Sub(2,2));
    }
}