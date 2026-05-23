using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria.DTO
{
    public class PagamentoDTO
    {
        public int ContaId { get; set; }

        public decimal Valor { get; set; }

        public string MetodoPagamento { get; set; } = string.Empty;
    }
}
