namespace Modelo.Cadastros
{
    public class PagamentoProduto
    {
        public long? ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public long? FormaId { get; set; }
        public FormaPagamento FormaPagamento { get; set; }

    }
}
