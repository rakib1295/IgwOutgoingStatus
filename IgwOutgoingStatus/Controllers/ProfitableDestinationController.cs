using IgwOutgoingStatus.Models;
using IgwOutgoingStatus.Data;
using IgwOutgoingStatus.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace IgwOutgoingStatus.Controllers
{
    public class ProfitableDestinationController : Controller
    {
        private readonly ILogger<ProfitableDestinationController> _logger;

        private ApplicationDbContext _db;

        public ProfitableDestinationController(ILogger<ProfitableDestinationController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult GetDestinations(DateTime? startDate, DateTime? endDate)
        {
            string startbillingcycle = "";
            string startpartition_day = "";
            string endbillingcycle = "";
            string endpartition_day = "";

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
            else if (endDate != null && startDate != null)
            {
                endbillingcycle = endDate?.ToString("yyyy") + endDate?.ToString("MM");
                endpartition_day = endDate?.ToString("dd");
            }

            PrftDestViewModel prftDestViewModel = new PrftDestViewModel();
            CultureInfo provider = CultureInfo.InvariantCulture;
            prftDestViewModel.StartDate = DateTime.ParseExact(startbillingcycle + startpartition_day, "yyyyMMdd", provider);
            prftDestViewModel.EndDate = DateTime.ParseExact(endbillingcycle + endpartition_day, "yyyyMMdd", provider);


            IEnumerable<Igw_Prft_Record> prftRecords = _db.Igw_D_Stat_OG_Prft_Record.Where(t =>
            DateTime.ParseExact(t.BillingCycle + t.Partition_Day, "yyyyMMdd", provider) >= prftDestViewModel.StartDate &&
            DateTime.ParseExact(t.BillingCycle + t.Partition_Day, "yyyyMMdd", provider) <= prftDestViewModel.EndDate).GroupBy(
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
                        }).Select(cs => new Igw_Prft_Record
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
                            Total_Profit_BDT = Math.Round(cs.Sum(c => c.Total_Profit_BDT), 2),
                            BillingCycle = cs.Key.BillingCycle,
                            Partition_Day = cs.Key.Partition_Day,
                            //Exchange_Rate = cs.Key.Exchange_Rate
                        }).ToList().Where(p => p.Total_Profit_BDT > 1).OrderByDescending(d => d.Total_Profit_BDT);
            //.OrderByDescending(e => e.Total_Min);

            prftDestViewModel.Igw_Prft_Record_List = prftRecords;


            return View("GetDestinations", prftDestViewModel);
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