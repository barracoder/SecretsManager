
namespace SecretsManager.Core;

/// <summary>
/// The main class of the library. This class is responsible for managing secrets.
/// </summary>
public class SecretsManager
{
    private ISecretSource _defaultSecretSource;
    private IDictionary<string, ISecretSource> _secretSources;

    public SecretsManager()
    {
        _secretSources = new Dictionary<string, ISecretSource>();
    }

    public IDictionary<string,ISecretSource> SecretSources { get => _secretSources; }

    public void RegisterSecretSource(string key, ISecretSource customSecretSource, bool isDefault = false)
    {
        if (isDefault)
        {
            _defaultSecretSource = customSecretSource;
        }

        _secretSources.Add(key, customSecretSource);
    }
}
