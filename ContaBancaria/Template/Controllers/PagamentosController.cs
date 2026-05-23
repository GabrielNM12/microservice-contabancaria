using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContaBancaria.DTO;
using ContaBancaria.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace ContaBancaria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PagamentosController : ControllerBase
    {
        private readonly ServPagamentos _servPagamentos;

        public PagamentosController(ServPagamentos servPagamentos)
        {
            _servPagamentos = servPagamentos;
        }

        [HttpPost]
        public IActionResult RegistrarPagamento(PagamentoDTO dto)
        {
            try
            {
                var resultado = _servPagamentos.RegistrarPagamento(dto);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult ListarPagamentos()
        {
            return Ok(_servPagamentos.ListarPagamentos());
        }
    }
}