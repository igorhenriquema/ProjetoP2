using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjProva2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Uma aplicação de vendas completa! " +
                "Cadastre seu Cliente, Fornecedor, Materiais, Estoque e efetue " +
                "todo o controle de vendas da sua loja!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Entre em contato conosco na aba Contato!";

            return View();
        }
    }
}