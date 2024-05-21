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
                    Id = Guid.NewGuid().ToString(),
                    Name = "Владелец сети",
                    NormalizedName = "ВЛАДЕЛЕЦ СЕТИ"
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Директор",
                    NormalizedName = "ДИРЕКТОР"
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Горничные",
                    NormalizedName = "ГОРНИЧНЫЕ"
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Повар в отеле",
                    NormalizedName = "ПОВАР В ОТЕЛЕ"
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Сотрудник рецепции",
                    NormalizedName = "СОТРУДНИК РЕЦЕПЦИИ"
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Зарегистрированный клиент",
                    NormalizedName = "ЗАРЕГИСТРИРОВАННЫЙ КЛИЕНТ"
                }
            );
        }
    }
}
