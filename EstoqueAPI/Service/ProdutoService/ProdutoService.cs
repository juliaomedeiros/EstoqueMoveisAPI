using EstoqueAPI.DataContext;
using EstoqueAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EstoqueAPI.Service.ProdutoService
{
    public class ProdutoService : IProdutoInterface
    {
        private readonly ApplicationDbContext _context;

        public ProdutoService(ApplicationDbContext context) 
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<ProdutoModel>>> CreateProduto(ProdutoModel novoProduto)
        {
            ServiceResponse<List<ProdutoModel>> serviceResponse = new ServiceResponse<List<ProdutoModel>>();

            try
            {
                if(novoProduto == null) 
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Dados incompletos. Necessário informar os dados";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Add(novoProduto);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.ProdutosEstoque.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;

            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ProdutoModel>>> DeleteProduto(int id)
        {
            ServiceResponse<List<ProdutoModel>> serviceResponse = new ServiceResponse<List<ProdutoModel>>();

            try 
            {
                ProdutoModel p = _context.ProdutosEstoque.FirstOrDefault(x => x.Id == id);

                if (p == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Produto não localizado";
                    serviceResponse.Sucesso = false;
                }


                _context.ProdutosEstoque.Remove(p);
                await _context.SaveChangesAsync();

            
                 serviceResponse.Dados = _context.ProdutosEstoque.ToList();

            }
            catch (Exception ex) 
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<ProdutoModel>> GetProdutoById(int id)
        {
            ServiceResponse<ProdutoModel> serviceResponse = new ServiceResponse<ProdutoModel>();

            try 
            {
                ProdutoModel p = _context.ProdutosEstoque.FirstOrDefault(x => x.Id == id);

                if (p == null) 
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Produto não localizado";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = p;

            } catch(Exception ex) 
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;

            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<ProdutoModel>> GetProdutoByNome(string nome)
        {
            ServiceResponse<ProdutoModel> serviceResponse = new ServiceResponse<ProdutoModel>();

            try
            {
                ProdutoModel p = _context.ProdutosEstoque.FirstOrDefault(x => x.Nome == nome);

                if (p == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Produto não localizado";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = p;

            }
            catch (Exception ex) 
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ProdutoModel>>> GetProdutos()
        {
            ServiceResponse<List<ProdutoModel>> serviceResponse = new ServiceResponse<List<ProdutoModel>>();

            try
            {
                serviceResponse.Dados = _context.ProdutosEstoque.ToList();

                if(serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado cadastrado";
                }

            }catch (Exception ex) 
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;

            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<List<ProdutoModel>>> UpdateProduto(ProdutoModel editarproduto)
        {
            ServiceResponse<List<ProdutoModel>> serviceResponse = new ServiceResponse<List<ProdutoModel>>();

            try 
            {
                ProdutoModel p = _context.ProdutosEstoque.AsNoTracking().FirstOrDefault(x => x.Id == editarproduto.Id); // uso de no tracking pois oa usar o id como parametros deu desencontro de informações no banco


                if (p == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Produto não localizado";
                    serviceResponse.Sucesso = false;
                }

                p.DataDeAlteracao = DateTime.Now.ToLocalTime();

                _context.ProdutosEstoque.Update(editarproduto);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.ProdutosEstoque.ToList();
            }
            catch (Exception ex) 
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;

            }

            return serviceResponse;
        }
    }
}
