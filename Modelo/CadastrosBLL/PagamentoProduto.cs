namespace Modelo.CadastrosBLL

//BLL – Camada de Regra de negócios(Business Logic Layer)
{
    public class PagamentoProduto
    {
        public long? ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public long? FormaId { get; set; }
        public FormaPagamento FormaPagamento { get; set; }

    }
}
