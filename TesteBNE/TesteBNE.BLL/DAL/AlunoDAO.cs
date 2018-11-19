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
        public const string spListarAlunos = "SELECT * FROM dbo.ALUNOS";
        public const string spBuscarPorId = "SELECT * FROM dbo.ALUNOS WHERE ID = @id";
        public const string spInsertAluno = "INSERT INTO dbo.Alunos VALUES(@Nome_Aluno)";
        #endregion
        #region Metodos
        public static bool CadastrarAluno(Aluno aluno)
        {


            //string connectionString = Helper.ConnectionValue("TesteBNE_DB").ToString();
            using (SqlConnection conn = new SqlConnection("data source=CQI-DEV-1100\\SQLEXPRESS01;initial catalog=TesteBNE_DB;persist security info=True; Integrated Security = SSPI; "))
            {
                conn.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand(spInsertAluno, conn))
                    {
                        command.Parameters.Add(new SqlParameter("Nome_Aluno", aluno.Nome_Aluno));
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception e)
                {
                    //falta fazer o tratamento da excessao
                    return false;
                }
            }

        }
        #endregion
    }
}
