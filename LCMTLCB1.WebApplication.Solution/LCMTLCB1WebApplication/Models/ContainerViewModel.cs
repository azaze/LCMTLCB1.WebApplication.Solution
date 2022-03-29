using LCMTLCB1WebApplication.Services.DataModels;

namespace LCMTLCB1WebApplication.Models
{
    public class ContainerViewModel
    {
        public Unit unit { get; set; }
        public List<Unit> unitlist { get; set; }
        public string status { get; set; }
        public string? msg { get; set; }

    }
}
