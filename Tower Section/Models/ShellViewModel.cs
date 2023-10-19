using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tower_Section.Models
{
    public class ShellViewModel
    {
        //unique id, with identity there is only a single reference for each id
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Shell_id { get; set; }
        public int section_id { get; set; }
        public int shell_position { get; set; }
        public int height { get; set; }
        public int bottom_diameter { get; set; }
        public int thickness { get; set; }
        public int steel_density { get; set; }

    }
}