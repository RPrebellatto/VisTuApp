namespace VisTuApp.Models
{
    public class Avaria
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Favor informar o nome da Avaria")]
        [Display(Name = "Avaria")]
        public string NomeAvaria { get; set; }
        public string Grau { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Tubulação")]
        public int TubulacaoId { get; set; }
        [Display(Name = "Tubulação")]
        public Tubulacao Tubulacao { get; set; }
    }
}
