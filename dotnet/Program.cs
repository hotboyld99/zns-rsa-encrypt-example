using System;
using System.IO;
using System.Text;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Crypto.Parameters;

class Program
{
    static void Main()
    {
        string text = "abc123";
        string publicKeyPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../public_key.pem");

        // 1. Load Public Key using BouncyCastle's PemReader
        RsaKeyParameters publicKey;
        using (var reader = File.OpenText(publicKeyPath))
        {
            var pemReader = new PemReader(reader);
            publicKey = (RsaKeyParameters)pemReader.ReadObject();
        }

        // 2. Setup OAEP Padding with specific hashes
        // Iencrypter engine = RsaEngine
        // Hash = Sha256Digest
        // MGF1 Hash = Sha1Digest
        var engine = new OaepEncoding(
            new RsaEngine(),
            new Sha256Digest(),
            new Sha1Digest(),
            null
        );

        engine.Init(true, publicKey);

        // 3. Encrypt
        byte[] dataToEncrypt = Encoding.UTF8.GetBytes(text);
        byte[] encryptedData = engine.ProcessBlock(dataToEncrypt, 0, dataToEncrypt.Length);

        // 4. Base64 Encode
        string res = Convert.ToBase64String(encryptedData);

        Console.WriteLine("Encrypted data: " + res);
    }
}