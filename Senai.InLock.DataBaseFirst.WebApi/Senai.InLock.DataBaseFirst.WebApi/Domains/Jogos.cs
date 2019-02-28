using System;
using System.Collections.Generic;

namespace Senai.InLock.DataBaseFirst.WebApi.Domains
{
    public partial class Jogos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataLancamento { get; set; }
        public decimal Valor { get; set; }
        public int? IdEstudio { get; set; }

        public Estudios IdEstudioNavigation { get; set; }
    }
}
