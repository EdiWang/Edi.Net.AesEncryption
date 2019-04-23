using NUnit.Framework;

namespace Edi.Net.AesEncryption.Test
{
    public class Tests
    {
        private IAesEncryptionService AesEncryptionService { get; set; }

        private string TestIv { get; set; }

        private string TestKey { get; set; }

        [SetUp]
        public void Setup()
        {
            TestIv = "GiiGET+npv5LokSwqzHQUQ==";
            TestKey = "E8tpN2VgSjiZAF0Evl7C3fv0XOZHZFw2b+piYMl99C8=";
        }

        [Test]
        public void TestKeyInfoCreation()
        {
            var keyInfo = new KeyInfo();
            AesEncryptionService = new AesEncryptionService(keyInfo);
            Assert.IsNotNull(AesEncryptionService.KeyInfo);
            Assert.IsNotNull(AesEncryptionService.KeyInfo.KeyString);
            Assert.IsNotNull(AesEncryptionService.KeyInfo.IVString);
        }

        [Test]
        public void TestEncryption()
        {
            var keyInfo = new KeyInfo(TestKey, TestIv);
            AesEncryptionService = new AesEncryptionService(keyInfo);

            var str = "Microsoft Rocks";
            var encryptedString = AesEncryptionService.Encrypt(str);
            Assert.IsNotEmpty(encryptedString);
            Assert.AreEqual("3QFJhcT2MB+/FH7T5JgWfQ==", encryptedString);
        }

        [Test]
        public void TestDecryption()
        {
            var keyInfo = new KeyInfo(TestKey, TestIv);
            AesEncryptionService = new AesEncryptionService(keyInfo);

            var enc = "3QFJhcT2MB+/FH7T5JgWfQ==";
            var str = AesEncryptionService.Decrypt(enc);
            Assert.IsNotEmpty(str);
            Assert.AreEqual("Microsoft Rocks", str);
        }
    }
}