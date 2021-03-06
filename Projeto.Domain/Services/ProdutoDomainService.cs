﻿using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Services
{
    public class ProdutoDomainService : BaseDomainService<Produto>, IProdutoDomainService
    {
        //atributo
        private readonly IProdutoRepository produtoRepository;

        //construtor para inicializar o atributo
        public ProdutoDomainService(IProdutoRepository produtoRepository)
            : base(produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        public List<Produto> GetByNome(string nome)
        {
            return produtoRepository.GetByNome(nome);
        }
    }
}
