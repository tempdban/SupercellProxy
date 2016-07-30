using System;
using System.Net;

namespace SupercellProxy
{
    class Keys
    {
        private static WebClient KeyDownloader = new WebClient();

        /// <summary>
        /// The generated private key, according to the modded public key.
        /// </summary>
        public static byte[] GeneratedPrivateKey;
            //=> "1891d401fadb51d25d3a9174d472a9f691a45b974285d47729c45c6538070d85".ToByteArray();

        /// <summary>
        /// The modded public key.
        /// </summary>
        public static byte[] ModdedPublicKey;
        
            //=> ("72f1a4a4c48e44da0c42310f800e96624e6dc6a641a9d41c3b5039d8dfadc27e")//.ToByteArray();
    


        /// <summary>
        /// The original, unmodified public key.
        /// </summary>
        public static byte[] OriginalPublicKey { get; set; }


        /// <summary>
        /// Downloads the latest public keys from InfinityModding
        /// </summary>
        public static void DownloadPublicKey()
        {
            try
            {
                if (Config.Game == Game.BOOM_BEACH)
                    OriginalPublicKey = KeyDownloader.DownloadString("https://goo.gl/qYJSYW").ToByteArray();
                else if (Config.Game == Game.CLASH_OF_CLANS)
                    OriginalPublicKey = KeyDownloader.DownloadString("https://goo.gl/ubYKf1").ToByteArray();
                else
                    OriginalPublicKey = KeyDownloader.DownloadString("https://goo.gl/8PO34o").ToByteArray();

                Logger.Log("Public key for " + Config.Game + " downloaded!");
                Logger.Log("    => " + OriginalPublicKey.ToHexString());
            }
            catch(Exception ex)
            {
                Logger.Log("Failed to download the latest public key!");
                Logger.Log("Please check your internet connection and contact the InfinityModding support.");
                Program.WaitAndKill();
            }
        }
    }

}
