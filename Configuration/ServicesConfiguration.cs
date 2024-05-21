using hotelcourseworkV2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hotelcourseworkV2.Configuration
{
    public class ServicesConfiguration : IEntityTypeConfiguration<Services>
    {
        public void Configure(EntityTypeBuilder<Services> builder)
        {
            builder.HasData(
                new Services{
                    Id = 1,
                    Name = "Басейн",
                    Price = 100
                },

                new Services {
                    Id = 2,
                    Name = "Спа",
                    Price = 250
                },
                
                new Services{
                    Id = 3, 
                    Name = "Сніданок",
                    Price = 300,
                },

                new Services{
                    Id = 4,
                    Name = "Ескурсія",
                    Price = 700
                }
            );
        }
    }
}
