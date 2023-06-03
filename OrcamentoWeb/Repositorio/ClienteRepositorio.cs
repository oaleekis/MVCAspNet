using OrcamentoWeb.Data;
using OrcamentoWeb.Models;

namespace OrcamentoWeb.Repositorio
{
	public class ClienteRepositorio : IClienteRepositorio
	{
		private readonly BancoContext _bancoContext;
		public ClienteRepositorio(BancoContext bancoContext) 
		{
			_bancoContext = bancoContext;
		}
        public ClienteModel ListarPorId(int id)
        {
			return _bancoContext.Clientes.FirstOrDefault(x => x.Id == id);
        }
        public List<ClienteModel> BuscarTodos()
        {
            return _bancoContext.Clientes.ToList();
        }
		public ClienteModel Adicionar(ClienteModel cliente)
		{
			_bancoContext.Clientes.Add(cliente);
			_bancoContext.SaveChanges();

			return cliente;
			
		}

        public ClienteModel Atualizar(ClienteModel cliente)
        {
            ClienteModel clienteDB = ListarPorId(cliente.Id);

			if (clienteDB == null) throw new Exception("Houve um erro na atualização do cliente");

            clienteDB.Nome = cliente.Nome;
			clienteDB.Cpf = cliente.Cpf;
			clienteDB.DataNascimento = cliente.DataNascimento;
			clienteDB.Email = cliente.Email;
			clienteDB.Telefone = cliente.Telefone;
			clienteDB.Endereco = cliente.Endereco;

			_bancoContext.Clientes.Update(clienteDB);
			_bancoContext.SaveChanges();

			return clienteDB;
        }

		public bool Apagar(int id)
		{
			ClienteModel clienteDB = ListarPorId(id);
			if (clienteDB == null) throw new Exception("Houve um erro para apagar o cliente");

			_bancoContext.Clientes.Remove(clienteDB);
			_bancoContext.SaveChanges();

			return true;
		}
	}
}
