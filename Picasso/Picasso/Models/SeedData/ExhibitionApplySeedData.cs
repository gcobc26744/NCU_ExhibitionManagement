using Microsoft.EntityFrameworkCore;
using Picasso.Model;

namespace Picasso.Models.SeedData
{
    public class ExhibitionApplySeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ExhibitionManagementDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ExhibitionManagementDbContext>>()))
            {
                // Look for any ExhibitionApply.
                if (context.ExhibitionApply.Any())
                {
                    return;   // DB has been seeded
                }

                string MemberId = context.Members.Where(m => m.MemberName.Equals("金怡帆")).FirstOrDefault().MemberId.ToString();
                string ExhibitionId1 = context.Exhibitions.Where(e => e.ExhibitionName.Equals("以土為名的抽象共感－陶藝創作展")).FirstOrDefault().ExhibitionId.ToString();
                string ExhibitionId2 = context.Exhibitions.Where(e => e.ExhibitionName.Equals("全面啟動 Inception（6+)")).FirstOrDefault().ExhibitionId.ToString();
                string ExhibitionId3 = context.Exhibitions.Where(e => e.ExhibitionName.Equals("台北曲藝團《北曲．三十而麗》")).FirstOrDefault().ExhibitionId.ToString();


                context.ExhibitionApply.AddRange(
                    new ExhibitionApply
                    {
                        ApplyDate = DateTime.Parse("2023/11/20"),
                        ApplyStatus = true,
                        CreateDate = DateTime.Parse("2023/11/20 00:00:00"),
                        ExhibitionId = Guid.Parse(ExhibitionId1),
                        MemberId = Guid.Parse(MemberId)
                    },
                    new ExhibitionApply
                    {
                        ApplyDate = DateTime.Parse("2023/12/28"),
                        ApplyStatus = true,
                        CreateDate = DateTime.Parse("2023/12/26 00:00:00"),
                        ExhibitionId = Guid.Parse(ExhibitionId2),
                        MemberId = Guid.Parse(MemberId)
                    },
                    new ExhibitionApply
                    {
                        ApplyDate = DateTime.Parse("2023/12/27"),
                        ApplyStatus = true,
                        CreateDate = DateTime.Parse("2023/12/26 00:00:00"),
                        ExhibitionId = Guid.Parse(ExhibitionId3),
                        MemberId = Guid.Parse(MemberId)
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
