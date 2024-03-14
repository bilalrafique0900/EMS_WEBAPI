using HeyRed.Mime;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace EmployeeSystem.Domain.Common.CommonMethod
{
    public static class CommonMethod
    {
        private static IConfiguration configuration;
        static CommonMethod()
        {
        }

        private const string DESKey = "AQWSEDRF";
        private const string DESIV = "HGFEDCBA";
        public static string DESEncrypt(string stringToEncrypt)
        {
            // Encrypt the content
            byte[] key = Convert2ByteArray(DESKey);
            byte[] IV = Convert2ByteArray(DESIV);
            byte[] inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            cs.Dispose();
            des.Dispose();
            return Convert.ToBase64String(ms.ToArray());
        }
        public static string DESDecrypt(string stringToDecrypt)
        {
            //Decrypt the content

            byte[] key = Convert2ByteArray(DESKey);

            byte[] IV = Convert2ByteArray(DESIV);

            int len = stringToDecrypt.Length;
            byte[] inputByteArray = Convert.FromBase64String(stringToDecrypt);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, (inputByteArray).Length);

            cs.FlushFinalBlock();

            Encoding encoding__1 = Encoding.UTF8;
            cs.Dispose();
            des.Dispose();
            return encoding__1.GetString(ms.ToArray());
        }
        private static byte[] Convert2ByteArray(string strInput)
        {
            char[] arrChar = strInput.ToCharArray();
            byte[] arrByte = new byte[arrChar.Length];
            int intCounter;
            for (intCounter = 0; intCounter <= arrByte.Length - 1; intCounter++)
            {
                arrByte[intCounter] = Convert.ToByte(arrChar[intCounter]);
            }
            return arrByte;
        }

        public static bool ContainsInt(string str)
        {
            string[] numbers = str.Split(',');
            foreach (string x in numbers)
            {
                int n;
                if (!int.TryParse(x, out n)) { return false; }
            }

            return true;
        }
        public static string GetFileBase64(string foldername, string ImageGuid)
        {
            string base64 = "";
            string appRoot = "";
            if (AppContext.BaseDirectory.IndexOf("bin") > 0)
                appRoot = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin") - 1);
            else
                appRoot = AppContext.BaseDirectory;
            if (File.Exists(appRoot + @"\" + foldername + @"\" + @ImageGuid))
            {
                byte[] bytes = System.IO.File.ReadAllBytes(appRoot + @"\" + foldername + @"\" + @ImageGuid);
                base64 = Convert.ToBase64String(bytes);
                base64 = "data:" + MimeTypesMap.GetMimeType(ImageGuid) + ";Base64," + base64;
            }
            return base64;
        }
        public static string AddFile(string Base64, string folder)
        {
            if (!IsBase64(Base64)) return Base64;
            string appRoot;
            string fname;
            fname = Guid.NewGuid()  + GetFileExtension(Base64);
            if (AppContext.BaseDirectory.IndexOf("bin") > 0)
                appRoot = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin") - 1);
            else
                appRoot = AppContext.BaseDirectory;
            bool exists = Directory.Exists(appRoot + @"\" + folder);
            if (!exists)
                System.IO.Directory.CreateDirectory(appRoot + @"\" + folder);
            var path = appRoot + @"\" + folder + @"\" + fname;
            int index = Base64.IndexOf(",");
            if (index > 0)
                Base64 = Base64.Substring(index + 1);
            Byte[] bytes = Convert.FromBase64String(Base64);
            File.WriteAllBytes(path, bytes);

            return fname;
        }
        public static bool IsBase64(this string base64String)
        {
            var str = "";
            if (base64String.Contains(","))
            {
                str = base64String.Split(",")[1];
            }
            else
                str = base64String;
            if (str == null || str.Length == 0 || str.Length % 4 != 0
               || str.Contains(" ") || str.Contains("\t") || str.Contains("\r") || str.Contains("\n"))
                return false;

            Convert.FromBase64String(str);
            return true;
        }
        public static string GetFileExtension(string base64String)

        {
            if (string.IsNullOrWhiteSpace(base64String))
                return "";
            var data = base64String.Substring(0, 5);

            switch (data.ToUpper())
            {

                case "UESDB":
                    return ".xlsx";

                case "/9J/4":
                    return ".jpg";

                case "JVBER":
                    return ".pdf";

                case "UMFYI":
                    return ".rar";

                case "IVBOR":
                    return ".png";

                case "AAAAF":
                    return "mp4";

                case "AAAAG":
                    return ".mp4";
                case "UEsDB":
                    return ".zip";

                default:
                    return string.Empty;
            }
        }

        public static string RandomGeneratedCode()
        {
            int codeLength = 10; // Length of the random code
            string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"; // Characters allowed in the code

            Random random = new Random();
            StringBuilder codeBuilder = new StringBuilder();

            for (int i = 0; i < codeLength; i++)
            {
                int randomIndex = random.Next(allowedChars.Length);
                char randomChar = allowedChars[randomIndex];
                codeBuilder.Append(randomChar);
            }

            return codeBuilder.ToString();
        }
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int pageNumber, int pageSize)
        {
            // Calculate the number of items to skip
            int itemsToSkip = (pageNumber - 1) * pageSize;

            // Apply pagination to the query
            IQueryable<T> paginatedQuery = query.Skip(itemsToSkip).Take(pageSize);

            return paginatedQuery;
        }
    }
}
