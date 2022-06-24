using ChannelEngineAssessment.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChannelEngineAssessment.Infrastructure.Data
{
    public class ChannelEngineAssessmentContext : DbContext
    {
        public ChannelEngineAssessmentContext(DbContextOptions options) : base(options)
        {
        }

       

        protected override void OnModelCreating(ModelBuilder builder)
        {
           
        }
    }
}
