using Revisao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisao.Data.Providers.MongoDb.Collections
{
    [BsonCollection("Carta")]
    public class CartaCollection : Document
    {
        public string Nome { get;  set; }
        public List<Endereco> Endereco { get;  set; }
        public int Idade { get;  set; }
        public string Conteudo { get;  set; }
    }
}
