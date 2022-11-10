namespace VisTuApp.Models
{
    public class Vistoria
    {
        public int Id { get; set; }
        [Display(Name = "Tubulação")]
        public int TubulacaoId { get; set; }
        [Display(Name = "Tubulação")]
        public Tubulacao Tubulacao { get; set; }
        [Display(Name = "Data da Vistoria")]
        public DateTime DataVistoria { get; set; }
    
        [Display(Name = "Vistoriador")]
        public string UsuarioVistoria { get; set; }
        [Display(Name = "Data do Reparo")]
        public DateTime? DataReparo { get; set; }
        public string? Observação { get; set; }

    }
}
