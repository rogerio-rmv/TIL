using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using LanchesMac.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
   
    public class CarrinhoCompraController : Controller
    {
        private readonly ILancheRepository _lancheRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(ILancheRepository lancheRepository, CarrinhoCompra carrinhoCompra)
        {
            _lancheRepository = lancheRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        public IActionResult Index()
        {
            _carrinhoCompra.CarrinhoCompraItens = _carrinhoCompra.GetCarrinhoCompraItens();

            var carrinhoCompraViewModel = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra
            };

            return View(carrinhoCompraViewModel);
        }

        [Authorize]
        public IActionResult AdicionarItemNoCarrinhoCompra(int lancheId)
        {
            var lacheSelecionado = _lancheRepository.GetLancheById(lancheId);

            if(lacheSelecionado != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(lacheSelecionado);
            }

            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult RemoverItemDoCarrinhoCompra(int lancheId)
        {
            var lacheSelecionado = _lancheRepository.GetLancheById(lancheId);

            if(lacheSelecionado != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(lacheSelecionado);
            }

            return RedirectToAction("Index");
        }
    }
}
