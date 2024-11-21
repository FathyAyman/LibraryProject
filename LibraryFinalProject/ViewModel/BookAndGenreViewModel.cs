using LibraryFinalProject.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryFinalProject.ViewModel
{
    public class BookAndGenreViewModel
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        [RegularExpression("(Available|Not Available)",ErrorMessage ="Availability Status must be Availabel or Not Available")]
        [Display(Name = "Availability Status")]
        public string? Availability_Status { get; set; }
        [Display(Name = "Price per Week")]
        public double PricePerWeek { get; set; }
        public string ISBN { get; set; }
        public DateTime Publish_Date { get; set; }
        [Display(Name ="Photo Path")]
        public string Book_Photo { get; set; }
        public int Genre_Id { get; set; }
        public string? Genre_Name { get; set; }
        public int? MemberId { get; set; }
        public int? CheckoutsId { get; set; }
        public string? Availability_color { get;set; }
        public List<Genre>? genres { get; set; }
    }
}
