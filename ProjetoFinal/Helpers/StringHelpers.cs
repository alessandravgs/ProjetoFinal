using System.Text.RegularExpressions;

namespace ProjetoFinal.Helpers
{
    public static class StringHelpers
    {
        public static bool IsValidCPF(string cpf)
        {
            // Remove qualquer caractere que não seja dígito
            cpf = Regex.Replace(cpf, @"[^\d]", "");

            // Verifica se o CPF tem 11 dígitos
            if (cpf.Length != 11 || !long.TryParse(cpf, out _))
                return false;

            // Verifica se todos os dígitos são iguais (caso 111.111.111-11, por exemplo)
            if (new string(cpf[0], 11) == cpf)
                return false;

            // Calcula o primeiro dígito verificador
            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                sum += (cpf[i] - '0') * (10 - i);
            }
            int remainder = sum % 11;
            int firstDigit = remainder < 2 ? 0 : 11 - remainder;

            // Verifica o primeiro dígito verificador
            if (firstDigit != (cpf[9] - '0'))
                return false;

            // Calcula o segundo dígito verificador
            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += (cpf[i] - '0') * (11 - i);
            }
            remainder = sum % 11;
            int secondDigit = remainder < 2 ? 0 : 11 - remainder;

            // Verifica o segundo dígito verificador
            return secondDigit == (cpf[10] - '0');
        }

        public static string GetNumbers(this string value)
        {
            return !string.IsNullOrWhiteSpace(value) ? Regex.Replace(value, "\\D", "") : string.Empty;
        }

        public static string GetLetters(this string value)
        {
            return !string.IsNullOrWhiteSpace(value) ? Regex.Replace(value, "\\d", "") : string.Empty;
        }

        public static string GetFormattedCpf(this string value)
        {
            var numbers = value.GetNumbers();
            return $@"{long.Parse(numbers):000\.000\.000\-00}";
        }

        public static string FormatTelefoneMovel(string ddd, string fone)
        {
            return string.Format("({0}) {1:00000-0000}", ddd, long.Parse(fone));
        }
    }
}
