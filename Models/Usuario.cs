using System.Reflection.Metadata.Ecma335;

namespace MaisDinheiro.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }
    }
}