namespace Modelo.CadastrosBLL

//BLL – Camada de Regra de negócios(Business Logic Layer)

{
    public class ProdutoStatus
    {
        public long? ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public long? StatusId { get; set; }
        public StatusCompra StatusCompra { get; set; }

    }
}
