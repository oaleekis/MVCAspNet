using Microsoft.AspNetCore.Mvc;
using OrcamentoWeb.Models;
using OrcamentoWeb.Repositorio;

namespace OrcamentoWeb.Controllers
{
    public class ClienteController : Controller
    {
		private readonly IClienteRepositorio _clienteRepositorio;
        public ClienteController(IClienteRepositorio clienteRepositorio)
        {
			_clienteRepositorio = clienteRepositorio;
		}
        public IActionResult Index()
        {
			List<ClienteModel> clientes = _clienteRepositorio.BuscarTodos();

            return View(clientes);
        }
		public IActionResult Criar()
		{
			return View();
		}
		public IActionResult Editar(int id)
		{
			ClienteModel cliente = _clienteRepositorio.ListarPorId(id);
			return View(cliente);
		}
		public IActionResult ApagarConfirmacao(int id)
		{
			ClienteModel cliente = _clienteRepositorio.ListarPorId(id);
			return View(cliente);
		}
		public IActionResult Apagar(int id)
		{
			_clienteRepositorio.Apagar(id);
			return RedirectToAction("Index");
		}
		[HttpPost]
		public IActionResult Criar(ClienteModel cliente)
		{
			_clienteRepositorio.Adicionar(cliente);
			return RedirectToAction("Index");
		}
        [HttpPost]
        public IActionResult Alterar(ClienteModel cliente)
        {
            _clienteRepositorio.Atualizar(cliente);
            return RedirectToAction("Index");
        }
    }
}
