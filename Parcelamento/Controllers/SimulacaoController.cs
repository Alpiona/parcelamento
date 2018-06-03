using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Parcelamento.Models;

namespace Parcelamento.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SimulacaoController : Controller
    {
        // GET api/simulacao/5000/5
        [HttpGet("{debito}/{parcelas}")]
        public IActionResult Get(decimal debito, int parcelas)
        {
            if (parcelas > 60)
                return BadRequest("O número de parcelas máximo é 60");

            else if (parcelas < 2)
                return BadRequest("O número de parcelas mínimo é 2");

            Simulacao resultado = new Simulacao(debito, parcelas);

            if (resultado.ValorDebito > 2000 && resultado.Parcelas.First().ValorParcela < 200)
                return BadRequest("O valor da menor parcela não pode ser inferior a 200,00 para valor total superior a 2.000,00");

            else if (resultado.ValorDebito <= 2000 && resultado.Parcelas.First().ValorParcela < 50)
                return BadRequest("O valor da menor parcela não pode ser inferior 50,00 para valor igual ou inferior a 2.000,00");

            return Ok(resultado);
        }

        // POST api/simulacao
        [HttpPost]
        public IActionResult Post([FromBody]Simulacao resultado)
        {
            if (resultado == null)
                return BadRequest("Alguma informação está ausente, ou inválida");

            else if (resultado.NumParcelas > 60)
                return BadRequest("O número de parcelas precisa ser menor que 60");

            else if (resultado.NumParcelas < 2)
                return BadRequest("O número de parcelas precisa ser maior que 2");

            else if (resultado.ValorDebito > 2000 && resultado.Parcelas.First().ValorParcela < 200)
                return BadRequest("O valor da menor parcela não pode ser inferior a 200,00 para valor total superior a 2.000,00");

            else if (resultado.ValorDebito <= 2000 && resultado.Parcelas.First().ValorParcela < 50)
                return BadRequest("O valor da menor parcela não pode ser inferior a 50,00 para valor igual ou inferior a 2.000,00");

            return Ok(resultado);
        }
    }
}
