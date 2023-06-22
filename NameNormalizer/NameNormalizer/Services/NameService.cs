using NameNormalizer.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NameNormalizer.Services
{
    public class NameService : INameService
    {
        private readonly Dictionary<Prefixes, string> _prefixes;
        public NameService()
        {
            _prefixes = InitializePrefixes();
        }
        public Task<string> NormalizeName(string fullName)
        {
            char letter;
            var result = new StringBuilder();
            string[] nameMembers = fullName.Split(' ');
            for (int i = 0; i < nameMembers.Length; i++)
            {
                var normalizedMember = new StringBuilder();
                if (CheckPrefixe(nameMembers[i].ToLower()))
                {
                    result.Append(nameMembers[i].ToLower());
                }
                else
                {
                    char[] letters = nameMembers[i].ToCharArray();
                    for (int j = 0; j < letters.Length; j++)
                    {
                        letter = (j == 0) ? Char.ToUpper(letters[j]) : Char.ToLower(letters[j]);
                        normalizedMember.Append(letter);
                    }
                }
                
                result.Append(normalizedMember);
                if(i < (nameMembers.Length-1))
                    result.Append(" ");
            }
            return Task.FromResult(result.ToString());
        }

        public Dictionary<Prefixes, string> InitializePrefixes()
        {
            var prefixes = new Dictionary<Prefixes, string>();
            foreach (Prefixes prefixeName in Enum.GetValues(typeof(Prefixes)))
            {
                prefixes.Add(prefixeName, prefixeName.ToString().ToLower());
            }

            return prefixes;
        }

        public bool CheckPrefixe(string nameMember)
        {
            bool keyExists = _prefixes.ContainsValue(nameMember);
            return keyExists;
        }
    }
}
