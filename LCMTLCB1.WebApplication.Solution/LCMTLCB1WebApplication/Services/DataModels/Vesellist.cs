namespace LCMTLCB1WebApplication.Services.DataModels
{
    public class Vesellist
    {
        public int rowId { get;set; }
        public string  vesselid { get; set; }
        public string vesselcode { get; set; }
        public string vesselname { get; set; }
        public string vesseloperation { get; set; }
        public string vesseloperationdesc { get; set; }
        public string voyin { get; set; }
        public string voyout { get; set; }
        public DateTime? ETA { get; set; }
        public DateTime? ATA { get; set; }
        public DateTime? ETD { get; set; }
        public DateTime? ATD { get; set; }
        public string terminal { get; set; }
        public string carrier { get; set; }
        public string phase { get; set; }
        public string carrierdesc { get; set; }
        public string servicein { get; set; }
        public string serviceout { get; set; }
        public string callsign { get; set; }
    }
}
