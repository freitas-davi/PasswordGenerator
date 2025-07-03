namespace GeradorDeSenhas.Models;

public class PasswordGeneratorModel
{
    public int Lenght { get; set; }
    public bool IncluirMaiusculas { get; set; }
    public bool IncluirMinusculas { get; set; }
    public bool IncluirNumeros { get; set; }
    public bool IncluirCaracteresEspeciais { get; set; }
    public string? SenhaGerada { get; set; }

}