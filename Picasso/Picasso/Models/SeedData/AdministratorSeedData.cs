using Microsoft.EntityFrameworkCore;
using Picasso.Model;

namespace Picasso.Models.SeedData
{
    public static class AdministratorSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ExhibitionManagementDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ExhibitionManagementDbContext>>()))
            {
                // Look for any Administrators.
                if (context.Administrators.Any())
                {
                    return;   // DB has been seeded
                }

                context.Administrators.AddRange(
                    new Administrators
                    {
                        AdministratorAccount = "Reent_1983",
                        AdministratorPassword = "heePh6iud",
                        AdministratorName = "錢立承",
                        AdministratorPhone = "0912586480",
                        AdministratorEmail = "JianWeiZheng@gmail.com",
                        CreateDate = DateTime.Parse("2023/11/25 00:00:00")
                    },
                    new Administrators
                    {
                        AdministratorAccount = "Wasts",
                        AdministratorPassword = "Sheigei3i",
                        AdministratorName = "丁彥廷",
                        AdministratorPhone = "0965841235",
                        AdministratorEmail = "ZhengYanTing@gmail.com",
                        CreateDate = DateTime.Parse("2023/11/25 00:00:00")
                    },
                    new Administrators
                    {
                        AdministratorAccount = "Brect<3",
                        AdministratorPassword = "exiateeVii6",
                        AdministratorName = "彭雅萍",
                        AdministratorPhone = "0966843215",
                        AdministratorEmail = "PengYaPing@gmail.com",
                        CreateDate = DateTime.Parse("2023/11/25 00:00:00")
                    },
                    new Administrators
                    {
                        AdministratorAccount = "xEningx",
                        AdministratorPassword = "Oque6Oodai7ae",
                        AdministratorName = "熊芝穎",
                        AdministratorPhone = "096587435",
                        AdministratorEmail = "XiongZhiYing@gmail.com",
                        CreateDate = DateTime.Parse("2023/11/25 00:00:00")
                    },
                    new Administrators
                    {
                        AdministratorAccount = "Prept",
                        AdministratorPassword = "OoKoh5deingie",
                        AdministratorName = "賴焙琪",
                        AdministratorPhone = "0987456213",
                        AdministratorEmail = "LaiBeiQi@gmail.com",
                        CreateDate = DateTime.Parse("2023/11/25 00:00:00")
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
