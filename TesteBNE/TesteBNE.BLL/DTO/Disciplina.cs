using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteBNE.BLL.DTO
{
    [Table("Disciplinas")]
    public class Disciplina
    {
        [Key]
        public int ID { get; set; }
        public String Nome_Disciplina { get; set; }
    }
}
