using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalogo.Models
{
    public class CategoriaModel
    {
        public CategoriaModel()
        {
            Produtos = new Collection<ProdutoModel>(); // boa pratica iniciar a coleção 
        }

        [Key]
        public int CategoriaId { get; set; }
        public string Nome { get; set; }
        public string ImagemUrl { get; set; }

        public ICollection<ProdutoModel>Produtos { get; set; } 
        //Propriedade de navegação para indicar que a CategoriaModel pode conter uma
        //coleção de Produtos (ProdutoModel) relacionamento entre duas entidades
        
        
    }
}
