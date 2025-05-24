using System.Security.Cryptography;
using System.Text;

namespace PlusMoney.API.Helpers
{
    public static class CriptografaSenha
    {
        public static string CriptografarSenha(this string senha)
        {

            var novoHash = SHA1.Create();
            var arraySenhaByte = new ASCIIEncoding().GetBytes(senha);
            arraySenhaByte = novoHash.ComputeHash(arraySenhaByte);

            var stringBuilder = new StringBuilder();

            foreach (var item in arraySenhaByte)
            {
                stringBuilder.Append(item.ToString("x2"));
            }

            return stringBuilder.ToString();
        }
    }
}
