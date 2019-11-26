using Public_Private_Key_Encryptor;
using System;
using System.IO;
using System.Reflection;

namespace Encrypt_Password_Console_App
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string _publicKey = "<RSAKeyValue><Modulus>i6BFZEiowigxEIV/2SUNUTjgslJas0Qe5pqi1qG6CZvyS25ruyZ67FHQw6mSHg22tZ/sfTBWSuS2LU+9QaqVuw==" +
                "</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

            Console.WriteLine("Please enter the Password you want to have Encrypted: ");

            string passwordPlain = Console.ReadLine();

            string passwordEncrypted = RSAController.Encrypt(passwordPlain, _publicKey);

            Console.WriteLine("");
            Console.WriteLine("Your Encrypted Password is: " + passwordEncrypted);

            string m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            try
            {
                using (StreamWriter sw = new StreamWriter(m_exePath + "\\Encrypted.txt", true))
                {
                    sw.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                    sw.WriteLine("  ");
                    sw.WriteLine("  {0}", passwordEncrypted);
                    sw.WriteLine("-------------------------------");
                }

                Console.WriteLine("Note: the Password has also been saved into the Encryptet.txt");
            }
            catch (Exception)
            {
            }

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Pressy Any Key to exit :)");

            Console.ReadKey();
        }
    }
}