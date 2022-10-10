using ControleContatos.Models;
namespace ControleContatos.Repository
{
    public interface IContatoRepository
    {
        ContatoModel FilterbyId(int id);
        List<ContatoModel> SearchAll();
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Atualizar(ContatoModel contato);
        bool Apagar(int id);
        
    }
}
