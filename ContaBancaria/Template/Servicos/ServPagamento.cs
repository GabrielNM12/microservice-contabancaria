using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContaBancaria.Controllers;
using ContaBancaria.DTO;
using Exemplo;

namespace ContaBancaria.Servicos
{
    public class ServPagamentos
    {
        private readonly DataContext _context;

        public ServPagamentos(DataContext context)
        {
            _context = context;
        }

        public string RegistrarPagamento(PagamentoDTO dto)
        {
            var conta = _context.Contas.FirstOrDefault(x => x.Id == dto.ContaId);

            if (conta == null)
            {
                throw new Exception("Conta não encontrada");
            }

            if (!conta.Ativo)
            {
                throw new Exception("Conta inativa");
            }

            if (conta.SaldoConta < dto.Valor)
            {
                throw new Exception("Saldo insuficiente");
            }

            conta.SaldoConta -= dto.Valor;

            Pagamento pagamento = new Pagamento()
            {
                ContaId = dto.ContaId,
                Valor = dto.Valor,
                MetodoPagamento = dto.MetodoPagamento,
                DataPagamento = DateTime.Now,
                Pago = true
            };

            _context.Pagamentos.Add(pagamento);

            _context.SaveChanges();

            return "Pagamento realizado com sucesso";
        }

        public List<Pagamento> ListarPagamentos()
        {
            return _context.Pagamentos.ToList();
        }
    }
}