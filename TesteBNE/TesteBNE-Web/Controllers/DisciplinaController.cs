using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TesteBNE_Web.Controllers
{
    public class DisciplinaController : Controller
    {
        // GET: Disciplina
        public ActionResult IndexDisciplina()
        {
            return View();
        }
        public ActionResult CadastroDisciplina() {
            return View();
        }
        public ActionResult AdicionarDisciplina()
        {
            return View();
        }
    }
}