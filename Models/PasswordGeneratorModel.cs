using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GeradorDeSenhas.Models;

public class PasswordGeneratorModel
{
    [DisplayName("Tamanho da senha")] 
    [Range(7, 61, ErrorMessage = "O tamanho deve ser entre 7 e 61 caracteres!")] // Define um valor mínimo e máximo para o tamanho da senha
    public int TamanhoSenha { get; set; } = 12; // Valor padrão de 12 caracteres

    [DisplayName("Incluir letras maiúsculas (A-Z)")]
    public bool IncluirMaiusculas { get; set; } = true; // Marcado como verdadeiro por padrão

    [DisplayName("Incluir letras minúsculas (a-z)")]
    public bool IncluirMinusculas { get; set; } = true; // Marcado como verdadeiro por padrão

    [DisplayName("Incluir números (0-9)")]
    public bool IncluirNumeros { get; set; } = true; // Marcado como verdadeiro por padrão

    [DisplayName("Incluir caracteres especiais (!@#$...)")]
    public bool IncluirCaracteresEspeciais { get; set; } = true; // Marcado como verdadeiro por padrão

    
    public string? SenhaGerada { get; set; }

}