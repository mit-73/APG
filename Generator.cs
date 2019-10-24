using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APG
{
    public class Generator
    {
        public string Start(string keyword, string domain, string symbol)
        {
            string password = GetLastDomainLetter(new StringBuilder(domain)) + GetSpecialSymbol(symbol) +
                              keyword +
                              keyword.Reverse().Aggregate(string.Empty, (acc, ch) => acc + ch) +
                              GetDomainLength(domain);

            return RemoveRepetitiveLetters(new StringBuilder(password), new StringBuilder(domain));
        }


        private string GetLastDomainLetter(StringBuilder domain)
        {
            string tempChar = "";

            for (int i = 0; i < domain.Length; i++)
            {
                if (domain[i] == '.')
                {
                    tempChar += domain[i-1].ToString();
                }
            }

            return tempChar.ToUpper();
        }

        private string GetSpecialSymbol(string symbol)
        {
            List<string> tempSymbols = new List<string>{ "!", "\"", "#", "$", "%", "&", "\'", "(", ")", "*", "+", ",", "-", ".", "/", ":", ";", "<", "=", ">", "?", "@", "[", "\\", "]", "^", "_", "`", "{", "|", "}", "~"};
            
            if (!Equals(symbol.ToLower(), ""))
            {
                foreach (var tempSymbol in tempSymbols)
                {
                    if (Equals(symbol.ToLower(), tempSymbol.ToLower())) return symbol;
                }
                
                return "";
            }

            return "";
        }

        private int GetDomainLength(string domain)
        {
            int count = 0;
            foreach (var letter in domain)
                if (char.IsLetter(letter))
                    count++;
            return count;
        }

        private string RemoveRepetitiveLetters(StringBuilder password, StringBuilder domain)
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