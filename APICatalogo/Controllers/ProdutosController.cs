using APICatalogo.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICatalogo.Models;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProdutoModel>> Get()
        {
            var produtos = _context.Produtos.ToList();
            if(produtos is null)
            {
                return NotFound("Produtos não encontrados!");
            }
            return produtos;
        }

        [HttpGet("{id:int}", Name="ObterProduto")]
        public ActionResult<ProdutoModel> Get(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            if(produto is null)
            {
                return NotFound("Produto não encontrado!");
            }
            return produto;
        }

        [HttpPost]
        public ActionResult Post([FromQuery]ProdutoModel produto)
        {
            if(produto is null)
            {
                return BadRequest();
            }
            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto", new 
            { id = produto.ProdutoId }, produto);

        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, ProdutoModel produto)
        {
            if(id != produto.ProdutoId)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(produto);
        }
    }
}
