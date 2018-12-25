namespace DnnSummit.Manager.Interfaces
{
    public interface ISecretsManager
    {
        string this[string name] { get; }
    }
}
