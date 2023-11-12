using AVIDI.ApiService.Constants;
using AVIDI.ApiService.Data.DbContexts;
using AVIDI.ApiService.Data.Repository.Interfaces;
using AVIDI.ApiService.Models;
using Microsoft.EntityFrameworkCore;

namespace AVIDI.ApiService.Data.Repository
{
    public class DataEventRepository: IDataEventRepository<DateEvent>
    {
        private AVIDIDbContext Context { get; init; }
        private DbSet<DateEvent> Table { get; set; }

        public DataEventRepository(AVIDIDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Table = context.DataEvents ?? throw new ArgumentNullException(nameof(context.DataEvents));
        }

        public async Task<IEnumerable<DateEvent>> GetEventsAsync(int year, string monthName)
        {
            try
            {
               int month = DateConverter.MontchToNumber[monthName.ToLower()];

               return await Task.Run(() => Table
                    .Include(p => p.Events)
                    .Where(entity => entity.Date.Year == year && entity.Date.Month == month));
            } catch(Exception ex)
            {

            }
             
            return new  List<DateEvent>();
        }

        public async Task AddAsync(DateEvent entity)
        {
            try {
                await Table.AddAsync(entity); 
                await Context.SaveChangesAsync();
            } catch (Exception ex) {
                throw new Exception($"DataEvent not save. {ex.Message}");
            }
        }
    }
}
