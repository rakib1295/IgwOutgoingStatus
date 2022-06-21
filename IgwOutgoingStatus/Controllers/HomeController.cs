using IgwOutgoingStatus.Models;
using IgwOutgoingStatus.Data;
using IgwOutgoingStatus.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace IgwOutgoingStatus.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index(DateTime? startDate, DateTime? endDate)       
        {
            string startbillingcycle = "";
            string? startpartition_day = "";
            string endbillingcycle = "";
            string? endpartition_day = "";            

            if (startDate == null)
            {
                startbillingcycle = DateTime.Now.ToString("yyyy") + DateTime.Now.ToString("MM");
                startpartition_day = DateTime.Now.ToString("dd");
            }
            else
            {
                startbillingcycle = startDate?.ToString("yyyy") + startDate?.ToString("MM");
                startpartition_day = startDate?.ToString("dd");
            }

            if (endDate == null && startDate != null)
            {
                endbillingcycle = startDate?.ToString("yyyy") + startDate?.ToString("MM");
                endpartition_day = startDate?.ToString("dd");
            }
            else if (endDate == null && startDate == null)
            {
                endbillingcycle = DateTime.Now.ToString("yyyy") + DateTime.Now.ToString("MM");
                endpartition_day = DateTime.Now.ToString("dd");
            }
            else if(endDate != null && startDate != null)
            {
                endbillingcycle = endDate?.ToString("yyyy") + endDate?.ToString("MM");
                endpartition_day = endDate?.ToString("dd");
            }

            IEnumerable<Igw_Loss_Record> lossRecords = _db.Igw_D_Stat_OG_Loss_Record.Where(t =>
            Convert.ToInt32(t.BillingCycle + t.Partition_Day) >= Convert.ToInt32(startbillingcycle + startpartition_day) &&
            Convert.ToInt32(t.BillingCycle + t.Partition_Day) <= Convert.ToInt32(endbillingcycle + endpartition_day)
                ).GroupBy(
                        l => new
                        {
                            l.Dest_Code,
                            l.Dest_Prefix,
                            l.Dest_Name,
                            l.Calling_Operator,
                            l.International_Carrier,
                            l.Carrier_Rate_USD,
                            l.Y_Rate_USD,
                            l.X_Rate_BDT,
                            l.Y_Rate_BDT,
                            l.Z_Rate_BDT,
                            l.BillingCycle,
                            l.Partition_Day,
                            //l.Exchange_Rate
                        }).Select(cs => new Igw_Loss_Record
                        {
                            Dest_Code = cs.Key.Dest_Code,
                            Dest_Prefix = cs.Key.Dest_Prefix,
                            Dest_Name = cs.Key.Dest_Name,
                            Calling_Operator = cs.Key.Calling_Operator,
                            International_Carrier = cs.Key.International_Carrier,
                            Total_Calls = cs.Sum(c => c.Total_Calls),
                            Total_Min = Math.Round(cs.Sum(c => c.Total_Min), 3),
                            //Total_Min_Pulse = cs.Sum(c => c.Total_Min_Pulse),
                            Carrier_Rate_USD = Math.Round(cs.Key.Carrier_Rate_USD, 6),
                            Y_Rate_USD = Math.Round(cs.Key.Y_Rate_USD, 6),
                            X_Rate_BDT = cs.Key.X_Rate_BDT,
                            Y_Rate_BDT = cs.Key.Y_Rate_BDT,
                            Z_Rate_BDT = cs.Key.Z_Rate_BDT,
                            Total_Revenue_BDT = Math.Round(cs.Sum(c => c.Total_Revenue_BDT), 2),
                            //Total_Expense_USD = cs.Sum(c => c.Total_Expense_USD),
                            Total_Expense_BDT = Math.Round(cs.Sum(c => c.Total_Expense_BDT), 2),
                            Total_Loss_BDT = Math.Round(cs.Sum(c => c.Total_Loss_BDT), 2),
                            BillingCycle = cs.Key.BillingCycle,
                            Partition_Day = cs.Key.Partition_Day,
                            //Exchange_Rate = cs.Key.Exchange_Rate
                        }).ToList().Where(p => p.Total_Loss_BDT < 0).OrderBy(d => d.Total_Loss_BDT);
            //.OrderByDescending(e => e.Total_Min);

            HomeViewModel homeViewModel = new HomeViewModel();
            CultureInfo provider = CultureInfo.InvariantCulture;
            homeViewModel.StartDate = DateTime.ParseExact(startbillingcycle + startpartition_day, "yyyyMMdd", provider);
            homeViewModel.EndDate = DateTime.ParseExact(endbillingcycle + endpartition_day, "yyyyMMdd", provider);

            homeViewModel.Igw_Loss_Record_List = lossRecords;

            return View("Index",homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}