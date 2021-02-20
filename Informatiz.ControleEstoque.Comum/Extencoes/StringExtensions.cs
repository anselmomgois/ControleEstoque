using System;
using System.Text.RegularExpressions;

namespace Informatiz.ControleEstoque.Comum.Extencoes
{
    public static class StringExtensions
    {
        public const string SPACE = " ";

        public static string RemoveLineEndings(this string text)
        {
            return Regex.Replace(text, @"(\r\n?|\n)", SPACE).Trim();
        }
    }
}
