﻿namespace API_DEMO.Model
{
    public class CityModel
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
        public int TalukaID { get; set; }
        public string TalukaName { get; set; }
        public int DistrictID { get; set; }
        public string DistrictName { get; set; }
        public int StateID { get; set; }
        public string StateName { get; set; }
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public int UserID { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

    }
}