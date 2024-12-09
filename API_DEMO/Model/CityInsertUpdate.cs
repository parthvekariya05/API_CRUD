using System.Text.Json.Serialization;

namespace API_DEMO.Model
{
    public class CityInsertUpdate
    {
        [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int CityID { get; set; }
        public string CityName { get; set; }
        public int TalukaID { get; set; }
        public int UserID { get; set; }

    }
}
