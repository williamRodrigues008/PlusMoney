namespace PlusMoney.API.Models
{
    public class Login
    {

        public string? Usuario { get; set; }
        public string? Senha { get; set; }
        public Login() { }

        public Login(string? usuario, string? senha)
        {
            Usuario = usuario;
            Senha = senha;
        }

    }
}
