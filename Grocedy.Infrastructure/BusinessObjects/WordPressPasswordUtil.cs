using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace GrocedyAPI.Helpers
{
    public class WordPressPasswordUtil
    {
        private static string itoa64 = "./0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        public static bool IsValid(string StrPassword,string expected)
        {
           

            string computed = MD5Encode(StrPassword, expected);

            Console.WriteLine(StrPassword);
            Console.WriteLine(computed);
            return expected.Equals(computed);
        }

        public static string MD5Encode(string password, string hash)
        {
            string output = "*0";
            if (hash == null)
            {
                return output;
            }

            if (hash.StartsWith(output))
                output = "*1";

            string id = hash.Substring(0, 3);
            // We use "$P$", phpBB3 uses "$H$" for the same thing
            if (id != "$P$" && id != "$H$")
                return output;

            // get who many times will generate the hash
            int count_log2 = itoa64.IndexOf(hash[3]);
            if (count_log2 < 7 || count_log2 > 30)
                return output;

            int count = 1 << count_log2;

            string salt = hash.Substring(4, 8);
            if (salt.Length != 8)
                return output;

            byte[] hashBytes = { };
            using (MD5 md5Hash = MD5.Create())
            {
                hashBytes = md5Hash.ComputeHash(Encoding.ASCII.GetBytes(salt + password));
                byte[] passBytes = Encoding.ASCII.GetBytes(password);
                do
                {
                    hashBytes = md5Hash.ComputeHash(hashBytes.Concat(passBytes).ToArray());
                } while (--count > 0);
            }

            output = hash.Substring(0, 12);
            string newHash = Encode64(hashBytes, 16);

            return output + newHash;
        }

        public static string Encode64(byte[] input, int count)
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            do
            {
                int value = (int)input[i++];
                sb.Append(itoa64[value & 0x3f]); // to uppercase
                if (i < count)
                    value = value | ((int)input[i] << 8);
                sb.Append(itoa64[(value >> 6) & 0x3f]);
                if (i++ >= count)
                    break;
                if (i < count)
                    value = value | ((int)input[i] << 16);
                sb.Append(itoa64[(value >> 12) & 0x3f]);
                if (i++ >= count)
                    break;
                sb.Append(itoa64[(value >> 18) & 0x3f]);
            } while (i < count);

            return sb.ToString();
        }

        public static string GetActivationLink(string userId,string email)
        {
            string salt = "TcL@#E}.)q.d@j3We+?8Lw~(l j|6oYVG#P#-iY;U&AWy2R`j+D<$}H<{B/Z1=L^!o0vrN|X55Fjl})v^A .Yt|C+*Q291Q[ofZYI$gs<QRMCBNhRTL$!.01x6;C>D@?";
            var hmacMD5 = new HMACMD5(Encoding.ASCII.GetBytes(salt));
            var saltedHash = hmacMD5.ComputeHash(Encoding.ASCII.GetBytes($"{userId},{email}"));

            Console.WriteLine();
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes($"user_id={userId}&user_email={email}&hash={BitConverter.ToString(saltedHash).Replace("-", "").ToLower()}");
           var base64 =  System.Convert.ToBase64String(plainTextBytes);
           return $"http://sylendra.tk/wp?wpforms_activate={base64}";
        }

        public static string GetForgotPasswordLink(string userId, string email,string password)
        {
            string salt = "TcL@#E}.)q.d@j3We+?8Lw~(l j|6oYVG#P#-iY;U&AWy2R`j+D<$}H<{B/Z1=L^!o0vrN|X55Fjl})v^A .Yt|C+*Q291Q[ofZYI$gs<QRMCBNhRTL$!.01x6;C>D@?";
            var hmacMD5 = new HMACMD5(Encoding.ASCII.GetBytes(salt));
            var saltedHash = hmacMD5.ComputeHash(Encoding.ASCII.GetBytes($"{userId},{email}"));

            Console.WriteLine();
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes($"user_id={userId}&user_email={email}&hash={BitConverter.ToString(saltedHash).Replace("-", "").ToLower()}");
            var base64 = System.Convert.ToBase64String(plainTextBytes);
            return $"Your password has been reset and the new Password is {password}. Please change your password on your first login.";
        }

        public static string GetUniqID()
        {
            var ts = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            double t = ts.TotalMilliseconds / 1000;

            return Convert.ToString((int)Math.Floor(t));
        }   
    }
}   
