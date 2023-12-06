using AutoMapper;
using Revisao.Data.Providers.MongoDb.Collections;
using Revisao.Domain.Entities;

namespace Revisao.Data.AutoMapper
{
    public class CollectionToDomain : Profile
    {
        public CollectionToDomain()
        {
            CreateMap<CartaCollection, Carta>()
                .ConstructUsing(u => new Carta(u.Nome, u.Endereco, u.Idade, u.Conteudo));
        }     
    }
}
