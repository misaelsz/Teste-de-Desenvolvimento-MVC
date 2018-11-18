using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteBNE.BLL.DTO;

namespace TesteBNE.BLL.DAL
{
    public static class AlunoDAO
    {

        #region consultas
        //comandos sql
        public const string spListarAlunos= "SELECT * FROM dbo.ALUNOS";
        public const string spBuscarPorId = "SELECT * FROM dbo.ALUNOS WHERE ID = @id";
        public const string spInsertAluno = "INSERT INTO dbo.ALUNOS VALUES(@Nome_Aluno)";
        #endregion
        #region Metodos
        public static bool CadastrarAluno(Aluno aluno) {

            using (SqlConnection conn = new SqlConnection(Helper.ConnectionValue("TesteBNE_DB").ToString())) 
            {
                conn.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand(spInsertAluno, conn)) {
                        command.Parameters.Add(new SqlParameter("Nome_Aluno", aluno.Nome_Aluno));
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception e){
                    //falta fazer o tratamento da excessao
                    return false;
                }
            }
        }
        #endregion
    }
}
