namespace BwlogApi.UnitTests.Systems.Controllers;

public class TestProfileController
{
    [Fact]
    public void Test1() { }

    [Theory]
    [InlineData(1, 2)]
    public void Sum(int a, int b) => Assert.Equal(3, a + b);
}
