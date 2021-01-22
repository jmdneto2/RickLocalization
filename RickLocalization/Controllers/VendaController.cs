﻿using AutoMapper;
using RickLocalization.Domain;
using RickLocalization.Repository;
using RickLocalization.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RickLocalization.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendaController : ControllerBase
    {
        private readonly IVendaRepository _repo;
        private readonly ILogger<VendaController> _logger;
        private readonly IMapper _mapper;

        public VendaController(IVendaRepository repo = null, IMapper mapper = null)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var vendas = _repo.GetAsync(true).Result;
                var results = _mapper.Map<IEnumerable<VendaDto>>(vendas);

                return Ok(results);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet("{vendaId}")]
        public async Task<IActionResult> GetById(int vendaId)
        {
            try
            {
                var vendas = _repo.GetByIdAsync(vendaId, true).Result;
                var results = _mapper.Map<VendaDto>(vendas);

                return Ok(results);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult<Venda>> Post(VendaDto dados)
        {
            try
            {
                var pedido = new Pedido();
                var pedidos = new List<Pedido>();
                Venda venda;
                foreach (var pedidoDto in dados.Pedidos)
                {
                    //Converte DTO para classe do domínio
                    var itensParaValidar = _mapper.Map<Item[]>(pedidoDto.Itens);

                    var itens = new List<Item>();

                    foreach (var item in itensParaValidar)
                    {
                        var produto = _repo.GetProdutoByIdAsync(item.ProdutoId).Result;
                        itens.Add(new Item(produto, item.Quantidade));
                    }

                    var resultadoInclusaoItens = pedido.AdicionarItens(itens);

                    if (resultadoInclusaoItens.Item1)
                    {
                        pedidos.Add(pedido);
                    }
                }

                //var venda = _mapper.Map<Venda>(dados); --desabilitando esta linha por enquanto pois precisa implementar validacao de dados recebidos
                venda = new Venda(pedidos);                
                var listaProdutos = _mapper.Map<Produto[]>(_repo.GetProdutosAsync().Result);

                foreach (var itens in venda.Pedidos)
                {
                    foreach (var item in itens.Itens)
                    {
                        item.NomeProduto = listaProdutos.Where(p => p.ProdutoId == item.ProdutoId).Select(x => x.Nome).FirstOrDefault().ToString();
                        item.QtdMaxPorCliente = listaProdutos.Where(p => p.ProdutoId == item.ProdutoId).Select(x => x.QtdMaxPorCliente).FirstOrDefault();
                        item.Produto = null;

                    }
                }

                _repo.Add(venda);



                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/venda/{venda.VendaID}", venda);
                }
                else
                {
                    return BadRequest("Erro ao criar venda");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
