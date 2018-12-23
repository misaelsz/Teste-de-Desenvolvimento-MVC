using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TesteBNE.BLL.DAL;
using TesteBNE.BLL.DTO;

namespace TesteBNEWebAPI.Controllers
{
    [RoutePrefix("api/Disciplina")]
    public class DisciplinaController : ApiController
    {
        // GET: api/Aluno
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, DisciplinaDAO.ListarDisciplinas());
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        // GET: api/Aluno/5
        public HttpResponseMessage Get(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, DisciplinaDAO.ListarDisciplinaPorId(id));
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        //GET: 
        [Route("Vincular/{id}")]
        public HttpResponseMessage GetNaoRelacionadas(int id) {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, DisciplinaDAO.ListarDisciplinasPorAluno(id));
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        // POST: api/Aluno
        public HttpResponseMessage Post([FromBody]Disciplina disciplina)
        {
            try
            {
                bool retorno = DisciplinaDAO.CadastrarDisciplina(disciplina);
                if (retorno == false)
                    return Request.CreateResponse(HttpStatusCode.BadRequest);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        // PUT: api/Aluno/5
        public HttpResponseMessage Put(int id, [FromBody]Disciplina disciplina)
        {
            try
            {
                bool retorno = DisciplinaDAO.AlterarDisciplina(id, disciplina);
                if (retorno == false)
                    return Request.CreateResponse(HttpStatusCode.BadRequest);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        // DELETE: api/Aluno/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, DisciplinaDAO.DeletarDisciplina(id));
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
