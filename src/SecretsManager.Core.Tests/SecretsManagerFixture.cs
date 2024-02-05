namespace SecretsManager.Core.Tests;

public class SecretsManagerFixture
{
    private readonly SecretsManager _underTest;

    public SecretsManagerFixture()
    {
        _underTest = new SecretsManager();   
    }

    [Fact]
    public void CanRegisterCustomSecretSource()
    {
        // Arrange
        var customSecretSource = new Mock<ISecretSource>().Object;
        var key = "test";

        // Act
        _underTest.RegisterSecretSource(key,customSecretSource);

        // Assert
        Assert.Contains(customSecretSource, _underTest.SecretSources.Values);
    }
}