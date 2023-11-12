using AVIDI.ApiService.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AVIDI.ApiService.Models
{
    [Table("DateEvent")]
    public class DateEvent : IIdentifiable
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [NotMapped]
        public IEnumerable<Event>? Events { get; set; }
    }
}
