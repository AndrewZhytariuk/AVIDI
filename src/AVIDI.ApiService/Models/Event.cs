using AVIDI.ApiService.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AVIDI.ApiService.Models
{
    [Table("Event")]
    public class Event : IIdentifiable
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }
        public string? Title { get; set; }
        [NotMapped]
        public DateEvent? Date { get; set; }
    }
}
