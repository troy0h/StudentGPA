using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace StudentGPA
{
    class SQL
    {
        static readonly string ConnectionString =
                        "Data Source=desktop-sa03gi7;" +
                        "Initial Catalog=StudentGPA;" +
                        "Integrated Security=SSPI;";
        public static SqlConnection conn = new(ConnectionString);

        public static string ID(int length)
        {
            // Random numbers of length length
            // Used for UserID
            const string numbers = "1234567890";
            var res = new StringBuilder(length);
            using (var rng = new RNGCryptoServiceProvider())
            {
                int count = (int)Math.Ceiling(Math.Log(numbers.Length, 2) / 8.0);
                Debug.Assert(count <= sizeof(uint));
                int offset = BitConverter.IsLittleEndian ? 0 : sizeof(uint) - count;
                int max = (int)(Math.Pow(2, count * 8) / numbers.Length) * numbers.Length;
                byte[] uintBuffer = new byte[sizeof(uint)];
                while (res.Length < length)
                {
                    rng.GetBytes(uintBuffer, offset, count);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    if (num < max)
                    {
                        res.Append(numbers[(int)(num % numbers.Length)]);
                    }
                }
            }
            return res.ToString();
        }
    }
}
