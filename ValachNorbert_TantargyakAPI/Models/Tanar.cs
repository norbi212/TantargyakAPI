using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ValachNorbert_TantargyakAPI.Models
{
    public class Tanar
    {
        [Key]
        public int Id { get; set; }
        public string Nev { get; set; }
        public string Email { get; set; }
        public DateTime BelepesDatuma { get; set; }
        [JsonIgnore]
        public List<Tantargy>? Tantargyak {  get; set; }
    }
}
