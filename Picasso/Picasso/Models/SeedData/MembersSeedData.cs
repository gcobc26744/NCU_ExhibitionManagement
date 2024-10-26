using Microsoft.EntityFrameworkCore;
using Picasso.Model;

namespace Picasso.Models.SeedData
{
    public static class MembersSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ExhibitionManagementDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ExhibitionManagementDbContext>>()))
            {
                // Look for any Members.
                if (context.Members.Any())
                {
                    return;   // DB has been seeded
                }

                context.Members.AddRange(
                    new Members
                    {
                        MemberAccount = "Supoed1944",
                        MemberPassword = "Weiv8aif4aph",
                        MemberName = "牛富奎",
                        MemberIdentity = "中央大學教職員",
                        MemberPhone = "0945685246",
                        MemberEmail = "NiuFuKui@cc.ncu.edu.tw",
                        CreateDate = DateTime.Parse("2023/11/25 00:00:00")
                    },
                    new Members
                    {
                        MemberAccount = "Queleandon",
                        MemberPassword = "LephaiB5",
                        MemberName = "蔣馥羽",
                        MemberIdentity = "中央大學學生",
                        MemberPhone = "0978963241",
                        MemberEmail = "112423080@cc.ncu.edu.tw",
                        CreateDate = DateTime.Parse("2023/11/25 00:00:00")
                    },
                    new Members
                    {
                        MemberAccount = "Sathect",
                        MemberPassword = "aDaT9au3",
                        MemberName = "雷雅玲",
                        MemberIdentity = "中央大學學生",
                        MemberPhone = "0944698531",
                        MemberEmail = "112423082@cc.ncu.edu.tw",
                        CreateDate = DateTime.Parse("2023/11/25 00:00:00")
                    },
                    new Members
                    {
                        MemberAccount = "Frasmils",
                        MemberPassword = "peiboh4A",
                        MemberName = "牛婷婷",
                        MemberIdentity = "中央大學教職員",
                        MemberPhone = "0989659976",
                        MemberEmail = "NiuTingTing@cc.ncu.edu.tw",
                        CreateDate = DateTime.Parse("2023/11/25 00:00:00")
                    },
                    new Members
                    {
                        MemberAccount = "Whisyme",
                        MemberPassword = "Ier4cie4oo",
                        MemberName = "傅欣怡",
                        MemberIdentity = "中央大學學生",
                        MemberPhone = "0912339689",
                        MemberEmail = "112423084@cc.ncu.edu.tw",
                        CreateDate = DateTime.Parse("2023/11/25 00:00:00")
                    },
                    new Members
                    {
                        MemberAccount = "Diveture",
                        MemberPassword = "aiThah6seePh",
                        MemberName = "楊安沛",
                        MemberIdentity = "校外人士",
                        MemberPhone = "0945698566",
                        MemberEmail = "YangAnPei@gmail.com",
                        CreateDate = DateTime.Parse("2023/11/25 00:00:00")
                    },
                    new Members
                    {
                        MemberAccount = "Sherarcon",
                        MemberPassword = "Aef2taiw",
                        MemberName = "謝佩瑩",
                        MemberIdentity = "中央大學教職員",
                        MemberPhone = "0956875632",
                        MemberEmail = "XiePeiYing@cc.ncu.edu.tw",
                        CreateDate = DateTime.Parse("2023/11/25 00:00:00")
                    },
                    new Members
                    {
                        MemberAccount = "Thoreeduck",
                        MemberPassword = "phabiesh5Sh",
                        MemberName = "羅培鈞",
                        MemberIdentity = "中央大學學生",
                        MemberPhone = "092299638",
                        MemberEmail = "112423086@cc.ncu.edu.tw",
                        CreateDate = DateTime.Parse("2023/11/25 00:00:00")
                    },
                    new Members
                    {
                        MemberAccount = "Charroarob",
                        MemberPassword = "eeh1queLia9",
                        MemberName = "金怡帆",
                        MemberIdentity = "校外人士",
                        MemberPhone = "0947857793",
                        MemberEmail = "JinYiFan@gmail.com",
                        CreateDate = DateTime.Parse("2023/11/25 00:00:00")
                    },
                    new Members
                    {
                        MemberAccount = "Wourethe",
                        MemberPassword = "looVohK6Yai",
                        MemberName = "李溫馨",
                        MemberIdentity = "校外人士",
                        MemberPhone = "0945696328",
                        MemberEmail = "LiWenXing@gmail.com",
                        CreateDate = DateTime.Parse("2023/11/25 00:00:00")
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
