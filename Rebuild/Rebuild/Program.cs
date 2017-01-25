using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rebuild
{
    class Program
    {
        static void Main(string[] args)
        {
            string codeWord = "";
            int rot = 0;
            string alphabet = "lx'iv3d4h.ry0qm!t9ow2p7jbuz,ne561?gfkac8s";
            string key = "";
            Console.Title = "Rot Encrpytion tool";
            Console.WriteLine("Please Enter your text to encrypt.");
            Console.WriteLine("If you use anymore than '.!?, place it in the Key aswell");
            codeWord = Console.ReadLine().ToLower();
            Console.WriteLine("Enter your Rotation");
            rot = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Please Enter a key");
            key = Console.ReadLine();
            Console.Clear();
            Console.Title = "Encoded Message";

            char[] codedKey = keyCreate(key, alphabet);

            Console.WriteLine(rotEncrypt(rot, codeWord, codedKey));

            Console.WriteLine(rotDecrypt(rot,rotEncrypt(rot,codeWord,codedKey),codedKey));
            
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Please Press Enter To Quit");
            Console.ReadLine();
        }

        private static char[] keyCreate(string key,string alphabet)
        {
            key = key.Replace(" ", string.Empty);
            key = string.Concat(key,alphabet).ToLower();
            char[] keychar = key.ToCharArray();
            char[] output = new char[alphabet.Length];
            int r = 0;
            for (int i = 0; i < key.Length; i++)
            {
                if (Array.IndexOf(output, keychar[i]) == -1)
                {
                    if (Array.IndexOf(alphabet.ToCharArray(), keychar[i]) == -1)
                    {
                        Array.Resize(ref output, output.Length+ 1);
                        output[r] = keychar[i];
                        r++;
                    }
                    else
                    {
                        output[r] = keychar[i];
                        r++;
                    }
                }
            }
            
            return output;
        }

        private static string rotEncrypt(int rot, string codeWord, char[] codedKey)
        {
            string output = "";
            var codeList = codeWord.ToCharArray();
            for (int i = 0; i < codeWord.Length; i++)
            {
                if (Array.IndexOf(codedKey, codeList[i]) != -1)
                {
                    output = string.Concat(output, codedKey[(Array.IndexOf(codedKey, codeList[i]) + rot) % codedKey.Length].ToString());//Modulus % allows me to get the remainder of the sum into 26. =]
                }
                else
                {
                    output = string.Concat(output, " ");
                }
            }
            
            return output;
        }

        private static string rotDecrypt(int rot, string cipher, char[] codedKey)
        {
            string output = "";
            var codeList = cipher.ToCharArray();
            for (int i = 0; i < cipher.Length; i++)
            {
                if (Array.IndexOf(codedKey, codeList[i]) != -1)
                {
                    output = string.Concat(output, codedKey[(Array.IndexOf(codedKey, codeList[i]) + Math.Abs(codedKey.Length -(rot%codedKey.Length))) % codedKey.Length].ToString());//find the oposite side of the rotation and modulous it to 26 then modulus the total into standard format.
                }
                else
                {
                    output = string.Concat(output, " ");
                }
            }

            return output;
        }
    }
}
