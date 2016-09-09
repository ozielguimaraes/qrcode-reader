using System;
using System.Threading;

namespace FomeLine.Models
{
    public class Produto
    {
        public Produto() { }
        
        public int ProdutoId { get; set; }

        public string Nome { get; private set; }

        public string Imagem { get; private set; }

        public decimal Valor { get; private set; }
        
        public int UnidadeDeMedidaId { get; set; }
       // public UnidadeDeMedida UnidadeDeMedida { get; set; }

        public int CategoriaId { get; set; }
        //public Categoria Categoria { get; set; }

        public void SetInformation(string nome, string imagem, decimal valor)
        {
            Nome = nome;
            Imagem = imagem;
            Valor = valor;
        }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Nome)) throw new Exception("Nome Obrigatório");
            if (string.IsNullOrEmpty(Imagem)) throw new Exception("Imagem Obrigatório");
            if (Valor == 0) throw new Exception("Valor Obrigatório");
            return true;
        }
    }
}