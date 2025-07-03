using Microsoft.AspNetCore.Mvc;
using GeradorDeSenhas.Models;
using System.Text;
using System.Diagnostics;

namespace GeradorDeSenhas.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index() // Método para exibir o formulário (GET)
        {
            var model = new PasswordGeneratorModel();
            return View(model); // Envia para a View para desenhar o formulário
        }


        [HttpPost] // Método para processar o formulário (POST)
        public IActionResult Index(PasswordGeneratorModel model)
        {
            var caracteres = new StringBuilder();
            if (model.IncluirMaiusculas)
                caracteres.Append("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            if (model.IncluirMinusculas)
                caracteres.Append("abcdefghijklmnopqrstuvwxyz");
            if (model.IncluirNumeros)
                caracteres.Append("0123456789");
            if (model.IncluirCaracteresEspeciais)
                caracteres.Append("!@#$%^&*()_+-=[]{}|;:,.<>?");

            // Mensagem de erro se nenhum tipo de caractere for selecionado
            if (caracteres.Length == 0)
            {
                ModelState.AddModelError(string.Empty, "Selecione pelo menos um tipo de caractere para gerar a senha.");
                return View(model); // Retorna a View com o erro
            }


            // GERAR SENHA
            var gerarSenha = new StringBuilder();
            var random = new Random();
            for (int i = 0; i < model.TamanhoSenha; i++)
            {
                int index = random.Next(caracteres.Length);
                gerarSenha.Append(caracteres[index]);
            }

            model.GerarSenha = gerarSenha.ToString(); // Atribui a senha gerada ao modelo

            // Retorna a View com o modelo atualizado
            return View(model);
            
        }


        // Métodos de privacidade e erro que já vêm com o template. Não precisamos mexer.
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
    
}