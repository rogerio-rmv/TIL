using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _conext;

        public ProdutosController(AppDbContext conext)
        {
            _conext = conext;
        }

        [HttpGet]
        public  ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = _conext.Produtos.AsNoTracking().ToList();

            if(produtos is null)
            {
                return NotFound("Produtos não encontrados...");
            }

            return produtos;
        }

        [HttpGet("{id:int}", Name="ObterProduto")]
        public ActionResult<Produto> GetProduto(int id)
        {
            var produto = _conext.Produtos.AsNoTracking().FirstOrDefault(p => p.ProdutoId == id);

            if(produto is null)
            {
                return NotFound("Produto não encontrado...");
            }

            return produto;
        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if (produto is null)
                return BadRequest();

            _conext.Produtos.Add(produto);
            _conext.SaveChanges();
            return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto); //retorna 201
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest(); // retorna erro 400
            }

            _conext.Entry(produto).State = EntityState.Modified;
            _conext.SaveChanges();

            return Ok(produto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            if (id == 0)
                return BadRequest();

            var produto = _conext.Produtos.FirstOrDefault(p => p.ProdutoId == id);

            if (produto is null)
                return NotFound("Produto não localizado...");

            _conext.Produtos.Remove(produto);
            _conext.SaveChanges();

            return Ok();
        }
    }
}
