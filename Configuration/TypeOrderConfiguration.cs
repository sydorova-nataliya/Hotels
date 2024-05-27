/*
    Типи:
    Номер 
    Ресторан
    Сервіс
*/
using hotelcourseworkV2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hotelcourseworkV2.Configuration
{
    public class TypeOrderConfiguration : IEntityTypeConfiguration<TypeOrder>
    {
        public void Configure(EntityTypeBuilder<TypeOrder> builder)
        {
            builder.HasData(
                new TypeOrder{
                    Id = 1,
                    Name = "Номер",
                },

                new TypeOrder {
                    Id = 2,
                    Name = "Ресторан",
                },
                
                new TypeOrder{
                    Id = 3, 
                    Name = "Сервіс",
                }
            );
        }
    }
}
