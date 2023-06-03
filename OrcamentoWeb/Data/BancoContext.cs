using Microsoft.EntityFrameworkCore;
using OrcamentoWeb.Models;

namespace OrcamentoWeb.Data
{
	public class BancoContext : DbContext
	{
		public BancoContext(DbContextOptions<BancoContext> options) : base(options) 
		{
		}

		public DbSet<ClienteModel> Clientes { get; set; }
	}
}
