using System;
using System.Collections.Generic;

namespace Senai.InLock.DataBaseFirst.WebApi.Domains
{
    public partial class Estudios
    {
        public Estudios()
        {
            Jogos = new HashSet<Jogos>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Jogos> Jogos { get; set; }
    }
}
