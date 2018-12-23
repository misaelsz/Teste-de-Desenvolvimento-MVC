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
        public const string spBuscarPorAluno = "SELECT * FROM dbo.DISCIPLINAS WHERE ID_ALUNO = @ID_ALUNO";
        public const string spBuscarPorId = "SELECT * FROM dbo.Disciplinas WHERE ID_DISCIPLINA = @ID_DISCIPLINA";
        public const string spBuscarNaoRelacionadas = "SELECT * FROM dbo.DISCIPLINAS WHERE ID_ALUNO IS NULL OR ID_ALUNO <> @ID_ALUNO";
        public const string spInsertDisciplina = "INSERT INTO dbo.DISCIPLINAS(NOME_DISCIPLINA, ID_ALUNO) VALUES(@Nome_disciplina, NULL);";
        public const string spUpdateDisciplina = "UPDATE dbo.Disciplinas SET NOME_DISCIPLINA = @Nome_Disciplina, ID_ALUNO = @ID_ALUNO WHERE ID_DISCIPLINA = @ID_DISCIPLINA";
        public const string spDeleteDisciplina = "DELETE dbo.Disciplinas WHERE ID_DISCIPLINA = @ID_DISCIPLINA";
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

                        command.Parameters.Add(new SqlParameter("Nome_Disciplina", disciplina.Nome_Disciplina));
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

        public static List<Disciplina> ListarDisciplinas()
        {
            List<Disciplina> disciplinas = new List<Disciplina>();

            try
            {

                using (SqlConnection conn = new SqlConnection("data source=CQI-DEV-1100\\SQLEXPRESS01;initial catalog=TesteBNE_DB;persist security info=True; Integrated Security = SSPI; "))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(spListarDisciplinas, conn))
                    {

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Disciplina disciplina = new Disciplina();
                            disciplina.ID = reader.GetInt32(0);
                            disciplina.Nome_Disciplina = reader.GetString(1);
                            // disciplina.ID_Aluno = reader.GetInt32(2);
                            disciplinas.Add(disciplina);
                        }

                    }

                }
                return disciplinas;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public static Disciplina ListarDisciplinaPorId(int id)
        {
            try
            {
                Disciplina disciplina = new Disciplina();
                using (SqlConnection conn = new SqlConnection("data source=CQI-DEV-1100\\SQLEXPRESS01;initial catalog=TesteBNE_DB;persist security info=True; Integrated Security = SSPI; "))
                {

                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(spBuscarPorId, conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("ID_DISCIPLINA", id));
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {

                            disciplina.ID = reader.GetInt32(0);
                            disciplina.Nome_Disciplina = reader.GetString(1);

                        }

                    }

                }
                return disciplina;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public static List<Disciplina> ListarDisciplinasNaoRelacionadas(int id)
        {
            List<Disciplina> disciplinas = new List<Disciplina>();
            try
            {
               
                using (SqlConnection conn = new SqlConnection("data source=CQI-DEV-1100\\SQLEXPRESS01;initial catalog=TesteBNE_DB;persist security info=True; Integrated Security = SSPI; "))
                {

                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(spBuscarNaoRelacionadas, conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("ID_ALUNO", id));
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Disciplina disciplina = new Disciplina();
                            disciplina.ID = reader.GetInt32(0);
                            disciplina.Nome_Disciplina = reader.GetString(1);
                            if (!reader.IsDBNull(2))
                                disciplina.ID_Aluno = reader.GetInt32(2);

                            disciplinas.Add(disciplina);
                        }

                    }

                }
                return disciplinas;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public static List<Disciplina> ListarDisciplinasPorAluno(int id)
        {
            List<Disciplina> disciplinas = new List<Disciplina>();
            try
            {

                using (SqlConnection conn = new SqlConnection("data source=CQI-DEV-1100\\SQLEXPRESS01;initial catalog=TesteBNE_DB;persist security info=True; Integrated Security = SSPI; "))
                {

                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(spBuscarPorAluno, conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("ID_ALUNO", id));
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Disciplina disciplina = new Disciplina();
                            disciplina.ID = reader.GetInt32(0);
                            disciplina.Nome_Disciplina = reader.GetString(1);
                            if (!reader.IsDBNull(2))
                                disciplina.ID_Aluno = reader.GetInt32(2);

                            disciplinas.Add(disciplina);
                        }

                    }

                }
                return disciplinas;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public static bool AlterarDisciplina(int id, Disciplina disciplina)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(/*ConfigurationManager.ConnectionStrings["TesteBNE_DB"].ConnectionString*/
                    "data source=CQI-DEV-1100\\SQLEXPRESS01;initial catalog=TesteBNE_DB;persist security info=True; Integrated Security = SSPI; "
                    ))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(spUpdateDisciplina, conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("ID_DISCIPLINA", id));
                        cmd.Parameters.Add(new SqlParameter("Nome_Disciplina", disciplina.Nome_Disciplina));
                        cmd.Parameters.Add(new SqlParameter("ID_ALUNO", disciplina.ID_Aluno));
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

        public static bool DeletarDisciplina(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("data source=CQI-DEV-1100\\SQLEXPRESS01;initial catalog=TesteBNE_DB;persist security info=True; Integrated Security = SSPI; "))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(spDeleteDisciplina, conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("ID_DISCIPLINA", id));
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
