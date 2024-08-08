using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    public class OperacoesHistorico
    {
        public string Nome { get; set; }
        public float Resultado { get; set; }
        [Key]
        public DateTime Data { get; set; }
    }
}
