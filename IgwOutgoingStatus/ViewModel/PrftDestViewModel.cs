using IgwOutgoingStatus.Models;

namespace IgwOutgoingStatus.ViewModel
{
    public class PrftDestViewModel
    {
        public IEnumerable<Igw_Prft_Record> Igw_Prft_Record_List { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
