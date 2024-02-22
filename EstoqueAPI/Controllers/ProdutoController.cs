using EstoqueAPI.Models;
using EstoqueAPI.Service.ProdutoService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoInterface _produtoInterface;
        public ProdutoController(IProdutoInterface produtoInterface) 
        {
            _produtoInterface = produtoInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ProdutoModel>>>> GetProdutos()
        {
            return Ok(await _produtoInterface.GetProdutos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<ProdutoModel>>> GetProdutoById(int id)
        {
            ServiceResponse<ProdutoModel> serviceResponse = await _produtoInterface.GetProdutoById(id);
            return Ok(serviceResponse);
        }

        [HttpGet("nomeProduto/{nome}")]
        public async Task<ActionResult<ServiceResponse<ProdutoModel>>> GetProdutoByNome(string nome)
        {
            ServiceResponse<ProdutoModel> serviceResponse = await _produtoInterface.GetProdutoByNome(nome);
            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<ProdutoModel>>>> CreateProduto(ProdutoModel novoProduto)
        {
            return Ok(await _produtoInterface.CreateProduto(novoProduto));
        }

        [HttpPut("editarProduto")]
        public async Task<ActionResult<ServiceResponse<List<ProdutoModel>>>> UpdateProduto(ProdutoModel editarproduto)
        {
            ServiceResponse<List<ProdutoModel>> serviceResponse = await _produtoInterface.UpdateProduto(editarproduto);

            return Ok(serviceResponse);
        }

        [HttpDelete("deletarProduto")]
        public async Task<ActionResult<ServiceResponse<List<ProdutoModel>>>> DeleteProduto(int id)
        {
            ServiceResponse<List<ProdutoModel>> serviceResponse = await _produtoInterface.DeleteProduto(id);

            return Ok(serviceResponse);
        }
    }
}
