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

    [Fact]
    public void CanRegisterDefaultSecretSource()
    {
        // Arrange
        var customSecretSource = new Mock<ISecretSource>().Object;
        var key = "test";

        // Act
        _underTest.RegisterSecretSource(key,customSecretSource, true);

        // Assert
        Assert.Equal(customSecretSource, _underTest.SecretSources[key]);
        Assert.Equal(customSecretSource, _underTest.DefaultSecretSource);
    }

    [Fact]
    public void DefaultSourceIsSetIfNoneIsRegistered()
    {
        // Arrange
        var customSecretSource = new Mock<ISecretSource>().Object;
        var key = "test";

        // Act
        _underTest.RegisterSecretSource(key,customSecretSource, false);

        // Assert
        Assert.Equal(customSecretSource, _underTest.DefaultSecretSource);
    }
}