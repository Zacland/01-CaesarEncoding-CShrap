using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CaesarEncoding
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Quel est le texte à coder/décoder ? ");
            string texteClair = Console.ReadLine().ToUpper();
            Console.Write("Quel est le décalage ? ");
            int decalage = int.Parse(Console.ReadLine());

            string texteCode = caesar(texteClair, decalage);
            Console.WriteLine($"Texte codé : {texteCode}");

            string texteCodeInverse = caesar(texteClair, -decalage);
            Console.WriteLine($"Texte inversé : {texteCodeInverse}");

            Console.ReadLine();
        }

        static string caesar(string texteClair, int decalage)
        {
            string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int nbCarac = caracteres.Length;
            string texteCode = "";
            foreach (char car in texteClair)
            {
                if (car != ' ')
                {
                    int pos = caracteres.IndexOf(car);
                    pos = mod((pos + decalage) , nbCarac);
                    texteCode += caracteres[pos];
                }
            }

            return formatOutput(texteCode, 5);
        }

        static string formatOutput(string texte, int regroupement)
        {
            string output = "";
            int cpt = 0;
            foreach (char c in texte)
            {
                output += c;
                cpt++;
                if (cpt >= regroupement)
                {
                    output += " ";
                    cpt = 0;
                }
            }

            return output;
        }

        // remplace le modulo "%" qui ne prend pas en compte les nombres négatifs...
        static int mod(int x, int m)
        {
            return (x % m + m) % m;
        }
    }
}
