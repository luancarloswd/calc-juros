using System.ComponentModel.DataAnnotations;

namespace CalcTest.Service.ViewModels
{
    public class JurosCompostosInputViewModel
    {
        [Required(ErrorMessage = "O valor inicial é obrigatório")]
        [Range(0.1, double.MaxValue, ErrorMessage = "O valor inicial deve ser maior que zero")]
        public decimal ValorInicial { get; set; }

        [Required(ErrorMessage = "O campo meses é obrigatório")]
        [Range(0, int.MaxValue, ErrorMessage = "O campo meses é inválido")]
        public int Meses { get; set; }
    }
}
