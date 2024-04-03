using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalogo.Models
{
    public class ProdutoModel
    {
        [Key]
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string ImagemUrl { get; set; }
        public float Estoque { get; set; }
        public DateTime DataCadastro { get; set; }

        public int CategoriaId { get; set; }
        public CategoriaModel Categoria { get; set; }
        //Coloquei uma propriedade "CategoriaId" que mapeia para a chave estrangeira no banco de
        //dados e uma propriedade de navegação "Categoria" para indicar que um "ProdutoModel"
        //está relacionado com uma "CategoriaModel"
    }
}
