namespace Avaliacao3BM.ViewModel;

public class LojaViewModel
{
    public int Id { get; set; }
    public string Piso { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Tipo { get; set; }
    public string Email { get; set; }

    public LojaViewModel(int id, string piso, string nome, string descricao, string tipo, string email)
    {
        Id = id;
        Piso = piso;
        Nome = nome;
        Descricao = descricao;
        Tipo = tipo;
        Email = email;
    }

    public LojaViewModel()
    {
        
    }
}