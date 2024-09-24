using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AOWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AOWebApp.Controllers
{
    public class ReportsController : Controller
    {

        private readonly AmazonOrdersContext _context;

        public ReportsController(AmazonOrdersContext context)
        {
            _context = context;
        }

       
        // GET: /<controller>/
        //Update the action to generate a list of distinct years in descending order based on the customerOrder dates
        public IActionResult Index()
        {
            var yearList = _context.CustomerOrders
                .Select(co => co.OrderDate.Year)
                .Distinct()
                .OrderByDescending(co => co)
                .ToList();
            // Let the Index() action load a view calles 'AnnualSalesReport'
            return View("AnnualSalesReport", new SelectList(yearList));
        }

        // Create a new action named AnnualSalesReportData and accepts an int Year parameter
        // It will return a new json() object with the data set to null
        public IActionResult AnnualSalesReportData(int Year)
        {
            // Create a query to navigate the CustomerOrders table to check if the year of the order matches the incoming year
            // then use GroupBy() group the records by the orderdate Year and Month
            // then select a new anonymous object containing the year,monthNo,monthName, totalItems and totalSales
            // lastly, order the records by the monthNo
            if (Year > 0)
            {
                var orderSummary = _context.ItemsInOrders
                    .Where(iio => iio.OrderNumberNavigation.OrderDate.Year == Year)
                    .GroupBy(iio => new { iio.OrderNumberNavigation.OrderDate.Year, iio.OrderNumberNavigation.OrderDate.Month })
                    .Select(group => new
                    {
                        year = group.Key.Year,
                        monthNo = group.Key.Month,
                        //monthName = "",
                        monthName = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(group.Key.Month),
                        totalItems = group.Sum(iio => iio.NumberOf),
                        totalSales = group.Sum(iio => iio.TotalItemCost)
                    })
                    .OrderBy(data => data.monthNo);
                    //.ToList();

                //var summary = orderSummary.Select(os => new
                //{
                //    os.year,
                //    os.monthNo,
                //    monthName = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(os.monthNo),
                //    os.totalItems,
                //    os.totalSales
                //});

                return Json(orderSummary);
                //return Json(summary);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

