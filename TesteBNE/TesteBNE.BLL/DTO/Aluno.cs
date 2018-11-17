using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteBNE.BLL.DTO
{
    [Table("Alunos")]
  public class Aluno
    {
        [Key]
        public Guid ID { get; set; }
        public String Nome_Aluno { get; set; }
        public List<Disciplina> ListaDisciplinas { get; set; }
    }
}
