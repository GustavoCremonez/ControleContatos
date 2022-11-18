using controleContatos.Data;
using controleContatos.Models;
using System.Collections.Generic;
using System.Linq;

namespace controleContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();

            return contato;
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDb = BuscarPorId(id);

            if (contatoDb == null) throw new System.Exception("Houve um erro ao deletar o contato");

            _bancoContext.Contatos.Remove(contatoDb);
            _bancoContext.SaveChanges();

            return true;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDb = BuscarPorId(contato.Id);

            if (contatoDb == null) throw new System.Exception("Houve um erro na atualização do contato");

            contatoDb.Name = contato.Name;
            contatoDb.Email = contato.Email;
            contatoDb.Celular = contato.Celular;

            _bancoContext.Contatos.Update(contatoDb);

            _bancoContext.SaveChanges();

            return contatoDb;
        }

        public ContatoModel BuscarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }
    }
}
