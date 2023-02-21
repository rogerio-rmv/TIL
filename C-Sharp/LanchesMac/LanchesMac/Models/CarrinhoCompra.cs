using LanchesMac.Context;

namespace LanchesMac.Models
{
    public class CarrinhoCompra
    {
        private readonly AppDbContext _context;

        public CarrinhoCompra(AppDbContext context)
        {
            _context = context;
        }

        public string CarrinhoCompraId { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }

        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            // Define uma sessão
            ISession session = services.GetService<IHttpContextAccessor>()?.HttpContext.Session;

            // Obtém um serviço do tipo do nosso contexto
            var context = services.GetService<AppDbContext>();

            // Obtém ou gera o Id do Carrinho
            string carrinhoId = session.GetString("CarrinhoId")?? Guid.NewGuid().ToString();

            // Atribui o id od carrinho na Sessão
            session.SetString("CarrinhoId", carrinhoId);

            // Retorna o carrinho com o contexto e o Id atribuido ou obtido
            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId
            };
        }

        public void AdicionarAoCarrinho(Lanche lanche)
        {
            // Obtém o item do carrinho conforme o id do carrinho (guid) e o lanche informado
            var carrinhoCompraItem = _context.CarrinhoCompraItens.SingleOrDefault(
                    l => l.Lanche.LancheId == lanche.LancheId &&
                    l.CarrinhoCompraId == CarrinhoCompraId
                );

            // Caso o lanche não tenha sido cadastrado para o carrinho,
            // cria um novo item para o carrinho de compras 
            // a partir do lanche informado e o id do carrinho
            if(carrinhoCompraItem== null) {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Lanche = lanche,
                    Quantidade = 1
                };

                _context.CarrinhoCompraItens.Add(carrinhoCompraItem);
            }
            else
            {
                // Caso o lacnhe já esteja no carrinho, ou seja,
                // existe o item para o lanche, soma 1 à quantidade 
                // de lanches que serão comprados
                carrinhoCompraItem.Quantidade++;
            }

            // Grava no banco de dados
            _context.SaveChanges();
        }


    }
}
