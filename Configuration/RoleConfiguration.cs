using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hotelcourseworkV2.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "1",
                    Name = "Владелец сети",
                    NormalizedName = "ВЛАДЕЛЕЦ СЕТИ"
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = "Директор",
                    NormalizedName = "ДИРЕКТОР"
                },
                new IdentityRole
                {
                    Id = "3",
                    Name = "Горничные",
                    NormalizedName = "ГОРНИЧНЫЕ"
                },
                new IdentityRole
                {
                    Id = "4",
                    Name = "Повар в отеле",
                    NormalizedName = "ПОВАР В ОТЕЛЕ"
                },
                new IdentityRole
                {
                    Id = "5",
                    Name = "Сотрудник рецепции",
                    NormalizedName = "СОТРУДНИК РЕЦЕПЦИИ"
                },
                new IdentityRole
                {
                    Id = "6",
                    Name = "Зарегистрированный клиент",
                    NormalizedName = "ЗАРЕГИСТРИРОВАННЫЙ КЛИЕНТ"
                }
            );
        }
    }
}
