using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.CodeFirst.WebApi.Domains
{
    public class JogoDomain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [Column("NomeJogo", TypeName = "varchar(150)")]
        public string NomeJogo { get; set; }
        [Required]
        [Column("Descricao", TypeName = "text")]
        public string Descricao { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [DataType(DataType.Currency)]
        [Required]
        //Gravação
        public int EstudioId { get; set; }
        [ForeignKey("EstudioId")]
        //Leitura
        public EstudioDomain Estudio { get; set; }
    }
}
