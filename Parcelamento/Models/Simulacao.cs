using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Parcelamento.Models
{
    public class Simulacao
    {
        [JsonProperty("vlrDebito")]
        public decimal ValorDebito { get; protected set; }

        [JsonProperty("numParcelas")]
        public int NumParcelas { get; protected set; }

        [JsonProperty("vlrCorrecao")]
        public decimal TotalCorrecao { get; protected set; }

        [JsonProperty("vlrTotal")]
        public decimal TotalParcelamento { get; protected set; }

        [JsonProperty("parcelas")]
        public List<Parcela> Parcelas { get; protected set; }


        public Simulacao (decimal vlrDebito, int nParcelas)
        {
            ValorDebito = vlrDebito;
            NumParcelas = nParcelas;
            Parcelas = CalculaParcelas(NumParcelas);
        }

        private List<Parcela> CalculaParcelas(int nParcelas)
        {
            DateTime vencimento = DateTime.Now;
            decimal saldoRestante = ValorDebito;
            decimal parcelaInicial = ValorDebito / nParcelas;
            List<Parcela> listaParcelas = new List<Parcela>();

            for (int i = 0; i<nParcelas; i++)
            {
                vencimento = ProximoVencimento(vencimento);
                decimal parcelaAtual = saldoRestante / (nParcelas-i);
                decimal correcao = parcelaAtual - parcelaInicial;
                Parcela novaParcela = new Parcela(i+1, vencimento, saldoRestante, parcelaAtual, saldoRestante-parcelaAtual, correcao);
                listaParcelas.Add(novaParcela);
                saldoRestante = (saldoRestante - parcelaAtual) * (decimal)1.01;

                TotalParcelamento += parcelaAtual;
                TotalCorrecao += correcao;
            }

            ValorDebito = Math.Truncate(100 * ValorDebito) / 100;
            TotalParcelamento = Math.Truncate(100 * TotalParcelamento) / 100;
            TotalCorrecao = Math.Truncate(100 * TotalCorrecao) / 100;

            return listaParcelas;
        }

        private DateTime ProximoVencimento (DateTime ultimoVenc)
        {
            int mes = ultimoVenc.Month;
            int ano = ultimoVenc.Year;

            if (ultimoVenc.Month == 12)
            {
                mes = 1;
                ano++;
            }
            else
            {
                mes++;
            }

            string vencString = "15/" + mes + "/" + ano;
            return Convert.ToDateTime(vencString);
        }
    }
}
