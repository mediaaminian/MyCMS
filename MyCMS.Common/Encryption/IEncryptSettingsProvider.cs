namespace MyCMS.Utilities.Encryption
{
    public interface IEncryptSettingsProvider
    {
        byte[] EncryptionKey { get; }
        string EncryptionPrefix { get; }
    }
}