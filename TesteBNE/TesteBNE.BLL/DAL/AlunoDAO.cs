using System;
using System.Collections.Generic;
using System.Configuration;
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
        public const string spBuscarPorId = "SELECT * FROM dbo.ALUNOS WHERE ID_ALUNO = @ID_ALUNO";
        public const string spInsertAluno = "INSERT INTO dbo.Alunos VALUES(@Nome_Aluno)";
        public const string spUpdateAluno = "UPDATE dbo.Alunos SET Nome_Aluno = @Nome_Aluno WHERE ID_ALUNO = @ID_ALUNO";
        public const string spDeleteAluno = "DELETE dbo.Alunos WHERE ID_ALUNO = @ID_ALUNO";
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

        public static List<Aluno> ListarAlunos()
        {
            List<Aluno> alunos = new List<Aluno>();
            
            try
            {

                using (SqlConnection conn = new SqlConnection("data source=CQI-DEV-1100\\SQLEXPRESS01;initial catalog=TesteBNE_DB;persist security info=True; Integrated Security = SSPI; "))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(spListarAlunos, conn))
                    {
                       
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Aluno aluno = new Aluno();
                            aluno.ID = reader.GetInt32(0);
                            aluno.Nome_Aluno = reader.GetString(1);
                            alunos.Add(aluno);
                        }
                        
                    }
                   
                }
                return alunos;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public static Aluno ListarALunoPorId(int id) {
            try
            {
                Aluno aluno = new Aluno();
                using (SqlConnection conn = new SqlConnection("data source=CQI-DEV-1100\\SQLEXPRESS01;initial catalog=TesteBNE_DB;persist security info=True; Integrated Security = SSPI; "))
                {
                    
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(spBuscarPorId, conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("ID_ALUNO", id));
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            
                            aluno.ID = reader.GetInt32(0);
                            aluno.Nome_Aluno = reader.GetString(1);
                            
                        }

                    }

                }
                return aluno;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public static bool AlterarAluno(int id, Aluno aluno)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(/*ConfigurationManager.ConnectionStrings["TesteBNE_DB"].ConnectionString*/
                    "data source=CQI-DEV-1100\\SQLEXPRESS01;initial catalog=TesteBNE_DB;persist security info=True; Integrated Security = SSPI; "
                    ))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(spUpdateAluno, conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("ID_ALUNO", id));
                        cmd.Parameters.Add(new SqlParameter("Nome_Aluno", aluno.Nome_Aluno));
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                    
            }
            catch (Exception)
            {

                return false;
            }
        }

        public static bool DeletarAluno(int id) {
            try
            {
                using (SqlConnection conn = new SqlConnection("data source=CQI-DEV-1100\\SQLEXPRESS01;initial catalog=TesteBNE_DB;persist security info=True; Integrated Security = SSPI; "))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(spDeleteAluno, conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("ID_ALUNO", id));
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        #endregion
    }
}
