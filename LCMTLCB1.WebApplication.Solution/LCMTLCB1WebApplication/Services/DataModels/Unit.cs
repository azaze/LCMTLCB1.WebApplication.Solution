namespace LCMTLCB1WebApplication.Services.DataModels
{
    public class Unit
    {
        public int rowId { get; set; }
        public long lotid { get; set; }
        public long sequence { get; set; }
        public string sort { get; set; }
        public string phase { get; set; }
        public string loadingstatus { get; set; }
        public string isocode { get; set; }
        public DateTime? handlingdate { get; set; }
        public double containerlength { get; set; }
        public double containerheight { get; set; }
        public string containertype { get; set; }
        public string containerid { get; set; }
        public string trans { get; set; }
        public DateTime? outdate { get; set; }
        public DateTime? outtime { get; set; }
        public string btwi03 { get; set; }
        public string paid { get; set; }
        public DateTime? datepaid { get; set; }
        public DateTime? movetime { get; set; }
        public string terminal { get; set; }
        public string seal1 { get; set; }
        public string seal2 { get; set; }
        public string carrier { get; set; }
        public string carriertype { get; set; }
        public string idnumber { get; set; }
        public string idtype { get; set; }
        public long grossweight { get; set; }
        public Booking booking { get; set; }
        public string vesselname { get; set; }
        public string handlingid { get; set; }
        public string handlingtype { get; set; }
        public string handlingsubtype { get; set; }
        public double? ordertemperature { get; set; }
        public double? registeredtemperature { get; set; }
        public double? imdgclass { get; set; }
        public double? outofgauge { get; set; }
        public string? position { get; set; }
        public string? portofdischarge { get; set; }
        public string? remark { get; set; }
        public string? carrieroperator { get; set; }
        public string? carrieroperatordesc { get; set; }
        public string? voyage { get; set; }
        public string? paymenttype { get; set; }

    }
}
