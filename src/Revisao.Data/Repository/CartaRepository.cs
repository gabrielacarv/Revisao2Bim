using AutoMapper;
using Newtonsoft.Json;
using Revisao.Data.Providers.MongoDb.Collections;
using Revisao.Data.Providers.MongoDb.Interfaces;
using Revisao.Domain.Entities;
using Revisao.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisao.Data.Repositories
{
    public class CartaRepository : ICartaRepository
    {

        private readonly IMongoRepository<CartaCollection> _cartaRepository;

        private readonly string _produtoCaminhoArquivo;
        private readonly IMapper _mapper;

        #region - Construtores
        public CartaRepository(IMongoRepository<CartaCollection> cartaRepository, IMapper mapper)
        {
            _cartaRepository = cartaRepository;
            _mapper = mapper;
        }
        #endregion

        #region Funções do Arquivo      
        //public Task<IEnumerable<Carta>> ObterTodos()
        //{
        //    List<Carta> cartas = LerCartasDoArquivo();
        //    return Task.FromResult<IEnumerable<Carta>>(cartas);
        //}

        public IEnumerable<Carta> ObterTodos()
        {
            var cartaList = _cartaRepository.FilterBy(filter => true);

            List<Carta> lista = new List<Carta>();
            foreach (var item in cartaList)
            {
                lista.Add(new Carta(item.Nome, item.Endereco, item.Idade, item.Conteudo));
            }

            //return _mapper.Map<IEnurable<Produto>>(produtoList);

            return lista;
        }

        //public void Adicionar(Carta novaCarta)
        //{
        //    //List<Produto> produtos = new List<Produto>();
        //    List<Carta> cartas = LerCartasDoArquivo();
        //    cartas.Add(novaCarta);
        //    EscreverCartasNoArquivo(cartas);
        //}


        public async Task Adicionar(Carta carta)
        {
            //await _produtoRepository.InsertOneAsync(_mapper.Map<ProdutoCollection>(produto)));

            CartaCollection cartaCollection = new CartaCollection();           
            cartaCollection.Nome = carta.Nome;
            cartaCollection.Endereco = carta.Endereco;
            cartaCollection.Idade = carta.Idade;          
            cartaCollection.Conteudo = carta.Conteudo;

            await _cartaRepository.InsertOneAsync(cartaCollection);
        }
        #endregion

        #region Métodos do Arquivo
        //private List<Carta> LerCartasDoArquivo()
        //{
        //    if (!System.IO.File.Exists(_cartaCaminhoArquivo))
        //    {
        //        return new List<Carta>();
        //    }

        //    string json = System.IO.File.ReadAllText(_cartaCaminhoArquivo);
        //    return JsonConvert.DeserializeObject<List<Carta>>(json);
        //}

        //private void EscreverCartasNoArquivo(List<Carta> cartas)
        //{
        //    string json = JsonConvert.SerializeObject(cartas);
        //    System.IO.File.WriteAllText(_cartaCaminhoArquivo, json);
        //}
        #endregion
    }
}
