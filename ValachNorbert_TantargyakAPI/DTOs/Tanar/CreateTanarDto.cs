using System.Text.Json.Serialization;

namespace ValachNorbert_TantargyakAPI.DTOs.Tanar
{
    public class CreateTanarDto
    {
        public string Nev { get; set; }
        public string Email { get; set; }
        public DateTime BelepesDatuma { get; set; }
    }
}
