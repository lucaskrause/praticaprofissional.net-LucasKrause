﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace DAL.Models
{
    public class Locacoes : Pai
    {
        public int codigoCliente { get; set; }

        public Clientes cliente { get; set; }

        public string nomeCliente { set { cliente ??= new Clientes(); cliente.nome = value; } }

        public int qtdePessoas { get; set; }

        public DateTime dtLocacao { get; set; }

        public decimal valor { get; set; }

        public int codigoCondicaoPagamento { get; set; }

        public CondicoesPagamento condicaoPagamento { get; set; }

        public string nomeCondicao { set { condicaoPagamento ??= new CondicoesPagamento(); condicaoPagamento.descricao = value; } }

        public List<AreasLocacao> areasLocacao { get; set; }

        public List<ContasReceber> parcelas { get; set; }

        public override string Validation()
        {
            if (this.codigoCliente <= 0)
            {
                return "Cliente obrigatório";
            }
            else if (this.qtdePessoas <= 0)
            {
                return "Quantidade de Pessoas de ser no mínimo 1";
            }
            else if (this.dtLocacao == null || this.dtLocacao.Date < DateTime.Now.AddDays(3).Date)
            {
                return "Data da Locação deve ter no mínimo 3 dias de antecedência";
            }
            else if (this.valor <= Convert.ToDecimal(0.00) || this.valor > Convert.ToDecimal(99999999.99))
            {
                return "valor deve ser entre 0.01 e 99999999.99";
            }
            else if (this.codigoCondicaoPagamento <= 0)
            {
                return "Condição de Pagamento obrigatório";
            }
            else if (this.areasLocacao == null || this.areasLocacao.Count == 0)
            {
                return "Áreas de Locação obrigatório";
            }
            else
            {
                return null;
            }
        }
    }
}
