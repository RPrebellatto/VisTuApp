namespace VisTuApp.Models
{
    public class Tubulacao
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Favor informar a tubulação")]
        [Display(Name = "Tubulação")]
        public string NomeTubulacao { get; set; }
        public List<Avaria> Avarias { get; set; }
    }
}
