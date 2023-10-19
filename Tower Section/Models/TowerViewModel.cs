using System.Collections.Generic;

namespace Tower_Section.Models
{
    public class TowerViewModel
    {
        public int tower_height { get; set; }
        public int total_id { get; set; }
        public List<SectionViewModel> number_sections { get; set; }
    }
}