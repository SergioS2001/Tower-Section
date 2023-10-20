using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Tower_Section.Models;

namespace Tower_Section.Controllers
{
    public class SectionController : Controller
    {
        //list of sections inside a certain tower
        private List<SectionViewModel> section = new List<SectionViewModel>
        {
            new SectionViewModel()
            {
                part_number = "1",
                number_shell = new List<ShellViewModel>(),  
                bottom_diameter = 1,
                top_diameter = 2,
                Tower_id = 1
            
            },
            new SectionViewModel()
            {
                part_number = "2",
                bottom_diameter = 10,
                top_diameter = 20,
                number_shell = new List<ShellViewModel>(),
                Tower_id = 1
                
                
            },
            new SectionViewModel()
            {
                part_number = "3",
                bottom_diameter = 20,
                top_diameter = 20,
                number_shell = new List<ShellViewModel>(),
                Tower_id = 2
            },
            new SectionViewModel()
            {
            part_number = "4",
            bottom_diameter = 10,
            top_diameter = 10,
            number_shell = new List<ShellViewModel>(),
            Tower_id = 2
        }
        };
        

        public ActionResult Index()
        {
            return View(section);
        }

        public ActionResult Add_Section(string part_number, int bottom_diameter, int top_diameter, ShellViewModel shell_position, List<ShellViewModel> number_shells)
        {
            var new_Section = new SectionViewModel
            {
                part_number = part_number, bottom_diameter = bottom_diameter, top_diameter = top_diameter,
                number_shell = number_shells
            };

            // if the section is empty, we throw a exeption because it needs at least 1 shell per section
                if (new_Section.number_shell.Count < 1)
                {
                      throw new ValidationException("At least one shell per section");
                }
            
                    int pos = 0;
                    foreach (var i in new_Section.number_shell)
                    {
                        //if the shell position doesnt start with 1 or the values arent aligned then it isnt sequential
                        if (i.shell_position < 1 || i.shell_position != pos + 1)
                        {
                            throw new ValidationException("The shells are not sequential");
                        }

                        pos = i.shell_position;
                    }
                    section.Add(new_Section);
                    return RedirectToAction("Index");
        }

        public ActionResult AddShell(int Section_id, int BottomDiameter, int Height, int thickness, int steel_density)
        {
            //creates the association of this shell to our section that we are implementing
            var section = this.section.FirstOrDefault(s => s.Tower_id == Section_id);

            if (section == null)
            {
                throw new ValidationException("Section is null, it must contain at least one shell.");
            }
                //increment number of shells
                var shellPosition = section.number_shell.Count() + 1;
                section.number_shell.Add(new ShellViewModel{
                    bottom_diameter = BottomDiameter,
                    thickness = thickness,
                    steel_density = steel_density,
                    height = Height,
                    section_id = Section_id

                });
            return RedirectToAction("Index");
        }

        public IActionResult ListInfo()
        {
            // Replace with code to retrieve data from the model
            var data = GetInfoFromSection();

            return View(data);
        }
        
        private List<SectionViewModel> GetInfoFromSection()
        {
            // Retrieve data from the Model
            // Replace this with your actual data retrieval logic
            var data = new List<SectionViewModel>
            {
                new SectionViewModel {  Tower_id= 1, part_number = "1", bottom_diameter = 1, top_diameter = 1},
                new SectionViewModel {  Tower_id= 1, part_number = "2", bottom_diameter = 10, top_diameter = 12},
                new SectionViewModel {  Tower_id= 1, part_number = "3", bottom_diameter = 5, top_diameter = 10},
            };

            return data;
        }
        
        public ActionResult DeleteSection(int Tower_id)
        {
            // Find the Section to delete based on its Tower_id
            var sectionToDelete = section.FirstOrDefault(s => s.Tower_id == Tower_id);
            
            //Check if the section exists
            if (sectionToDelete == null)
            {
                
                throw new ValidationException("Section Not Found");
            }
            // Remove the Section from the list
            section.Remove(sectionToDelete);
            return RedirectToAction("Index");
        }
        
        public ActionResult EditSection(int Tower_id)
        {
            // Find the Section to edit based on its Tower_id
            var sectionToEdit = section.FirstOrDefault(s => s.Tower_id == Tower_id);

            if (sectionToEdit == null)
            {
                throw new ValidationException("Section Not Found");
            }

            return View("Edit");
        }
        
        [HttpPost]
        public ActionResult UpdateSection(SectionViewModel updatedSection)
        {
            // Find the Section to update based on its Tower_id
            var sectionToEdit = section.FirstOrDefault(s => s.Tower_id == updatedSection.Tower_id);

            if (sectionToEdit == null)
            {
                throw new ValidationException("Section Not Found");
            }

            // Update the Section's properties
            sectionToEdit.part_number = updatedSection.part_number;
            sectionToEdit.bottom_diameter = updatedSection.bottom_diameter;
            sectionToEdit.top_diameter = updatedSection.top_diameter;

            return RedirectToAction("Index");
        }
        
        public ActionResult SearchSection(string partNumber)
        {
            // Find the Section that matches the part number
            var sectionToSearch = section.FirstOrDefault(s => s.part_number == partNumber);

            if (sectionToSearch == null)
            {
                // Handle cases where the Section is not found
                return View("Error"); // You can create a "NotFound" view for this purpose
            }

            return View("SectionDetails", sectionToSearch);
        }
        
        public ActionResult SearchSectionbyDiameter(string searchTerm, string searchBy)
        {
            var result = new List<SectionViewModel>();

            if (string.IsNullOrEmpty(searchTerm))
            {
                // Handle cases where no search term is provided
                return View("Error"); // You can create a "NoSearchTerm" view for this purpose
            }

            // Search by Top Diameter
            if (searchBy.Equals("TopDiameter", StringComparison.OrdinalIgnoreCase))
            {
                result = section.Where(s => s.top_diameter == int.Parse(searchTerm)).ToList();
            }
            // Search by Bottom Diameter
            else if (searchBy.Equals("BottomDiameter", StringComparison.OrdinalIgnoreCase))
            {
                result = section.Where(s => s.bottom_diameter == int.Parse(searchTerm)).ToList();
            }

            if (result.Count == 0)
            {
                // Handle cases where no matching Section is found
                return View("Error"); // You can create a "NotFound" view for this purpose
            }

            return View("SearchResults", result);
        }






        
        
    }
}