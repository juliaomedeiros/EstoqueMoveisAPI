using EstoqueAPI.Models;

namespace EstoqueAPI.Service.ProdutoService
{
    public interface IProdutoInterface
    {
        Task<ServiceResponse<List<ProdutoModel>>> GetProdutos();
        Task<ServiceResponse<List<ProdutoModel>>> CreateProduto(ProdutoModel novoProduto);
        Task<ServiceResponse<ProdutoModel>> GetProdutoByNome(string nome);
        Task<ServiceResponse<ProdutoModel>> GetProdutoById(int id);
        Task<ServiceResponse<List<ProdutoModel>>> UpdateProduto(ProdutoModel editarProduto);
        Task<ServiceResponse<List<ProdutoModel>>> DeleteProduto(int id);
    }
}
