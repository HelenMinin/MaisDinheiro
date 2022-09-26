using System;
using MaisDinheiro.Enums;

namespace MaisDinheiro.ViewModels
{
    public class CriarDespesaViewModel
    {
        public string Nome { get; set; }
        public long Valor { get; set; }
        public DateTime Vencimento { get; set; }
        public Categoria Categoria{ get; set; }
        public Status Status { get; set; }
        public bool IsRecorrente { get; set; }
    }
}