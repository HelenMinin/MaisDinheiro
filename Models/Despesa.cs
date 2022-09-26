using System;
using System.Reflection.Metadata.Ecma335;
using MaisDinheiro.Enums;
using Microsoft.AspNetCore.Http;

namespace MaisDinheiro.Models
{
    public class Despesa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public long Valor { get; set; }
        public DateTime Vencimento { get; set; }
        public Categoria Categoria{ get; set; }
        public Status Status { get; set; }
        public bool IsRecorrente { get; set; }
    }
}