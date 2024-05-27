using hotelcourseworkV2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hotelcourseworkV2.Configuration
{
    public class TypeRoomConfiguration : IEntityTypeConfiguration<TypeRoom>
    {
        public void Configure(EntityTypeBuilder<TypeRoom> builder)
        {
            builder.HasData(
                new TypeRoom{
                    Id = 1,
                    Name = "Звичаний",
                    Price = 400
                },

                new TypeRoom {
                    Id = 2,
                    Name = "Покращеный",
                    Price = 800
                },
                
                new TypeRoom{
                    Id = 3, 
                    Name = "Люкс",
                    Price = 1500,
                },

                new TypeRoom{
                    Id = 4,
                    Name = "Презеденський люкс",
                    Price = 2500
                }
            );
        }
    }
}
