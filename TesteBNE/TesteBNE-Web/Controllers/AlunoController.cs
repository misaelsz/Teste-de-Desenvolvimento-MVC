using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TesteBNE_Web.Controllers
{
    public class AlunoController : Controller
    {
        // GET: Aluno
        public ActionResult IndexAluno()
        {
            return View();
        }

        public ActionResult CadastroAluno()
        {
            return View();
        }
    }
}