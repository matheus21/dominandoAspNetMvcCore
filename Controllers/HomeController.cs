using Microsoft.AspNetCore.Mvc;
using MinhaDemoMvc.Models;
using System.Diagnostics;

namespace MinhaDemoMvc.Controllers
{
    /**
     *  Rotas por atributo: Definidos os nomes aqui, não funcionará o modo automatico.
     *  Adicionando a rota vazia, ele entende que deve cair nas rotas padrões.
     *  A rota vazia pode estar em somente uma classe Controller e em somente um dos metodos de cada Controller, para evitar conflitos.
     *  Uma vez definida aqui, a configuração do arquivo Program.cs será ignorada.
     */
    [Route("")]
    [Route("gestao-clientes")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("")]
        [Route("pagina-inicial")]
        /**
         * Para passar parâmetros
         * Podemos também tipar, com param:tipo
         */
        [Route("pagina-inicial/{id:int}/{categoria:guid}")]
        public IActionResult Index(int id, Guid categoria)
        {
            return View();
        }

        /**
         * Na sobrecarga de rotas (Rota pode ser chamada de vários modos), a ultima forma definida prevalece por padrão 
         */
        [Route("privacidade")]
        [Route("politica-de-privacidade")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        /**
         * Se estiver sem rota, irá conflitar com a rota vazia em 'pagina-inicial'
         * Então colocamos uma rota para erro
         */
        [Route("erro-encontrado")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}