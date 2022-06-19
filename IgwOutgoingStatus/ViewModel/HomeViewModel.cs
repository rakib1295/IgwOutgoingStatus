using IgwOutgoingStatus.Models;

namespace IgwOutgoingStatus.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Igw_Loss_Record> Igw_Loss_Record_List { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
