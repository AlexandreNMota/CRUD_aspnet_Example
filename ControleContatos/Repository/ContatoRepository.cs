
using ControleContatos.Controllers;
using ControleContatos.Data;
using ControleContatos.Models;

namespace ControleContatos.Repository
{
    public class ContatoRepository : IContatoRepository
    {
       private BancoContext _bancoContext;
        public ContatoRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            // gravar database
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;

        }

        public List<ContatoModel> SearchAll()
        {
            return _bancoContext.Contatos.ToList();
        }

        public ContatoModel FilterbyId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }

       
        ContatoModel IContatoRepository.Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = FilterbyId(contato.Id);
            if (contatoDB == null) throw new Exception("Houve um erro na atualização do contato");
            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Telefone = contato.Telefone;
            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();
            return contatoDB;
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDB = FilterbyId(id);
            if (contatoDB == null) throw new Exception("Houve um erro ao apagar o contato");
            _bancoContext.Contatos.Remove(contatoDB);
            _bancoContext.SaveChanges();
            return true;

        }
    }
}

