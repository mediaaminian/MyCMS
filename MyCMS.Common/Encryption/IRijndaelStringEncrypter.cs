using System;

namespace MyCMS.Utilities.Encryption
{
    public interface IRijndaelStringEncrypter : IDisposable
    {
        string Encrypt(string value);
        string Decrypt(string value);
    }
}
