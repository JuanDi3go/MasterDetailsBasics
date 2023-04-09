﻿using MasterDetailsBasics.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Xml.Linq;

namespace MasterDetailsBasics.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string cadenasql;


        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            cadenasql = config.GetConnectionString("Dbconnection");

        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult SaveSale([FromBody] Sale body)
        {
            XElement sale = new XElement("Sale",

                new XElement("DocumentNumber", body.DocumentNumber),
                new XElement("BusinessName", body.BusinessName),
                new XElement("Overall", body.Overall)

                );

            XElement osaleDetail = new XElement("SalesDetail");

            foreach (SalesDetail item in body.SalesDetails)
            {
                osaleDetail.Add(new XElement("Item",

                    new XElement("Product",item.Product),
                    new XElement("Price", item.Price),
                    new XElement("Quantity", item.Quantity),
                    new XElement("Overall", item.Overall)
                    ));
            }

            sale.Add(osaleDetail);


            using (var connection = new SqlConnection(cadenasql))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SP_SaveSale", connection);
                cmd.Parameters.Add("@Sale_xml", SqlDbType.Xml).Value = sale.ToString();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
            }


                return Json(new {response = true });

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