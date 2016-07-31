using System;
using System.Net;

namespace SupercellProxy
{
    class Keys
    {

        /// <summary>
        /// The generated private key, according to the modded public key.
        /// </summary>
        public static byte[] GeneratedPrivateKey
            => "1891d401fadb51d25d3a9174d472a9f691a45b974285d47729c45c6538070d85".ToByteArray();
<<<<<<< HEAD

=======
       
>>>>>>> origin/master

        /// <summary>
        /// The modded public key.
        /// </summary>
        public static byte[] ModdedPublicKey
<<<<<<< HEAD

=======
        
>>>>>>> origin/master
            => "72f1a4a4c48e44da0c42310f800e96624e6dc6a641a9d41c3b5039d8dfadc27e".ToByteArray();
    

        /// <summary>
        /// The original, unmodified public key.
        /// </summary>
        public static byte[] OriginalPublicKey { get; set; }


<<<<<<< HEAD
        public static void PublicKey()
        {
            try
            {
                if (Config.Game == Game.BOOM_BEACH)
                    OriginalPublicKey = "680df1a0e672b908ef988332c19d3a1669c393c005516bdba648159e964a721b".ToByteArray();
                else if (Config.Game == Game.CLASH_OF_CLANS)
                    OriginalPublicKey = "bb9ca4c6b52ecdb40267c3bcca03679201a403ef6230b9e488db949b58bc7479".ToByteArray();
                else
                    OriginalPublicKey = "2971520277bb38734fc36e2a0d95e76e969379a5372a44c1b2fd3c1766b0016a".ToByteArray();

                Logger.Log("Public key for " + Config.Game + " received!");
                Logger.Log("    => " + OriginalPublicKey.ToHexString());
            }
            catch(Exception ex)
            {
                Logger.Log("Failed to receive the latest public key!");
               
                Program.WaitAndKill();
            }
=======
        /// <summary>
        /// Downloads the latest public keys from InfinityModding
        /// </summary>
        public static void PublicKey()
        {
            if (Config.Game == Game.BOOM_BEACH)
                OriginalPublicKey = "680df1a0e672b908ef988332c19d3a1669c393c005516bdba648159e964a721b".ToByteArray();
            else if (Config.Game == Game.CLASH_OF_CLANS)
                OriginalPublicKey = "bb9ca4c6b52ecdb40267c3bcca03679201a403ef6230b9e488db949b58bc7479".ToByteArray();
            else
                OriginalPublicKey = "2971520277bb38734fc36e2a0d95e76e969379a5372a44c1b2fd3c1766b0016a".ToByteArray();
>>>>>>> origin/master
        }
    }

}
