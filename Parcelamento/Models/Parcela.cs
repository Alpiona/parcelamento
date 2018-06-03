using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcelamento.Models
{
    public class Parcela
    {
        [JsonProperty("numParcela")]
        public int NumeroParcela { get; }

        [JsonProperty("datVencimento")]
        public DateTime Vencimento { get; }

        [JsonProperty("vlrSaldoAtualizado")]
        public decimal SaldoAtualizado { get; }

        [JsonProperty("vlrParcela")]
        public decimal ValorParcela { get; }

        [JsonProperty("vlrSaldoRemanescente")]
        public decimal SaldoRemanescente { get; }

        [JsonProperty("vlrCorrecao")]
        public decimal CorrecaoParcela { get; }


        public Parcela(int nParcela, DateTime vencimento, decimal saldoAtualizado, decimal parcelaAtual, decimal saldoRestante, decimal correcao)
        {
            NumeroParcela = nParcela;
            Vencimento = vencimento;
            SaldoAtualizado = Math.Truncate(100 * saldoAtualizado) / 100;
            ValorParcela = Math.Truncate(100 * parcelaAtual) / 100;
            SaldoRemanescente = Math.Truncate(100 * saldoRestante) / 100;
            CorrecaoParcela = Math.Truncate(100 * correcao) / 100;
        }
    }
}
