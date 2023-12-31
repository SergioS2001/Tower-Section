using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Tower_Section.Models;

namespace Tower_Section.Controllers
{
    public class ShellController : Controller
    {
        private List<ShellViewModel> shell = new List<ShellViewModel>()
        {
            new ShellViewModel()
            {
                Shell_id = 1,
                bottom_diameter = 1,
                section_id = 1,
                height = 10,
                thickness = 1,
                steel_density = 10
            },
            new ShellViewModel()
            {
                Shell_id = 2,
                bottom_diameter = 3,
                section_id = 1,
                height = 6,
                thickness = 2,
                steel_density = 10
            },
            new ShellViewModel()
            {
                Shell_id = 3,
                bottom_diameter = 4,
                section_id = 2,
                height = 10,
                thickness = 1,
                steel_density = 10
            },
            new ShellViewModel()
            {
                Shell_id = 1,
                bottom_diameter = 1,
                section_id = 2,
                height = 10,
                thickness = 1,
                steel_density = 10
            }
        };
        
        public IActionResult Index()
        {
            return View(shell);
        }
        
        private List<ShellViewModel> GetInfoFromShell()
        {
            // Retrieve data from the Model
            // Replace this with your actual data retrieval logic
            var data = new List<ShellViewModel>
            {
                new ShellViewModel() {  Shell_id= 1, section_id = 1, bottom_diameter = 1, height = 1, thickness = 1, steel_density = 2},
                new ShellViewModel() {  Shell_id= 2, section_id = 1, bottom_diameter = 10, height = 12, thickness = 2, steel_density = 1},
                new ShellViewModel() {  Shell_id= 3, section_id = 1, bottom_diameter = 5, height = 10, thickness = 1, steel_density = 3},
            };

            return data;
        }
        
    }
}