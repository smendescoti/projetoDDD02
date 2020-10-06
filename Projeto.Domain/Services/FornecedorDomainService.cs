using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Services
{
    public class FornecedorDomainService : BaseDomainService<Fornecedor>, IFornecedorDomainService
    {
        //atributo
        private readonly IFornecedorRepository fornecedorRepository;

        //construtor para inicialização
        public FornecedorDomainService(IFornecedorRepository fornecedorRepository)
            : base(fornecedorRepository)
        {
            this.fornecedorRepository = fornecedorRepository;
        }

        public override void Insert(Fornecedor obj)
        {
            //verificando se o cnpj não está cadastrado no banco de dados
            if(fornecedorRepository.GetByCnpj(obj.Cnpj) == null)
            {
                //cadastrando o fornecedor no banco de dados
                fornecedorRepository.Insert(obj);
            }
            else
            {
                //retornando uma exceção com mensagem de erro
                throw new Exception("Erro, o CNPJ informado já encontra-se cadastrado.");
            }
        }

        public Fornecedor GetByCnpj(string cnpj)
        {
            return fornecedorRepository.GetByCnpj(cnpj);
        }
    }
}
