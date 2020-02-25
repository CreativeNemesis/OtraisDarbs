using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Skola_Forma.Models;

namespace Skola_Forma.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IConfiguration Configuration { get; }

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Create(Lietotaji lietotaji)
        {
            if (ModelState.IsValid)
            {
                string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = $"Insert Into [Table] (Vards, Uzvards, Adrese, Telefons) Values (@Vards,@Uzvards,@Adrese,@Telefons)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Vards", lietotaji.Vards);
                        command.Parameters.AddWithValue("@Uzvards", lietotaji.Uzvards);
                        command.Parameters.AddWithValue("@Adrese", lietotaji.Adrese);
                        command.Parameters.AddWithValue("@Telefons", lietotaji.Telefons);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    return RedirectToAction("Index");
                }
            }
            else
                return View();
        }


        public IActionResult Index()
        {
            List<Lietotaji> lietotajiList = new List<Lietotaji>();
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"]; using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //SqlDataReader
                connection.Open();

                string sql = "Select * From [Table]";
                using (SqlCommand command = new SqlCommand(sql, connection))
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Lietotaji lietotaji = new Lietotaji();
                        lietotaji.Vards = Convert.ToString(dataReader["Vards"]);
                        lietotaji.Uzvards = Convert.ToString(dataReader["Uzvards"]);
                        lietotaji.Adrese = Convert.ToString(dataReader["Adrese"]);
                        lietotaji.Telefons = Convert.ToInt32(dataReader["Telefons"]);
                        lietotajiList.Add(lietotaji);
                    }
                }
                connection.Close();
            }
            return View(lietotajiList);
        }
    } 
}
