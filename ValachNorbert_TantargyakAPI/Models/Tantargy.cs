using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ValachNorbert_TantargyakAPI.Models
{
    public class Tantargy
    {
        [Key]
        public int Id { get; set; }
        public string TantargyNev { get; set; }
        public string RovidLeiras { get; set; }
        public int EvesOraszam { get; set; }
        public int TanarId { get; set; }
        [ForeignKey("TanarId")]
        [JsonIgnore]
        public Tanar Tanar { get; set; }
    }
}
