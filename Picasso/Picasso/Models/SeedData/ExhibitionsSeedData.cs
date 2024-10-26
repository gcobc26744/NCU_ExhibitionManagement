using Microsoft.EntityFrameworkCore;
using Picasso.Model;

namespace Picasso.Models.SeedData
{
    public static class ExhibitionsSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ExhibitionManagementDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ExhibitionManagementDbContext>>()))
            {
                // Look for any Exhibitions.
                if (context.Exhibitions.Any())
                {
                    return;   // DB has been seeded
                }

                string SpaceId1 = context.Spaces.Where(s => s.SpaceName.Equals("人文藝術中心")).FirstOrDefault().SpaceId.ToString();
                string SpaceId2 = context.Spaces.Where(s => s.SpaceName.Equals("107電影院")).FirstOrDefault().SpaceId.ToString();
                string SpaceId3 = context.Spaces.Where(s => s.SpaceName.Equals("黑盒子劇場")).FirstOrDefault().SpaceId.ToString();
                string MemberId1 = context.Members.Where(m => m.MemberName.Equals("李溫馨")).FirstOrDefault().MemberId.ToString();
                string MemberId2 = context.Members.Where(m => m.MemberName.Equals("金怡帆")).FirstOrDefault().MemberId.ToString();
                string MemberId3 = context.Members.Where(m => m.MemberName.Equals("楊安沛")).FirstOrDefault().MemberId.ToString();

                context.Exhibitions.AddRange(
                    
                    //人文藝術中心的展覽
                    new Exhibitions
                    {
                        SpaceId = Guid.Parse(SpaceId1),
                        MemberId = Guid.Parse(MemberId1),
                        ExhibitionName = "以土為名的抽象共感－陶藝創作展",
                        ExhibitionType = "陶藝展",
                        StartDate = DateTime.Parse("2023/11/14"), //過去
                        EndDate = DateTime.Parse("2023/12/15"),
                        Organizer = "人文藝術中心",
                        CoOrganizer = "國立臺灣藝術大學工藝設計學系, etc.",
                        ExhibitionDescription = @"陶瓷是人類最為精彩的發明之一，自古以來土與火結合的藝術，成就了人類文明最為綿長而燦爛的篇章。現今的藝術家們持續以陶瓷為媒介，將內在的好奇心、想像力和創造力在以土為名的創作旅程中延續。黏土材料是構成陶瓷作品的骨架，建構在其上的則是藝術家的感性抒發。藝術家的個性和作品表現息息相關，感興趣的題材與元素必定與自身有著緊密的關聯。創作者和材料之間也是平行對應的關係，九位藝術家對於黏土的喜好與情感皆源自於創作實踐過程中的體會，不止於對陶瓷單一維度的思考和觀看，更圍繞著對場域與位面的多元洞析。",
                        ExhibitionStatus = "通過",
                        Image = "以土為名的抽象共感－陶藝創作展_活動海報.png",
                        CreateDate = DateTime.Parse("2023/11/25 00:00:00")
                    },
                    new Exhibitions
                    {
                        SpaceId = Guid.Parse(SpaceId1),
                        MemberId = Guid.Parse(MemberId2),
                        ExhibitionName = "島史：湛藍圖景 - 2023劉子平個展",
                        ExhibitionType = "畫展",
                        StartDate = DateTime.Parse("2023/12/20"), //當前
                        EndDate = DateTime.Parse("2024/01/31"),
                        Organizer = "人文藝術中心",
                        CoOrganizer = "桃園市政府文化局, etc.",
                        ExhibitionDescription = @"無",
                        ExhibitionStatus = "通過",
                        Image = "島史：湛藍圖景 - 2023劉子平個展_活動海報.jpg",
                        CreateDate = DateTime.Parse("2023/11/25 00:00:00")
                    },
                    new Exhibitions
                    {
                        SpaceId = Guid.Parse(SpaceId1),
                       MemberId = Guid.Parse(MemberId3),
                        ExhibitionName = "迴相 Reflection",
                        ExhibitionType = "畫展",
                        StartDate = DateTime.Parse("2024/02/01"), //未來
                        EndDate = DateTime.Parse("2024/02/28"),
                        Organizer = "人文藝術中心",
                        CoOrganizer = "好思當代",
                        ExhibitionDescription = @"「迴向」是佛教極為殊勝的功德修行，意指將自身累積的功德迴轉，利益他人或法界。本展援引「迴向」一詞，並以諧音「相」取而代之，企圖展現個體迴返過往存在之實踐，也就是說，今日之「相」為昨日之萬象所積累，未來之「相」為今日所存之萬象所造就。
                                                本展覽由策展人張玉美集結八位藝術家的創作，包括榮嘉文化藝術基金會典藏精選李小鏡、徐冰、張洹、鄭在東，另也邀請何孟娟、施力嘉、黃少葳、黃嘉寧共同展出。主要探討藝術家如何透過創作描述「身體」，重新體現自身、他者之「相」。展覽分成四子題為「生之存有」、「家人自寫」、「人、居演化」、「人慾禮教」，並以豐富且多元的作品媒材和表現形式，為展覽場域創造眾相聚集且互融的樣態。企圖由此四子題展開生存的辯證，呈現個體於過去、現在與未來生存、生活之相。",
                        ExhibitionStatus = "通過",
                        Image = "迴相 Reflection_活動海報.jpg",
                        CreateDate = DateTime.Parse("2023/11/25 00:00:00")
                    },
                    new Exhibitions
                    {
                        SpaceId = Guid.Parse(SpaceId1),
                        MemberId = Guid.Parse(MemberId1),
                        ExhibitionName = "食人之界 - 梁廷毓 個展",
                        ExhibitionType = "畫展",
                        StartDate = DateTime.Parse("2024/03/25"), //未來
                        EndDate = DateTime.Parse("2024/04/12"),
                        Organizer = "人文藝術中心",
                        CoOrganizer = "桃園市政府文化局",
                        ExhibitionDescription = @"同類相殘者（Cannibals）一詞在近世之後被賦予了明確意義，使用於殖民者遭逢到的難纏族類，以及被視為抵制、挑釁外地商人和定居者的非人野獸。19世紀發生於北台灣淺山地帶漢人武裝聚落的食人行為，在殖民者眼中同樣令人無法直視。這一處「食人之界」，在本展覽中指向漢人侵墾、移住歷史上，處在界線另一端原住民群體的反視，但也不僅如此。作為「斷頭河計畫」的一部分，延續藝術家梁廷毓過去的《番肉考》（众藝術Zone Art，2018），以及〈龍潭、關西地區的「食番肉」記憶〉（第十屆客家文化傳承與發展學術研討會，2019）等文論及展演發表。圍繞在北臺灣淺山地帶的「食番肉」傳聞，除了對不同語言權力的歷史文本背後之觀察者視角的重新演繹，也藉由客家、閩南、原住民人群之間關於食人者（anthropophagus）的敘事，在視覺、氣味、口感、觸感等感官記憶（sensory memory）之口述歷史取徑，藉由影像、裝置等方式，推測在地者、當事者（閩、客居民）傳述的主觀經驗和現場性描述，進行肉塊、頭顱、屍骨等「非人之物」作為歷史行動者的史學編撰，以及地理空間中的鬼魅、食人史和定居殖民思維之間的潛在聯繫。",
                        ExhibitionStatus = "通過",
                        Image = "食人之界 - 梁廷毓 個展_活動海報.jpg",
                        CreateDate = DateTime.Parse("2023/11/25 00:00:00")
                    },
                    new Exhibitions
                    {
                        SpaceId = Guid.Parse(SpaceId1),
                        MemberId = Guid.Parse(MemberId2),
                        ExhibitionName = "恐龍國度傳說",
                        ExhibitionType = "畫展",
                        StartDate = DateTime.Parse("2024/03/04"), //未來
                        EndDate = DateTime.Parse("2024/03/16"),
                        Organizer = "人文藝術中心",
                        CoOrganizer = "國際科技協會",
                        ExhibitionDescription = @"科技與未來的結合。",
                        ExhibitionStatus = "失敗",
                        Image = "恐龍國度傳說_活動海報.jpg",
                        CreateDate = DateTime.Parse("2023/11/25 00:00:00")
                    },
                    new Exhibitions
                    {
                        SpaceId = Guid.Parse(SpaceId1),
                        MemberId = Guid.Parse(MemberId2),
                        ExhibitionName = "夢幻旅行秘境",
                        ExhibitionType = "畫展",
                        StartDate = DateTime.Parse("2024/04/15"), //未來
                        EndDate = DateTime.Parse("2024/04/19"),
                        Organizer = "人文藝術中心",
                        CoOrganizer = "藝術博物館",
                        ExhibitionDescription = @"自然歷史的深入了解。",
                        ExhibitionStatus = "待審核",
                        Image = "夢幻旅行秘境_活動海報.jpg",
                        CreateDate = DateTime.Parse("2023/11/25 00:00:00")
                    },

                    //107電影院的展覽
                    new Exhibitions
                    {
                        SpaceId = Guid.Parse(SpaceId2),
                        MemberId = Guid.Parse(MemberId1),
                        ExhibitionName = "凝視蔡明亮的日子——《不散》數位修復版特映與講座",
                        ExhibitionType = "影音展覽",
                        StartDate = DateTime.Parse("2023/12/04"), //過去
                        EndDate = DateTime.Parse("2023/12/05"),
                        Organizer = "人文藝術中心, etc.",
                        CoOrganizer = "台灣電影研究中心, etc.",
                        ExhibitionDescription = @"本次活動由國立中央大學文學院學士班、人文藝術中心、台灣電影研究中心與視覺文化研究中心共同主辦，於10/4放映《不散》數位修復版及邀請法文系高滿德老師映後座談，並在10/5歡迎茶會後舉辦蔡明亮導演專場講座！",
                        ExhibitionStatus = "通過",
                        Image = "凝視蔡明亮的日子_活動海報.png",
                        CreateDate = DateTime.Parse("2023/11/25 00:00:00")
                    },
                    new Exhibitions
                    {
                        SpaceId = Guid.Parse(SpaceId2),
                        MemberId = Guid.Parse(MemberId2),
                        ExhibitionName = "《新寶島曼波》放映會暨映後座談會",
                        ExhibitionType = "影音展覽",
                        StartDate = DateTime.Parse("2023/12/07 15:00:00"), //過去
                        EndDate = DateTime.Parse("2023/12/08 18:00:00"),
                        Organizer = "人文藝術中心",
                        CoOrganizer = "無",
                        ExhibitionDescription = @"本片堪稱年度音樂片。由年輕的繆夫人樂團擔綱創作演出，本片的五首主題曲皆來自楊澤的新舊詩作，由詩人特別為片中的人物、情節而設，而寫。拍片期間同步完成的另外幾首未入歌的詩，則以朗讀的形式穿插出現於片中。電影呈現老中青三代音樂創作者同台飆歌的盛況，包括代表新世代的女主角陳塵（小匚）、女配角怪少女林纓、中生代原住民歌手巴奈、毛恩足、月琴傳藝師張日貴阿嬤，從詩朗讀到新詩新唱，到老歌重唱，一系列從島嶼台灣靈魂深處發出的告白及見證，帶領島上眾人齊聚一堂，引頸高歌，一詠三嘆，迎向山海，共譜《新寶島曼波》的靈動樂章。這部由詩人楊澤自編自導自演的新形態紀錄片，不折不扣是詩人楊澤獻給生長島嶼及海洋的一首「大情歌」。",
                        ExhibitionStatus = "通過",
                        Image = "新寶島曼波_放映會暨映後座談會.jpg",
                        CreateDate = DateTime.Parse("2023/11/25 00:00:00")
                    },
                    new Exhibitions
                    {
                        SpaceId = Guid.Parse(SpaceId2),
                        MemberId = Guid.Parse(MemberId3),
                        ExhibitionName = "樂來越愛你 La La Land（0+）",
                        ExhibitionType = "影音展覽",
                        StartDate = DateTime.Parse("2024/01/22 18:00:00"), //未來
                        EndDate = DateTime.Parse("2024/01/26 21:00:00"),
                        Organizer = "人文藝術中心",
                        CoOrganizer = "無",
                        ExhibitionDescription = @"無",
                        ExhibitionStatus = "通過",
                        Image = "NoPictures.png",
                        CreateDate = DateTime.Parse("2023/11/25 00:00:00")
                    },
                    new Exhibitions
                    {
                        SpaceId = Guid.Parse(SpaceId2),
                        MemberId = Guid.Parse(MemberId1),
                        ExhibitionName = "下一站，天國 After Life（0+）",
                        ExhibitionType = "影音展覽",
                        StartDate = DateTime.Parse("2024/01/15 18:00:00"), //未來
                        EndDate = DateTime.Parse("2024/01/19 21:00:00"),
                        Organizer = "人文藝術中心",
                        CoOrganizer = "無",
                        ExhibitionDescription = @"無",
                        ExhibitionStatus = "通過",
                        Image = "NoPictures.png",
                        CreateDate = DateTime.Parse("2023/11/25 00:00:00")
                    },
                    new Exhibitions
                    {
                        SpaceId = Guid.Parse(SpaceId2),
                        MemberId = Guid.Parse(MemberId2),
                        ExhibitionName = "全面啟動 Inception（6+)",
                        ExhibitionType = "影音展覽",
                        StartDate = DateTime.Parse("2023/12/20 18:00:00"), //當前
                        EndDate = DateTime.Parse("2023/12/29 21:00:00"),
                        Organizer = "人文藝術中心",
                        CoOrganizer = "無",
                        ExhibitionDescription = @"無",
                        ExhibitionStatus = "通過",
                        Image = "NoPictures.png",
                        CreateDate = DateTime.Parse("2023/11/25 00:00:00")
                    },
                    new Exhibitions
                    {
                        SpaceId = Guid.Parse(SpaceId2),
                        MemberId = Guid.Parse(MemberId2),
                        ExhibitionName = "機器人奇蹟秘境",
                        ExhibitionType = "影音展覽",
                        StartDate = DateTime.Parse("2024/05/15 18:00:00"), //未來
                        EndDate = DateTime.Parse("2024/05/17 21:00:00"),
                        Organizer = "人文藝術中心",
                        CoOrganizer = "視覺藝術中心",
                        ExhibitionDescription = @"現代攝影藝術作品展。",
                        ExhibitionStatus = "待審核",
                        Image = "機器人奇蹟秘境_活動海報.jpg",
                        CreateDate = DateTime.Parse("2023/11/25 00:00:00")
                    },
                    new Exhibitions
                    {
                        SpaceId = Guid.Parse(SpaceId2),
                        MemberId = Guid.Parse(MemberId2),
                        ExhibitionName = "航海工程秘境",
                        ExhibitionType = "影音展覽",
                        StartDate = DateTime.Parse("2024/05/20 18:00:00"), //未來
                        EndDate = DateTime.Parse("2024/05/24 21:00:00"),
                        Organizer = "人文藝術中心",
                        CoOrganizer = "科技創新中心",
                        ExhibitionDescription = @"科技與未來的結合。",
                        ExhibitionStatus = "通過",
                        Image = "航海工程秘境_活動海報.jpg",
                        CreateDate = DateTime.Parse("2023/11/25 00:00:00")
                    },

                    //黑盒子劇場的展覽
                    new Exhibitions
                    {
                        SpaceId = Guid.Parse(SpaceId3),
                        MemberId = Guid.Parse(MemberId1),
                        ExhibitionName = "統計音樂劇《玫瑰的數字》",
                        ExhibitionType = "影音展覽",
                        StartDate = DateTime.Parse("2023/09/22 15:00:00"), //過去
                        EndDate = DateTime.Parse("2023/09/22 18:00:00"),
                        Organizer = "EDU創作社",
                        CoOrganizer = "人文藝術中心",
                        ExhibitionDescription = @"「統計音樂劇《玫瑰的數字》是寓教於樂的成功例子，以淺顯易懂且帶著趣味的演出方式，讓大眾能清楚地了解南丁格爾在統計方面的貢獻．．．」——國內知名音樂劇部落客Daisy",
                        ExhibitionStatus = "通過",
                        Image = "玫瑰的故事_活動海報.jpg",
                        CreateDate = DateTime.Parse("2023/11/25 00:00:00")
                    },
                    new Exhibitions
                    {
                        SpaceId = Guid.Parse(SpaceId3),
                        MemberId = Guid.Parse(MemberId2),
                        ExhibitionName = "海島演劇2023人權遊台灣《開在壁上的花》",
                        ExhibitionType = "影音展覽",
                        StartDate = DateTime.Parse("2024/03/20 14:30:00"), //未來
                        EndDate = DateTime.Parse("2024/03/22 17:00:00"),
                        Organizer = "國家人權博物館, etc.",
                        CoOrganizer = "人文藝術中心",
                        ExhibitionDescription = @"「一齣戲，也是一段歷史……」
                                                簡國賢，留日攻讀戲劇，國民政府接收後，見台灣人依舊遭受二等公民的差別待遇，開始創作「壁」等針貶貪腐的戲劇作品，被迫流亡。
                                                楊國宇，舞台劇「壁」公演時參與幫忙，十分喜愛並深受感動。高三一天凌晨，兩位男子請他幫忙找人，與母親一別就是10年⋯⋯
                                                林秋祥，簡國賢養女之兄，夜裡警察敲門來找，他告訴父親「沒事的」即被關入監牢。為救兒子，富裕的家境被騙一空，淪落負債。
                                                國民政府來台不久，228事件、白色恐怖如大浪襲來，改變了台灣、以及三個桃園人的命運⋯⋯",
                        ExhibitionStatus = "通過",
                        Image = "開在壁上的花_活動海報.jpg",
                        CreateDate = DateTime.Parse("2023/11/25 00:00:00")
                    },
                    new Exhibitions
                    {
                        SpaceId = Guid.Parse(SpaceId3),
                        MemberId = Guid.Parse(MemberId3),
                        ExhibitionName = "台北曲藝團《北曲．三十而麗》",
                        ExhibitionType = "影音展覽",
                        StartDate = DateTime.Parse("2023/12/25 19:30:00"), //現在
                        EndDate = DateTime.Parse("2023/12/29 21:30:00"),
                        Organizer = "台北曲藝團",
                        CoOrganizer = "人文藝術中心",
                        ExhibitionDescription = @"回望30．致敬北曲．再現經典
                                                台北曲藝團成立至今屆滿三十週年，回望30，曾與臺灣初代相聲大師吳兆南、魏龍豪並肩前行、歷經第二代相聲演員郭志傑、朱德剛、樊光耀、葉怡均等曲藝演員崛起，其後藝心一意、笑傳說唱三十載，不但書寫了臺灣相聲發展史，也濡養了第三代青年相聲演員，時至今日，北曲已成為臺灣曲藝演員陣容最堅強的藝術團隊。《三十而麗》是一場回望經典、原音重現的幽默製作，以「台北曲藝團30年來做了那些無可替代的事情」為主軸，帶領觀眾來一場記憶洄游，展現台北曲藝團的標誌、貢獻與唯一性，在歡笑中致敬前輩、緬懷故人，希望在疫常時代，無論老觀眾還是新朋友，都能因相聲淘盡煩惱、忘憂大笑！",
                        ExhibitionStatus = "通過",
                        Image = "台北曲藝團_北曲三十而麗.jpg",
                        CreateDate = DateTime.Parse("2023/11/25 00:00:00")
                    },
                    new Exhibitions
                    {
                        SpaceId = Guid.Parse(SpaceId3),
                        MemberId = Guid.Parse(MemberId2),
                        ExhibitionName = "時間旅行之旅之謎",
                        ExhibitionType = "影音展覽",
                        StartDate = DateTime.Parse("2024/01/25 19:30:00"), //未來
                        EndDate = DateTime.Parse("2024/01/26 21:30:00"),
                        Organizer = "人文發展中心",
                        CoOrganizer = "人文藝術中心",
                        ExhibitionDescription = @"科技與未來的結合。",
                        ExhibitionStatus = "通過",
                        Image = "時間旅行之旅之謎_活動海報.jpg",
                        CreateDate = DateTime.Parse("2023/11/25 00:00:00")
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
