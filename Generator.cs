using System;
using System.Linq;
using System.Text;

namespace APG
{
    public class Generator
    {
        public string Start(string keyword, string domain, string symbol)
        {
            string password = LastDomainLetter(new StringBuilder(domain)).ToUpper() + GenerateSpecialSymbol(symbol) +
                              keyword +
                              keyword.Reverse().Aggregate(string.Empty, (acc, ch) => acc + ch) +
                              DomainLetterLength(domain);

            return RemoveLetters(new StringBuilder(password), new StringBuilder(domain));
        }


        private string LastDomainLetter(StringBuilder domain)
        {
            string tempChar = "";

            for (int i = 0; i < domain.Length; i++)
            {
                if (domain[i] != '.')
                {
                    tempChar = domain[i].ToString();
                }
                else break;
            }

            return tempChar;
        }

        private string GenerateSpecialSymbol(string symbol)
        {
            if (Equals(symbol.ToLower(), "yes") || Equals(symbol, "1") || Equals(symbol.ToLower(), "true")) return "!";

            return "";
        }

        private int DomainLetterLength(string domain)
        {
            int count = 0;
            foreach (var letter in domain)
                if (char.IsLetter(letter))
                    count++;
            return count;
        }

        private string RemoveLetters(StringBuilder password, StringBuilder domain)
        {
            string temp = password.ToString();

            for (int i = 0; i < password.Length; i++)
            {
                for (int j = 0; j < domain.Length; j++)
                {
                    if (password[i] == domain[j]) temp = temp.Replace(domain[j].ToString(), "");
                }
            }

            return temp;
        }
    }
}