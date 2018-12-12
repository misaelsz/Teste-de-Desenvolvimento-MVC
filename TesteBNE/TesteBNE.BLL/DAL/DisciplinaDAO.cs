using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteBNE.BLL.DTO;

namespace TesteBNE.BLL.DAL
{
    public static class DisciplinaDAO
    {

        #region consultas
        //comandos sql
        public const string spListarDisciplinas = "SELECT * FROM dbo.Disciplinas";
        public const string spBuscarPorId = "SELECT * FROM dbo.Disciplinas WHERE ID = @ID";
        public const string spInsertDisciplina = "INSERT INTO dbo.Disciplinas VALUES(@Nome_Discilpina)";
        public const string spUpdateDisciplina = "UPDATE dbo.Disciplinas SET Nome_Disciplina = @Nome_Disciplina WHERE ID = @ID";
        public const string spDeleteDisciplina = "DELETE dbo.Disciplinas WHERE ID = @ID";
        #endregion
        #region Metodos
        public static bool CadastrarDisciplina(Disciplina disciplina)
        {


            //string connectionString = Helper.ConnectionValue("TesteBNE_DB").ToString();
            using (SqlConnection conn = new SqlConnection("data source=CQI-DEV-1100\\SQLEXPRESS01;initial catalog=TesteBNE_DB;persist security info=True; Integrated Security = SSPI; "))
            {
                conn.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand(spInsertDisciplina, conn))
                    {
                        command.Parameters.Add(new SqlParameter("Nome_Aluno", disciplina.Nome_Disciplina));
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

        public static List<Aluno> ListarDisciplina()
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
        public static Aluno ListarDisciplinaPorId(int id)
        {
            try
            {
                Aluno aluno = new Aluno();
                using (SqlConnection conn = new SqlConnection("data source=CQI-DEV-1100\\SQLEXPRESS01;initial catalog=TesteBNE_DB;persist security info=True; Integrated Security = SSPI; "))
                {

                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(spBuscarPorId, conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("ID", id));
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

        public static bool AlterarDisciplina(int id, Aluno aluno)
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
                        cmd.Parameters.Add(new SqlParameter("ID", id));
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

        public static bool DeletarDisciplina(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("data source=CQI-DEV-1100\\SQLEXPRESS01;initial catalog=TesteBNE_DB;persist security info=True; Integrated Security = SSPI; "))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(spDeleteAluno, conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("ID", id));
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
