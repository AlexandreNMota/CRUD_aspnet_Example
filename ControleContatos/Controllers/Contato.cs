using ControleContatos.Models;
using ControleContatos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ControleContatos.Controllers
{
    public class Contato : Controller
    {   
        private readonly IContatoRepository _contatoRepository;
        public Contato(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }
        public IActionResult Index()
        {
            List<ContatoModel>? contatos = _contatoRepository.SearchAll();
            return View(contatos);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Alterar(ContatoModel contato)

        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepository.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Edit", contato);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"OPS! Não reconheci seu contato. Tente novamente: {erro.Message}";
                return RedirectToAction("Index");
            }
            
        }


        public IActionResult Edit(int id)
        {
            
            ContatoModel contato =  _contatoRepository.FilterbyId(id);
            return View(contato);
        }

        public IActionResult ConfirmDelete(int id)
        {
            ContatoModel contato = _contatoRepository.FilterbyId(id);
            return View(contato);
        }

        public IActionResult Delete(int id)
        {

            try
            {
                _contatoRepository.Apagar(id);
                TempData["MensagemSucesso"] = "Contato apagado com sucesso";
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"OPS! Não foi possível apagar seu contato. Tente novamente: {erro.Message}";
                return RedirectToAction("Index");
            }
            
        }

        [HttpPost]
        public IActionResult Create(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepository.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(contato);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"OPS! Não reconheci seu contato. Tente novamente: {erro.Message}";
                return RedirectToAction("Index");
            }          
                        
            
        }
        
    }
}
