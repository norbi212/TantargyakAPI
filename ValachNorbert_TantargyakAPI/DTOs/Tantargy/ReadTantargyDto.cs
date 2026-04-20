using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ValachNorbert_TantargyakAPI.DTOs.Tantargy
{
    public class ReadTantargyDto
    {
        public int Id { get; set; }
        public string TantargyNev { get; set; }
        public string RovidLeiras { get; set; }
        public int EvesOraszam { get; set; }
        public string TanarNeve { get; set; }
    }
}
