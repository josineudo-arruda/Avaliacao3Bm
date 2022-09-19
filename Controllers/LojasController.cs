using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Avaliacao3BM.Models;
using Avaliacao3BM.ViewModel;

namespace Avaliacao3BM.Controllers;

public class LojasController : Controller
{
    private readonly ILogger<LojasController> _logger;

    public LojasController(ILogger<LojasController> logger)
    {
        _logger = logger;
    }

    public static List<LojaViewModel> lojas = new List<LojaViewModel> 
    {
        new LojaViewModel(1, "piso 1", "Mc Donald's", "fast food", "Loja", "mequizinho@gmail.com"),
        new LojaViewModel(2, "piso 2", "Starbucks", "bebidinha hum", "Kiosque", "bebidinha@gmail.com"),
        new LojaViewModel(3, "piso 2", "Americanas", "loja com tudo", "Loja", "eoamericas@gmail.com"),
        new LojaViewModel(4, "piso 3", "Burguer King", "fast food", "Loja", "burguerzinho@gmail.com")
    };

    public IActionResult ListaPublica() 
    {
        return View(lojas);
    }

    public IActionResult ListaRestrita()
    {
        return View(lojas);
    }

    public IActionResult Excluir([FromForm] int id)
    {
        foreach(var loja in lojas)
        {
            if(loja.Id  == id)
            {
                lojas.Remove(loja);
                break;
            }
        }
        return View("/Views/Home/Index.cshtml");
    }

    public IActionResult Detalhes(int id)
    {
        foreach(var loja in lojas)
        {
            if(loja.Id  == id)
            {
                return View(loja);
            }
        }
        return View();
    }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
