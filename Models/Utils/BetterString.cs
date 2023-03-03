using System.Text.RegularExpressions;

namespace myown.Models.Utils
{
    public static class BetterString
    {
        private static string RemoveSpaces(this string strToRemoveSpaces)
        {
            return Regex.Replace(strToRemoveSpaces.Trim(), @"\s+", " ");
        }

        public static string UcFirst(this string needle, bool isDash = false)
        {
            char toSplit = isDash == true ? '-' : ' ';
            string[] arrWords = needle.Split(toSplit);

            string newString = String.Empty;
            for (int i = 0; i < arrWords.Length; i++)
            {
                string word = arrWords[i];
                
                newString += char.ToUpper(word[0]);
                newString += word[1 ..].ToLower();

                if (i != arrWords.Length - 1)
                    newString += isDash == true ? '-' : ' ';
            }
            
            return newString;
        }

        private static string CreateNewFormattedName(string[] arrNames, string[] specificNames, string[] prepositions)
        {
            const string REGEX_TO_COMPARE = @"(mac|mc)([^aeiouAEIOU]{1})";
            string formattedName = String.Empty;

            foreach(var name in arrNames)
            {
                if (arrNames.First() != name && prepositions.Contains(name.ToLower()))
                {
                    formattedName += name.ToLower();
                    continue;
                }
                if (name[0..2].ToUpper() == "O'")
                {
                    formattedName += name[..3].ToUpper() + name[3..].ToLower();
                    continue;
                }
                if (specificNames.Contains(name.ToLower()))
                {
                    char[] chars = { char.ToUpper(name[0]), char.ToLower(name[1]), char.ToUpper(name[2]) };
                    formattedName += new string(chars) + name[3..].ToLower();
                    continue;
                }
                if (name.Length > 3 && Regex.IsMatch(name[..3].ToLower(), REGEX_TO_COMPARE))
                {
                    char[] chars = { char.ToUpper(name[0]), char.ToLower(name[1]), char.ToUpper(name[2]) };
                    formattedName += new string(chars) + name[3..].ToLower();
                    continue;
                }
                if (name.Length > 4 && Regex.IsMatch(name[..4].ToLower(), REGEX_TO_COMPARE))
                {
                    formattedName += char.ToUpper(name[0]) + name[1..2].ToLower() + char.ToUpper(name[3]) + name[4..].ToLower();
                    continue;
                }
                
                formattedName += char.ToUpper(name[0]) + name[1..].ToLower();
                
                formattedName += arrNames.Last() == name ? "" : " ";
            }

            return formattedName;
        }

        public static string FormatName(this string notFormattedName)
        {
            string nameWithoutExtraSpaces = notFormattedName.RemoveSpaces();
            string[] arrNames = nameWithoutExtraSpaces.Split(" ");
            string[] specificNames = {
                "dicaprio", "distefano", "lebron", "labrie"
            };
            string[] prepositions = {
                "di", "da", "das", "do", "dos", "de", "e", "von", "van", "le", "la", "du", "des", "del", "della", "der", "al"
            };
            
            string formattedName = CreateNewFormattedName(arrNames, specificNames, prepositions);
            return formattedName;
        }

        private static string TakeOnlyCorrectLenghtOfNumbers(string documentWithoutExtraSpaces, bool isCnpj = false)
        {
            string aux = String.Empty;
            int maxLength = isCnpj == true ? 14 : 11;

            for (int i = documentWithoutExtraSpaces.Length-1, j = 0; i >= 0 && j < maxLength; i--) {
                int num;
                if (int.TryParse(documentWithoutExtraSpaces[i].ToString(), out num)) {
                    aux = documentWithoutExtraSpaces[i].ToString() + aux;
                    j++;
                }
            }

            return aux.PadLeft(maxLength, '0');
        }

        public static string FormatCpf(this string notFormattedCpf)
        {
            string cpfWithoutExtraSpaces = notFormattedCpf.RemoveSpaces();
            string cpfAux = TakeOnlyCorrectLenghtOfNumbers(cpfWithoutExtraSpaces);
            string formattedCpf = cpfAux[0..3] + '.' + cpfAux[3..6] + '.' + cpfAux[6..9] + '-' + cpfAux[9..];
            
            return formattedCpf;
        }

        public static string FormatCnpj(this string notFormattedCnpj)
        {
            string cnpjWithoutExtraSpaces = notFormattedCnpj.RemoveSpaces();
            string cnpjAux = TakeOnlyCorrectLenghtOfNumbers(cnpjWithoutExtraSpaces, true);
            string formattedCnpj = cnpjAux[..2] + '.' + cnpjAux[2..5] + '.' + cnpjAux[5..8] + '/' + cnpjAux[8..12] + '-' + cnpjAux[12..];
            
            return formattedCnpj;
        }
    }
}