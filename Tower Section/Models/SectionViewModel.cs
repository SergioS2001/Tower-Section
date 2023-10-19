using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tower_Section.Models
{
    public class SectionViewModel
    {
        [Key] // This specifies that the property is a primary key
        [Required] // This specifies that the property is required
        public int Tower_id { get; set; } //sequential ID

        public string part_number { get; set; }
        public int bottom_diameter { get; set; }
        public int top_diameter { get; set; }
        public List<ShellViewModel> number_shell { get; set; }

    }
}