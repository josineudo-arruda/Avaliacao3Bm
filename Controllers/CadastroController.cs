using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Avaliacao3BM.Models;
using Avaliacao3BM.ViewModel;

namespace Avaliacao3BM.Controllers;

public class CadastroController : Controller
{
    private readonly ILogger<CadastroController> _logger;

    public CadastroController(ILogger<CadastroController> logger)
    {
        _logger = logger;
    }


    public IActionResult Cadastro()
    {
        return View();
    }

    public IActionResult Cadastrar([FromForm] LojaViewModel lojaViewModel)
    {
        LojaViewModel loja = new LojaViewModel((LojasController.lojas[(LojasController.lojas).Count - 1].Id) + 1, lojaViewModel.Piso, lojaViewModel.Nome, lojaViewModel.Descricao, lojaViewModel.Tipo, lojaViewModel.Email);
        foreach(var lojaNome in LojasController.lojas)
        {
            if((lojaNome.Nome).Equals(loja.Nome))
            {
                @ViewBag.LojaNome = loja.Nome;
                return View("ErroCadastro");
            }
        }
        (LojasController.lojas).Add(loja);
        return View("Cadastro");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
