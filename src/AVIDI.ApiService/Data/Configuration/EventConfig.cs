using AVIDI.ApiService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AVIDI.ApiService.Data.Configuration
{
    public class EventConfig : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasOne(p => p.Date).WithMany(p => p.Events).IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
