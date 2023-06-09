﻿using System.ComponentModel.DataAnnotations;

namespace OrcamentoWeb.Models
{
	public class ClienteModel
	{
        public int Id { get; set; }
        public string Nome { get; set; }
        public long Cpf { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public long Telefone { get; set; }
        public string Endereco { get; set; }

    }


}
