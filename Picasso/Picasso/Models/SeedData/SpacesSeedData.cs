using Microsoft.EntityFrameworkCore;

namespace Picasso.Models.SeedData
{
    public static class SpacesSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ExhibitionManagementDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ExhibitionManagementDbContext>>()))
            {
                // Look for any Spaces.
                if (context.Spaces.Any())
                {
                    return;   // DB has been seeded
                }

                context.Spaces.AddRange(
                    new Spaces
                    {
                        SpaceName = "人文藝術中心",
                        SpaceLocation = "中正圖書館一樓",
                        SpaceCapacity = 200,
                        SpaceDescription = @"藝文中心位於中正圖書館一樓，建築物為榮譽校友陳其寬建築師所設計，目前場館規劃有展覽空間、藝術教室、圖書閱覽區及典藏室。
                                            藝文中心每學期推出二至三檔展覽，並以邀請展為主，類型涵蓋平面、立體、複合媒材、新媒體藝術等，每年於五、六月校慶期間更會安排傑出校友、前輩藝術家與國家文藝獎得主等重要展覽。
                                            藉由國內與國際知名藝術家或團體的引進與介紹，加上整體性的宣傳，將高質感的文化藝術活動引入校園。展期間除邀請藝術家分享創作理念，面對面進行交流外，並透過一系列如講座、工作坊
                                            及駐校計畫等展覽延伸活動，提供中大師生、鄰近社區與大桃園地區民眾親近參與藝文活動之多元場合，培育並提升美學素養。",
                        SpaceStatus = true,
                        Image = "ArtCenterPic.png",
                        CreateDate = DateTime.Parse("2023/11/25 00:00:00")
                    },
                    new Spaces
                    {
                        SpaceName = "107電影院",
                        SpaceLocation = "人文社會科學大樓一樓",
                        SpaceCapacity = 95,
                        SpaceDescription = @"107電影院位於人文社會科學大樓1樓，為國內首座校園專屬戲院，廳內設有95個座席及專業視聽播放設備，以推廣電影藝術及教育為目
                                            的。於民國92年由英文系電影文化研究室規劃成立，自民國111年起由人文藝術中心負責經營管理，學期間提供各式主題影展與精選影片放映，
                                            另不定期邀請導演或影評人分享鏡頭下的秘密，帶領觀眾體驗不一樣的觀影經驗。",
                        SpaceStatus = true,
                        Image = "107MoviePic.png",
                        CreateDate = DateTime.Parse("2023/11/25 00:00:00")
                    },
                    new Spaces
                    {
                        SpaceName = "黑盒子劇場",
                        SpaceLocation = "人文社會科學大樓一樓",
                        SpaceCapacity = 100,
                        SpaceDescription = @"黑盒子劇場位於人文社會科學大樓1樓，是桃園地區十分具專業性的小型劇場空間，民國101年1月起由「黑盒子表演藝術中心」專業
                                            團隊規劃成立，民國111年開始由人文藝術中心負責經營管理，期為本校師生量身打造優質表演藝術活動，開拓學生美學視野，為理工學生培養深厚人文蘊涵。
                                            黑盒子劇場有完備的劇場燈光音響及影像設備，除了不斷優化專業場域，更持續活化空間利用，打造表演藝術學習平台，協助學生自主學習。
                                            同時，也是在地小型藝文表演的文創搖藍，每年推出藝術駐校及技術工作坊等活動，另不定期舉辦邀請各中小型劇團演出，讓觀眾可以近距離欣賞多元化表演藝術。",
                        SpaceStatus = true,
                        Image = "BlackBox.png",
                        CreateDate = DateTime.Parse("2023/11/25 00:00:00")
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
