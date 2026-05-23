using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria.Servicos
{
    public class Pagamento
    {
        public int Id { get; set; }

        public int ContaId { get; set; }

        public decimal Valor { get; set; }

        public string MetodoPagamento { get; set; }

        public DateTime DataPagamento { get; set; }

        public bool Pago { get; set; }
    }
}
