using ECom.DataAccess.Data;
using ECom.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace ECom.Utility;

public class ApplicationDbContextSeedData
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetService<ApplicationDbContext>();
        var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
        string[] roles = new string[] { StaticDetail.RoleUser, StaticDetail.RoleAdmin };
        foreach (var role in roles)
        {
            if (!context.Roles.Any(x => x.Name == role))
            {
                context.Roles.Add(new ApplicationRole()
                {
                    Name = role,
                    NormalizedName = role.ToUpper(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                });
            }

            context.SaveChanges();
        }

        if (!context.UserRoles.Any(x =>
                x.RoleId == context.Roles.FirstOrDefault(r => r.Name == StaticDetail.RoleAdmin).Id))
        {

            var user = new ApplicationUser
            {
                UserName = StaticDetail.AdminEmail,
                Email = StaticDetail.AdminEmail,
                EmailConfirmed = true
            };
            await userManager.CreateAsync(user, StaticDetail.AdminPassword);
            await userManager.AddToRoleAsync(user, StaticDetail.RoleAdmin);
            context.SaveChanges();
        }

        if (!context.Manufactures.Any())
        {
            var lst = new List<Manufacture>()
            {
                new Manufacture
                {
                    Name = "Apple"
                },
                new Manufacture
                {
                    Name = "Oppo"
                },
                new Manufacture
                {
                    Name = "Samsung"
                },
                new Manufacture
                {
                    Name = "Sony"
                },
                new Manufacture
                {
                    Name = "OnePlus"
                },
                new Manufacture
                {
                    Name = "Vivo"
                },
                new Manufacture
                {
                    Name = "Xiaomi"
                },
                new Manufacture
                {
                    Name = "Realme"
                }

            };
            context.Manufactures.AddRange(lst);
            context.SaveChanges();
        }

        if (!context.Categories.Any())
        {
            var lst = new List<Category>()
            {
                new Category
                {
                    Name = "Điện thoại"
                },
                new Category
                {
                    Name = "Sạc, cáp"
                },
                new Category
                {
                    Name = "Tai nghe"
                },
                new Category
                {
                    Name = "Ốp lưng điện thoại"
                },
                new Category
                {
                    Name = "Khác"
                },
            };
            context.Categories.AddRange(lst);
            context.SaveChanges();
        }
            if (!context.Products.Any())
            {
            var list = new List<Product>()
                {
                    new Product
                    {
                        Name = "Apple iPhone 11",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 1,
                        ManufactureId = 1,
                        Description = "Apple đã chính thức trình làng bộ 3 siêu phẩm iPhone 11, trong đó phiên bản iPhone 11 64GB có mức giá rẻ nhất nhưng vẫn được nâng cấp mạnh mẽ như iPhone Xr ra mắt trước đó.",
                        Price = 14990000,
                        Discount = 0.16m,
                        Quantity = 9999,
                        ImageUrl = "/img/featured/iPhone11.jpg",
                        IsDeleted = false,
                    },
                    new Product
                    {
                        Name = "Apple iPhone 13 Pro Max",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 1,
                        ManufactureId = 1,
                        Description = "iPhone 13 Pro Max 128 GB - siêu phẩm được mong chờ nhất ở nửa cuối năm 2021 đến từ Apple. Máy có thiết kế không mấy đột phá khi so với người tiền nhiệm, bên trong đây vẫn là một sản phẩm có màn hình siêu đẹp, tần số quét được nâng cấp lên 120 Hz mượt mà, cảm biến camera có kích thước lớn hơn, cùng hiệu năng mạnh mẽ với sức mạnh đến từ Apple A15 Bionic, sẵn sàng cùng bạn chinh phục mọi thử thách.",
                        Price = 36990000,
                        Discount = 0.12m,
                        Quantity = 9999,
                        ImageUrl = "/img/featured/iphone13promax.jpg",
                        IsDeleted = false,
                    },
                    new Product
                    {
                        Name = "Apple iPhone 13 Pro",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 1,
                        ManufactureId = 1,
                        Description = "Mỗi lần ra mắt phiên bản mới là mỗi lần iPhone chiếm sóng trên khắp các mặt trận và lần này cái tên khiến vô số người sục sôi là iPhone 13 Pro, chiếc điện thoại thông minh vẫn giữ nguyên thiết kế cao cấp, cụm 3 camera được nâng cấp, cấu hình mạnh mẽ cùng thời lượng pin lớn ấn tượng.",
                        Price = 30990000,
                        Discount = 0.11m,
                        Quantity = 9999,
                        ImageUrl = "/img/featured/iphone13pro.jpg",
                        IsDeleted = false,
                    },
                    new Product
                    {
                        Name = "Apple iPhone SE 2022",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 1,
                        ManufactureId = 1,
                        Description = "Mỗi lần ra mắt phiên bản mới là mỗi lần iPhone chiếm sóng trên khắp các mặt trận và lần này cái tên khiến vô số người sục sôi là iPhone 13 Pro, chiếc điện thoại thông minh vẫn giữ nguyên thiết kế cao cấp, cụm 3 camera được nâng cấp, cấu hình mạnh mẽ cùng thời lượng pin lớn ấn tượng.",
                        Price = 13990000,
                        Discount = 0.07m,
                        Quantity = 9999,
                        ImageUrl = "img/featured/iphone-se-white-600x600.jpg",
                        IsDeleted = false,
                    },
                    new Product
                    {
                        Name = "Apple iPhone XR",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 1,
                        ManufactureId = 1,
                        Description = "Được xem là phiên bản iPhone giá rẻ đầy hoàn hảo, iPhone Xr 128GB khiến người dùng có nhiều sự lựa chọn hơn về màu sắc đa dạng nhưng vẫn sở hữu cấu hình mạnh mẽ và thiết kế sang trọng.",
                        Price = 13490000,
                        Discount = 0,
                        Quantity = 9999,
                        ImageUrl = "img/featured/xr.jpg",
                        IsDeleted = false,
                    },
                    new Product
                    {
                        Name = "Oppo Reno5 5G",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 1,
                        ManufactureId = 2,
                        Description = "OPPO đã trình làng OPPO Reno5 5G phiên bản kết nối 5G internet siêu nhanh ra thị trường. Chiếc điện thoại với hàng loạt các tính năng nổi bật cùng vẻ ngoài thời thượng giúp tôn lên vẻ sang trọng cho người sở hữu.",
                        Price = 11990000,
                        Discount = 0.29m,
                        Quantity = 9999,
                        ImageUrl = "img/featured/reno5.jpg",
                        IsDeleted = false,
                    },
                    new Product
                    {
                        Name = "OPPO Reno4 Pro",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 1,
                        ManufactureId = 2,
                        Description = "OPPO chính thức trình làng chiếc smartphone có tên OPPO Reno4 Pro. Máy trang bị cấu hình vô cùng cao cấp với vi xử lý chip Snapdragon 720G, bộ 4 camera đến 48 MP ấn tượng, cùng công nghệ sạc siêu nhanh 65 W nhưng được bán với mức giá vô ưu đãi, dễ tiếp cận.",
                        Price = 10490000,
                        Discount = 0.23m,
                        Quantity = 9999,
                        ImageUrl = "img/featured/reno4.jpg",
                        IsDeleted = false,
                    },
                    new Product
                    {
                        Name = "Oppo Reno6 5G",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 1,
                        ManufactureId = 2,
                        Description = "Sau khi ra mắt OPPO Reno5 chưa lâu thì OPPO lại cho ra mẫu smartphone mới mang tên OPPO Reno6 với hàng loạt cải tiến mới về ngoại hình bên ngoài lẫn hiệu năng bên trong, mang đến trải nghiệm vượt bật cho người dùng.",
                        Price = 12990000,
                        Discount = 0.15m,
                        Quantity = 9999,
                        ImageUrl = "img/featured/opporeno6.jpg",
                        IsDeleted = false,
                    },
                    new Product
                    {
                        Name = "Oppo Reno7 5G",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 1,
                        ManufactureId = 2,
                        Description = "Tiếp nối sự thành công của dòng sản phẩm Reno, OPPO cho ra mắt Reno7 5G với cải tiến đáng kể về phần camera, sở hữu một thiết kế bắt mắt cùng một hiệu năng mạnh mẽ giúp bạn có được những trải nghiệm vô cùng tuyệt vời trên mọi tác vụ. ",
                        Price = 12990000,
                        Discount = 0m,
                        Quantity = 9999,
                        ImageUrl = "img/featured/opporeno7.jpg",
                        IsDeleted = false,
                    },
                    new Product
                    {
                        Name = "Realme 8",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 1,
                        ManufactureId = 8,
                        Description = "Điện thoại Realme 8 được ra mắt nằm trong phân khúc tầm trung, có thiết kế đẹp mắt đặc trưng của Realme, smartphone trang bị hiệu năng bên trong đầy mạnh mẽ và có dung lượng pin tương đối lớn.",
                        Price = 7290000,
                        Discount = 0m,
                        Quantity = 9999,
                        ImageUrl = "img/featured/realme8.jpg",
                        IsDeleted = false,
                    },
                    new Product
                    {
                        Name = "Realme 9 Pro",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 1,
                        ManufactureId = 8,
                        Description = "Realme 9 Pro - chiếc điện thoại tầm trung được Realme giới thiệu với thiết kế phản quang hoàn toàn mới, máy có một vẻ ngoài năng động, hiệu năng mạnh mẽ, cụm camera AI 64 MP và một tốc độ sạc ổn định.",
                        Price = 7990000,
                        Discount = 0m,
                        Quantity = 9999,
                        ImageUrl = "img/featured/realme9pro.jpg",
                        IsDeleted = false,
                    },
                    new Product
                    {
                        Name = "Realme C35",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 1,
                        ManufactureId = 8,
                        Description = "Realme 9 Pro - chiếc điện thoại tầm trung được Realme giới thiệu với thiết kế phản quang hoàn toàn mới, máy có một vẻ ngoài năng động, hiệu năng mạnh mẽ, cụm camera AI 64 MP và một tốc độ sạc ổn định.",
                        Price = 4290000,
                        Discount = 0m,
                        Quantity = 9999,
                        ImageUrl = "img/featured/realmec35.jpg",
                        IsDeleted = false,
                    },
                    new Product
                    {
                        Name = "Samsung Galaxy A03",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 1,
                        ManufactureId = 3,
                        Description = "Samsung Galaxy A03 4GB có thiết kế vân đan chéo trẻ trung, sở hữu camera độ phân giải đến 48 MP, pin thoải mái sử dụng trong một ngày và đây cũng là sản phẩm dòng A đầu tiên ra mắt năm 2022 của Samsung tại thị trường Việt Nam.",
                        Price = 2990000,
                        Discount = 0m,
                        Quantity = 9999,
                        ImageUrl = "img/featured/samsung-galaxy-a03-xanh-thumb-600x600.jpg",
                        IsDeleted = false,
                    },
                    new Product
                    {
                        Name = "Điện thoại Samsung Galaxy A52s 5G",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 1,
                        ManufactureId = 3,
                        Description = "Samsung đã chính thức giới thiệu chiếc điện thoại Galaxy A52s 5G đến người dùng, đây phiên bản nâng cấp của Galaxy A52 5G ra mắt cách đây không lâu, với ngoại hình không đổi nhưng được nâng cấp đáng kể về thông số cấu hình bên trong.",
                        Price = 10990000,
                        Discount = 0.18m,
                        Quantity = 9999,
                        ImageUrl = "img/featured/samsung-galaxy-a52s-5g-mint-600x600.jpg",
                        IsDeleted = false,
                    },
                    new Product
                    {
                        Name = "Samsung Galaxy Note 20",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 1,
                        ManufactureId = 3,
                        Description = "Tháng 8/2020, smartphone Galaxy Note 20 chính thức được lên kệ, với thiết kế camera trước nốt ruồi quen thuộc, cụm camera hình chữ nhật mới lạ cùng với vi xử lý Exynos 990 cao cấp của chính hãng điện thoại Samsung chắc hẳn sẽ mang lại một trải nghiệm thú vị cùng hiệu năng mạnh mẽ.",
                        Price = 23990000,
                        Discount = 0.33m,
                        Quantity = 9999,
                        ImageUrl = "img/featured/samsung-galaxy-note-20-062220-122200-fix-600x600.jpg",
                        IsDeleted = false,
                    },
                    new Product
                    {
                        Name = "Samsung Galaxy S21+ 5G",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 1,
                        ManufactureId = 3,
                        Description = "Tháng 8/2020, smartphone Galaxy Note 20 chính thức được lên kệ, với thiết kế camera trước nốt ruồi quen thuộc, cụm camera hình chữ nhật mới lạ cùng với vi xử lý Exynos 990 cao cấp của chính hãng điện thoại Samsung chắc hẳn sẽ mang lại một trải nghiệm thú vị cùng hiệu năng mạnh mẽ.",
                        Price = 25990000,
                        Discount = 0.30m,
                        Quantity = 9999,
                        ImageUrl = "img/featured/samsung-galaxy-s21-plus-bac-600x600-600x600.jpg",
                        IsDeleted = false,
                    },
                    new Product
                    {
                        Name = "Samsung Galaxy S22 Ultra 5G",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 1,
                        ManufactureId = 3,
                        Description = "Galaxy S22 Ultra 5G chiếc smartphone cao cấp nhất trong bộ 3 Galaxy S22 series mà Samsung đã cho ra mắt. Tích hợp bút S Pen hoàn hảo trong thân máy, trang bị vi xử lý mạnh mẽ cho các tác vụ sử dụng vô cùng mượt mà và nổi bật hơn với cụm camera không viền độc đáo mang đậm dấu ấn riêng.",
                        Price = 30990000,
                        Discount = 0,
                        Quantity = 9999,
                        ImageUrl = "img/featured/samsunggalaxys22ultra5g.jpg",
                        IsDeleted = false,
                    },
                    new Product
                    {
                        Name = "Samsung Galaxy Z Flip3 5G",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 1,
                        ManufactureId = 3,
                        Description = "Trong sự kiện Galaxy Unpacked hồi 11/8, Samsung đã chính thức trình làng mẫu điện thoại màn hình gập thế hệ mới mang tên Galaxy Z Flip3 5G 128GB. Đây là một siêu phẩm với màn hình gập dạng vỏ sò cùng nhiều điểm cải tiến và thông số ấn tượng, sản phẩm chắc chắn sẽ thu hút được rất nhiều sự quan tâm của người dùng, đặc biệt là phái nữ.",
                        Price = 24990000,
                        Discount = 0.12m,
                        Quantity = 9999,
                        ImageUrl = "img/featured/samsung-galaxy-z-flip-3-cream-1-600x600.jpg",
                        IsDeleted = false,
                    },
                    new Product
                    {
                        Name = "Samsung Galaxy Z Fold3 5G",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 1,
                        ManufactureId = 3,
                        Description = "Galaxy Z Fold3 5G, chiếc điện thoại được nâng cấp toàn diện về nhiều mặt, đặc biệt đây là điện thoại màn hình gập đầu tiên trên thế giới có camera ẩn (08/2021). Sản phẩm sẽ là một “cú hit” của Samsung góp phần mang đến những trải nghiệm mới cho người dùng.",
                        Price = 33990000,
                        Discount = 0.19m,
                        Quantity = 9999,
                        ImageUrl = "img/featured/samsung-galaxy-z-fold-3-silver-1-600x600.jpg",
                        IsDeleted = false,
                    },
                    new Product
                    {
                        Name = "Vivo V21 5G",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 1,
                        ManufactureId = 6,
                        Description = "Chụp selfie bùng nổ trong đêm, thiết kế mới hiện đại đón đầu xu hướng, cùng với đó là tốc độ kết nối mạng 5G hàng đầu, tất cả những tính năng ấn tượng này đều có trong Vivo V21 5G mẫu điện thoại cận cao cấp đến từ Vivo.",
                        Price = 8890000,
                        Discount = 0.12m,
                        Quantity = 9999,
                        ImageUrl = "img/featured/vivo-v21-5g-xanh-den-600x600.jpg",
                        IsDeleted = false,
                    },
                    new Product
                    {
                        Name = "Vivo Y15s",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 1,
                        ManufactureId = 6,
                        Description = "Vivo vừa mang một chiến binh mới đến phân khúc tầm trung giá rẻ có tên Vivo Y15s, một sản phẩm sở hữu khá nhiều ưu điểm như thiết kế đẹp, màn hình lớn, camera kép, pin cực trâu và còn rất nhiều điều thú vị khác đang chờ đón bạn.",
                        Price = 3490000,
                        Discount = 0,
                        Quantity = 9999,
                        ImageUrl = "img/featured/Vivo-y15s-2021-xanh-den-660x600.jpg",
                        IsDeleted = false,
                    },
                    new Product
                    {
                        Name = "Xiaomi 11T Pro 5G",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 1,
                        ManufactureId = 7,
                        Description = "Xiaomi 11T Pro 5G 8GB sử dụng con chip Snapdragon 888 mạnh mẽ, camera chính 108 MP, hỗ trợ sạc nhanh 120 W, màn hình rộng với tốc độ làm tươi lên đến 120 Hz, tận hưởng trải nghiệm tuyệt vời trong từng khoảnh khắc.",
                        Price = 13990000,
                        Discount = 0,
                        Quantity = 9999,
                        ImageUrl = "img/featured/xiaomi-11t-pro-5g-8gb-thumb-600x600.jpeg",
                        IsDeleted = false,
                    },
                    new Product
                    {
                        Name = "Xiaomi 11T 5G",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 1,
                        ManufactureId = 7,
                        Description = "Xiaomi 11T đầy nổi bật với thiết kế vô cùng trẻ trung, màn hình AMOLED, bộ 3 camera sắc nét và viên pin lớn đây sẽ là mẫu smartphone của Xiaomi thỏa mãn mọi nhu cầu giải trí, làm việc và là niềm đam mê sáng tạo của bạn. ",
                        Price = 10990000,
                        Discount = 0.1m,
                        Quantity = 9999,
                        ImageUrl = "img/featured/Xiaomi-11T-White-1-2-3-600x600.jpg",
                        IsDeleted = false,
                    },
                    new Product
                    {
                        Name = "Xiaomi 12",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 1,
                        ManufactureId = 7,
                        Description = "Xiaomi đang dần khẳng định chỗ đứng của mình trong phân khúc điện thoại flagship bằng việc ra mắt Xiaomi 12 với bộ thông số ấn tượng, máy có một thiết kế gọn gàng, hiệu năng mạnh mẽ, màn hình hiển thị chi tiết cùng khả năng chụp ảnh sắc nét nhờ trang bị ống kính đến từ Sony.",
                        Price = 20990000,
                        Discount = 0.05m,
                        Quantity = 9999,
                        ImageUrl = "img/featured/Xiaomi-12-xam-thumb-mau-600x600.jpg",
                        IsDeleted = false,
                    },
                    new Product
                    {
                        Name = "Xiaomi Redmi Note 11 Pro",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 1,
                        ManufactureId = 7,
                        Description = "Xiaomi Redmi Note 11 Pro 4G mang trong mình khá nhiều những nâng cấp cực kì sáng giá. Là chiếc điện thoại có màn hình lớn, tần số quét 120 Hz, hiệu năng ổn định cùng một viên pin siêu trâu.",
                        Price = 7490000,
                        Discount = 0.03m,
                        Quantity = 9999,
                        ImageUrl = "img/featured/xiaomi-redmi-note-11-pro-trang-thumb-600x600.jpg",
                        IsDeleted = false,
                    },
                    new Product
                    {
                        Name = "Xiaomi Redmi Note 11 Pro",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 1,
                        ManufactureId = 7,
                        Description = "Xiaomi Redmi Note 11 Pro 4G mang trong mình khá nhiều những nâng cấp cực kì sáng giá. Là chiếc điện thoại có màn hình lớn, tần số quét 120 Hz, hiệu năng ổn định cùng một viên pin siêu trâu.",
                        Price = 7490000,
                        Discount = 0.03m,
                        Quantity = 9999,
                        ImageUrl = "img/featured/xiaomi-redmi-note-11-pro-trang-thumb-600x600.jpg",
                        IsDeleted = false,
                    },
                    new Product
                    {
                        Name = "Đế sạc không dây Qi 10W Mbest AC63F3 Đen",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 2,
                        Description = "",
                        Price = 175000,
                        Discount = 0.0m,
                        Quantity = 9999,
                        ImageUrl = "img/featured/saccap/sac-khong-day-qi-10w-mbest-ac63f3-den-avatar-1-600x600.jpg",
                        IsDeleted = false,
                    },
                    new Product
                    {
                        Name = "Tai nghe Bluetooth True Wireless AVA+ DS200A-WB",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 3,
                        Description = "",
                        Price = 315000,
                        Discount = 0.0m,
                        Quantity = 9999,
                        ImageUrl = "img/featured/tainghe/bluetooth-true-wireless-ava-ds200a-wb-thumb-600x600.png",
                        IsDeleted = false,
                    },
                    new Product
                    {
                        Name = "Cáp Type C - Lightning 1m Apple MM0A3 Trắng",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 2,
                        Description = "",
                        Price = 300000,
                        Discount = 0.05m,
                        Quantity = 9999,
                        ImageUrl = "img/featured/tainghe/bluetooth-mozard-k8-thumb-600x600.jpeg",
                        IsDeleted = false,
                    },
                    new Product
                    {
                        Name = "Tai nghe Bluetooth Mozard K8",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 3,
                        Description = "",
                        Price = 499000,
                        Discount = 0.0m,
                        Quantity = 9999,
                        ImageUrl = "img/featured/saccap/cap-type-c-lightning-1m-apple-mm0a3-trang-thumb-600x600.jpeg",
                        IsDeleted = false,
                    },
                    new Product
                    {
                        Name = "Cáp Lightning 1m Hydrus CS-C-021",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 2,
                        Description = "",
                        Price = 60000,
                        Discount = 0,
                        Quantity = 9999,
                        ImageUrl = "img/featured/saccap/caplightning1mhydruscs-c-021-ava-600x600.jpg",
                        IsDeleted = false,
                    },
                    new Product
                    {
                        Name = "Túi chống nước Cosano JMG-C-21 Xanh biển",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 5,
                        Description = "",
                        Price = 25000,
                        Discount = 0,
                        Quantity = 9999,
                        ImageUrl = "img/featured/khac/tui-chong-nuoc-cosano-jmg-c-21-xanh-bien-add-600x600.jpg",
                        IsDeleted = false,
                    },
                    new Product
                    {
                        Name = "Tai nghe Bluetooth JLab JBuds Pro Signature Đen",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 3,
                        Description = "",
                        Price = 570000,
                        Discount = 0,
                        Quantity = 9999,
                        ImageUrl = "img/featured/tainghe/bluetooth-jlab-jbuds-pro-signature-thumb-600x600.jpeg",
                        IsDeleted = false,
                    },
                    new Product
                    {
                        Name = "Tai nghe Bluetooth JLab JBuds Pro Signature Đen",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 3,
                        Description = "",
                        Price = 600000,
                        Discount = 0.1m,
                        Quantity = 9999,
                        ImageUrl = "img/featured/tainghe/bluetooth-jlab-jbuds-pro-signature-thumb-600x600.jpeg",
                        IsDeleted = false,
                    },
                    new Product
                    {
                        Name = "Pin sạc dự phòng 7.500 mAh AVA+ DS005-PP",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 2,
                        Description = "",
                        Price = 520000,
                        Discount = 0,
                        Quantity = 9999,
                        ImageUrl = "img/featured/saccap/ava-plus-ds005-pp-ava-600x600.jpg",
                        IsDeleted = false,
                    },
                    new Product
                    {
                        Name = "Tai nghe Bluetooth True Wireless Rezo F15",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 3,
                        Description = "",
                        Price = 560000,
                        Discount = 0,
                        Quantity = 9999,
                        ImageUrl = "img/featured/tainghe/bluetooth-true-wireless-rezo-f15-thumb-600x600.jpeg",
                        IsDeleted = false,
                    },
                     new Product
                    {
                        Name = "Tai nghe Bluetooth AirPods Pro MagSafe Charge Apple MLWK3 Trắng",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 3,
                        Description = "",
                        Price = 4990000,
                        Discount = 0.05m,
                        Quantity = 9999,
                        ImageUrl = "img/featured/tainghe/bluetooth-airpods-pro-magsafe-charge-apple-mlwk3-thumb-600x600.jpg",
                        IsDeleted = false,
                    },
                     new Product
                    {
                        Name = "Adapter Sạc Type C 20W dùng cho iPhone/iPad Apple MHJE3 Trắng",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 2,
                        Description = "",
                        Price = 520000,
                        Discount = 0.05m,
                        Quantity = 9999,
                        ImageUrl = "img/featured/saccap/adapter-sac-type-c-20w-cho-iphone-ipad-apple-mhje3-avatar-1-1-600x600.jpg",
                        IsDeleted = false,
                    },
                      new Product
                    {
                        Name = "Bộ 2 móc điện thoại OSMIA CK-CRS10 Mèo cá heo xanh",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 5,
                        Description = "",
                        Price = 30000,
                        Discount = 0,
                        Quantity = 9999,
                        ImageUrl = "img/featured/khac/bo-2-moc-dien-thoai-osmia-ck-crs10-meo-ca-heo-xanhava-600x600.jpg",
                        IsDeleted = false,
                    },
                      new Product
                    {
                        Name = "Tai nghe Bluetooth AirPods 3 Apple MME73 Trắng",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 3,
                        Description = "",
                        Price = 5490000,
                        Discount = 0,
                        Quantity = 9999,
                        ImageUrl = "img/featured/tainghe/airpods-3-hop-sac-khong-day-thumb-600x600.jpeg",
                        IsDeleted = false,
                    },
                       new Product
                    {
                        Name = "Ốp lưng Nhựa dẻo Realme C35 TPU TechLife",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 4,
                        Description = "",
                        Price = 99000,
                        Discount = 0,
                        Quantity = 9999,
                        ImageUrl = "img/featured/oplung/op-lung-nhua-deo-realme-c35-tpu-techlife-thumb-600x600.jpg",
                        IsDeleted = false,
                    },
                       new Product
                    {
                        Name = "Adapter sạc 2 cổng Type C PD QC3.0 18W Xmobile QP-1EU Trắng",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 2,
                        Description = "",
                        Price = 210000,
                        Discount = 0,
                        Quantity = 9999,
                        ImageUrl = "img/featured/saccap/adapter-sac-2-cong-type-c-pd-qc30-xmobile-qp-1eu-avatar-1-600x600.jpg",
                        IsDeleted = false,
                    },
                       new Product
                    {
                        Name = "Bộ 2 móc điện thoại OSMIA CK-CRS34 Xanh hồng",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 5,
                        Description = "",
                        Price = 30000,
                        Discount = 0,
                        Quantity = 9999,
                        ImageUrl = "img/featured/khac/bo-2-moc-dien-thoai-osmia-ck-crs34-xanh-hongava-600x600.jpg",
                        IsDeleted = false,
                    },
                       new Product
                    {
                        Name = "Ốp lưng MagSafe iPhone 13 Pro Max Nhựa dẻo Apple MM2P3",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 4,
                        Description = "",
                        Price = 795000,
                        Discount = 0,
                        Quantity = 9999,
                        ImageUrl = "img/featured/oplung/op-lung-magsafe-iphone-13-pro-max-nhua-deo-apple-mm2p3-160122-074022-600x600.jpg",
                        IsDeleted = false,
                    },
                        new Product
                    {
                        Name = "Adapter Bluetooth Xmobile BT14",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 2,
                        Description = "",
                        Price = 234000,
                        Discount = 0,
                        Quantity = 9999,
                        ImageUrl = "img/featured/saccap/adapter-bluetooth-xmobile-bt14-den-avatar-1-600x600.jpg",
                        IsDeleted = false,
                    },
                        new Product
                    {
                        Name = "Tai nghe Bluetooth Mozard Flex4 Đen Xanh",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 3,
                        Description = "",
                        Price = 244000,
                        Discount = 0,
                        Quantity = 9999,
                        ImageUrl = "img/featured/tainghe/tai-nghe-bluetooth-mozard-flex4-den-xanh-thumb-2-600x600.jpeg",
                        IsDeleted = false,
                    },
                        new Product
                    {
                        Name = "Đế điện thoại xe hơi Vent mount Pro With MagSafe Belkin WIC002btGR Bạc",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 2,
                        Description = "",
                        Price = 795000,
                        Discount = 0,
                        Quantity = 9999,
                        ImageUrl = "img/featured/khac/de-dien-thoai-xe-hoi-magsafe-belkin-wic002btgr-041121-085128-600x600.jpg",
                        IsDeleted = false,
                    },
                         new Product
                    {
                        Name = "Ốp lưng MagSafe iPhone 13 Pro Max Da Apple MM1R3",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 4,
                        Description = "",
                        Price = 895000,
                        Discount = 0,
                        Quantity = 9999,
                        ImageUrl = "img/featured/oplung/op-lung-magsafe-iphone-13-pro-max-da-apple-mm1r3-160122-042316-600x600.jpg",
                        IsDeleted = false,
                    },
                         new Product
                    {
                        Name = "Đế điện thoại xe hơi Vent mount Belkin F7U017BT Đen",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 2,
                        Description = "",
                        Price = 384000,
                        Discount = 0,
                        Quantity = 9999,
                        ImageUrl = "img/featured/khac/de-dien-thoai-xe-hoi-vent-mount-belkin-f7u017bt-den-thumb-600x600.jpg",
                        IsDeleted = false,
                    },
                         new Product
                    {
                        Name = "Ốp lưng Galaxy S22 Ultra Nhựa cứng viền dẻo Samsung",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 4,
                        Description = "",
                        Price = 531000,
                        Discount = 0,
                        Quantity = 9999,
                        ImageUrl = "img/featured/oplung/op-lung-galaxy-s22-ultra-nhua-cung-vien-deo-samsung-thumb-600x600.jpg",
                        IsDeleted = false,
                    },
                         new Product
                    {
                        Name = "Tai nghe Bluetooth Kanen K6",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 3,
                        Description = "",
                        Price = 500000,
                        Discount = 0.15m,
                        Quantity = 9999,
                        ImageUrl = "img/featured/tainghe/tai-nghe-bluetooth-kanen-k6-thumb-600x600.jpeg",
                        IsDeleted = false,
                    },
                         new Product
                    {
                        Name = "Ốp lưng Galaxy S22 Silicone Samsung Forest",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 4,
                        Description = "",
                        Price = 700000,
                        Discount = 0.1m,
                        Quantity = 9999,
                        ImageUrl = "img/featured/oplung/op-lung-galaxy-s22-silicone-samsung-xanh-forest-1.-600x600.jpg",
                        IsDeleted = false,
                    },
                         new Product
                    {
                        Name = "Túi chống nước Cosano JMG-C-20 Xanh lá",
                        ReleaseDate = DateTime.Now,
                        CategoryId = 5,
                        Description = "",
                        Price = 25000,
                        Discount = 0,
                        Quantity = 9999,
                        ImageUrl = "img/featured/khac/tui-chong-nuoc-cosano-jmg-c-20-xanh-la-add-600x600.jpg",
                        IsDeleted = false,
                    },
                };

                {
                    context.Products.AddRange(list);
                    context.SaveChanges();
                }
            }
        }
    }