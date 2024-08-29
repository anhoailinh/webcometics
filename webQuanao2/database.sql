
CREATE TABLE [Color] (
    ColorId INT PRIMARY KEY IDENTITY(1,1),
    ColorName NVARCHAR(255) NOT NULL
);

CREATE TABLE [Category] (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL
);

CREATE TABLE [Size] (
    SizeId INT PRIMARY KEY IDENTITY(1,1),
    SizeName NVARCHAR(255) NOT NULL
);
CREATE TABLE [Products] (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX) NOT NULL,
    Descriptionall NVARCHAR(MAX),
    ImageUrl NVARCHAR(255) NOT NULL,
    Img1 NVARCHAR(255) NOT NULL,
    Img2 NVARCHAR(255),
    Img3 NVARCHAR(255),
    Price DECIMAL(18,2) NOT NULL,
    ProductsHot BIT NOT NULL,
    Quatity INT NOT NULL,
    Discount DECIMAL(18,2),
    CategoryID INT NOT NULL,
    ColorId INT,
    SizeId INT,
    FOREIGN KEY (CategoryID) REFERENCES [Category](Id),
    FOREIGN KEY (ColorId) REFERENCES [Color](ColorId),
    FOREIGN KEY (SizeId) REFERENCES [Size](SizeId)
);
CREATE TABLE [User] (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NULL,
    Email NVARCHAR(255) NULL,
    Password NVARCHAR(255) NULL,
    Role NVARCHAR(50) NULL
);
INSERT INTO [User] (Name, Email, Password, Role) VALUES
(N'An Hoài Linh ', N'anlinh@gmail.com', N'123456', N'Administrator'),
(N'Trang', N'trang@gmail.com', N'123456', N'User'),
(N'Lan Anh', N'lananh@gmail.com', N'123456', N'User');


INSERT INTO [Color] (ColorName) VALUES (N'Đen');
INSERT INTO [Color] (ColorName) VALUES (N'Trắng');
INSERT INTO [Color] (ColorName) VALUES (N'Đỏ');
INSERT INTO [Size] (SizeName) VALUES ('S');
INSERT INTO [Size] (SizeName) VALUES ('M');
INSERT INTO [Size] (SizeName) VALUES ('L');
INSERT INTO [Size] (SizeName) VALUES ('XL');

INSERT INTO [Category] ( Name) VALUES ( N'Kem dưỡng ẩm');
INSERT INTO [Category] ( Name) VALUES ( N'Nước tẩy trang');
INSERT INTO [Category] (Name) VALUES (N'Sữa rửa mặt');

INSERT INTO Products (
     Name, Description, Descriptionall, ImageUrl, Img1, Img2, Img3, Price, ProductsHot, Quatity, Discount, CategoryID, ColorId, SizeId
) VALUES 
( N'Gel rửa mặt Cosrx Good Morning 150ml/50ml chiết xuất trà xanh độ ph thấp', N'Hiệu quả sản phẩm:
- Gel rửa mặt có độ pH thấp 4.5 - 5.5 không khô căng da sau khi rửa mặt
- Gel rửa mặt COSRX Good Morning độ pH thấp chứa 0.5% BHA giúp làm sạch da nhẹ nhàng, không gây kích ứng da', N'Hiệu quả sản phẩm:
- Gel rửa mặt có độ pH thấp 4.5 - 5.5 không khô căng da sau khi rửa mặt
- Gel rửa mặt COSRX Good Morning độ pH thấp chứa 0.5% BHA giúp làm sạch da nhẹ nhàng, không gây kích ứng da
- Tinh dầu trà xanh và 0.5% BHA (Betaine Salicylate) kháng khuẩn, hỗ trợ làm sạch mụn, tẩy da chết, làm sạch lỗ chân lông
- Allantoin dưỡng ẩm, làm dịu da, mang lại cảm giác dễ chịu và làm ẩm da sau khi rửa mặt
✅Loại da phù hợp
- Mọi loại da
- Da dầu, nhạy cảm', N'sp1.jpg', N'sp1-1.jpg', N'sp1-2.jpg', N'sp1-3.jpg', 200000, 1, 20, NULL, 3, 2, 2),
( N'Sữa Rửa Mặt Simple lành tính và hiệu quả cho mọi loại da 150ml', N'1, Sữa rửa mặt Simple cấp ẩm (Water Boost) 150ml giúp làm sạch da hiệu quả, loại bỏ bã nhờn, dầu thừa và bụi bẩn trên da.
Chứa Pentavitin, loại chất nhỏ hơn phân tử Hyaluronic Acid gấp 7000 lần
', N'1, Sữa rửa mặt Simple cấp ẩm (Water Boost) 150ml giúp làm sạch da hiệu quả, loại bỏ bã nhờn, dầu thừa và bụi bẩn trên da. 
Chứa Pentavitin, loại chất nhỏ hơn phân tử Hyaluronic Acid gấp 7000 lần, kết hợp cùng Vitamin B5, Glycerin và HA giúp cấp ẩm tức thì, cho làn da đàn hồi và tươi mát.
Phù hợp cho cả làn da nhạy cảm nhất, không gây bít tắc lỗ chân lông.
', N'sp3.jpg', N'sp3-1.jpg', N'sp3-2.jpg', N'sp3-3.jpg', 300000, 1, 30, NULL, 3, 1, 3),
( N'Gel Rửa Mặt SVR Sebiaclear Gel Moussant Hasaki Sản Phẩm Chính Hãng', N'Gel Rửa Mặt SVR Sebiaclear Gel Moussant là sản phẩm sữa rửa mặt dành cho làn da dầu mụn đến từ thương hiệu dược mỹ phẩm SVR, với công thức không chứa xà phòng giúp làm sạch, nhẹ nhàng làm thông thoáng làn da. Khả năng tạo bọt mịn giúp loại trừ các chất bẩn và lượng bã nhờn dư thừa mà không làm khô da. Có thể rửa sạch dễ dàng, mang lại một làn da sạch, tươi mát và khô thoáng.', N'Gel Rửa Mặt SVR Sebiaclear Gel Moussant là sản phẩm sữa rửa mặt dành cho làn da dầu mụn đến từ thương hiệu dược mỹ phẩm SVR, với công thức không chứa xà phòng giúp làm sạch, nhẹ nhàng làm thông thoáng làn da. Khả năng tạo bọt mịn giúp loại trừ các chất bẩn và lượng bã nhờn dư thừa mà không làm khô da. Có thể rửa sạch dễ dàng, mang lại một làn da sạch, tươi mát và khô thoáng.', N'sp4.jpg', N'sp4-1.jpg', N'sp4-2.jpg', N'sp4-3.jpg', 400000, 0, 40, NULL, 3, 3, 4),
( N'Sữa rửa mặt giúp làm sạch sâu dành cho da dầu Cerave Foam Cleanse 473ML', N'CeraVe là nhãn hiệu dưỡng ẩm #1 tại Mỹ được các chuyên gia chăm sóc da khuyên dùng. Vào năm 2005, một hội đồng các bác sĩ, chuyên gia chăm sóc da đã phát triển một công nghệ mới có chứa Ceramides 1, 3 và 6-II (giống hệt với cấu trúc Ceramides được chứng minh thiếu hụt trong một số bệnh về da), axit béo và các chất béo khác được tăng cường với hệ thống phân phối đột phá được gọi là MultiVesicular Emulsion Technology - MVE. Công thức của 3 loại CERAmides thiết yếu và công nghệ mVE là sự ra đời của CeraVe. CeraVe là một trong số ít những nhãn hàng phát triển sản phẩm bởi các bác sĩ nhằm cung cấp các giải pháp trị liệu cho làn da. Với nỗ lực không ngừng nghỉ của mình, nhãn hàng vẫn sẽ tiếp tục đồng hành và phát triển cùng các chuyên gia chăm sóc da để góp phần biến đổi diện mạo ngành chăm sóc da trong nhiều năm tới.', N'CeraVe là nhãn hiệu dưỡng ẩm #1 tại Mỹ được các chuyên gia chăm sóc da khuyên dùng. Vào năm 2005, một hội đồng các bác sĩ, chuyên gia chăm sóc da đã phát triển một công nghệ mới có chứa Ceramides 1, 3 và 6-II (giống hệt với cấu trúc Ceramides được chứng minh thiếu hụt trong một số bệnh về da), axit béo và các chất béo khác được tăng cường với hệ thống phân phối đột phá được gọi là MultiVesicular Emulsion Technology - MVE. Công thức của 3 loại CERAmides thiết yếu và công nghệ mVE là sự ra đời của CeraVe. CeraVe là một trong số ít những nhãn hàng phát triển sản phẩm bởi các bác sĩ nhằm cung cấp các giải pháp trị liệu cho làn da. Với nỗ lực không ngừng nghỉ của mình, nhãn hàng vẫn sẽ tiếp tục đồng hành và phát triển cùng các chuyên gia chăm sóc da để góp phần biến đổi diện mạo ngành chăm sóc da trong nhiều năm tới.', N'sp5.jpg', N'sp5-1.jpg', N'sp5-2.jpg', N'sp5-3.jpg', 500000, 1, 50, NULL, 3, 2, 1),
(
     N'Nước Tẩy Trang Làm Sạch Sâu Cho Da Dầu, Da Nhạy Cảm, Giảm Mụn Bioderma Senbium H2O', N'Nước Tẩy Trang Cho Da Dầu, Da Hỗn Hợp, Da Mụn Bioderma Senbium H2O hiện đã có mặt tại Thế Giới Skinfood cung cấp một giải pháp hoàn toàn mới với dòng sản phẩm Sébium, giúp ngăn ngừa mụn nhờ tác động trực tiếp đến chất lượng bả nhờn, từ đó ngăn ngừa và giảm mụn, giúp bạn duy trì một làn da mịn màng, sáng khỏe.', N'Nước Tẩy Trang Cho Da Dầu, Da Hỗn Hợp, Da Mụn Bioderma Senbium H2O hiện đã có mặt tại Thế Giới Skinfood cung cấp một giải pháp hoàn toàn mới với dòng sản phẩm Sébium, giúp ngăn ngừa mụn nhờ tác động trực tiếp đến chất lượng bả nhờn, từ đó ngăn ngừa và giảm mụn, giúp bạn duy trì một làn da mịn màng, sáng khỏe.', N'sp8.jpg', N'sp8-1.jpg', N'sp8-2.jpg', N'sp8-3.jpg', 400000, 1, 25, NULL, 2, 2, 4
),
(
    N'Nước Tẩy Trang BYPHASSE Solution Micellaire 500ml. - ADELA COMESTIC – NHÀ PHÂN PHỐI CHÍNH THỨC TẠI VIỆT NAM', N'Nước Tẩy Trang BYPHASSE Solution Micellaire Face Loại 500ml
Phù hợp mọi loại da, đặc biệt dành cho da nhạy cảm, da khô, da mẫn đỏ.
Được áp dụng từ công nghệ tiên tiến nên nó có khả năng làm sạch bề mặt da, sử dụng thêm công nghệ mixen, bổ sung thêm nhóm phân tử nano với hai loại đối nghịch nhau.
Thành phần của nước tẩy trang Byphasse không có paraben, không chứa cồn, không dùng phẩm màu và sử dụng các chất dưỡng ẩm như glycerin, propylene glycol, panthenol.', N'Nước Tẩy Trang BYPHASSE Solution Micellaire Face Loại 500ml
Phù hợp mọi loại da, đặc biệt dành cho da nhạy cảm, da khô, da mẫn đỏ.
Được áp dụng từ công nghệ tiên tiến nên nó có khả năng làm sạch bề mặt da, sử dụng thêm công nghệ mixen, bổ sung thêm nhóm phân tử nano với hai loại đối nghịch nhau.
Thành phần của nước tẩy trang Byphasse không có paraben, không chứa cồn, không dùng phẩm màu và sử dụng các chất dưỡng ẩm như glycerin, propylene glycol, panthenol.', N'sp9.jpg', N'sp9-1.jpg', N'sp9-2.jpg', N'sp9-3.jpg', 500000, 0, 20, 50.00, 2, 3, 1
),
(
    N'Nước tẩy trang dưỡng trắng Senka All Clear Water Micellar Formula White 230ml', N'Nước tẩy trang dưỡng trắng Senka All Clear Water Micellar Formula White 230ml không cồn dịu nhẹ cho da giúp làm sạch bụi bẩn, bã nhờn, lớp trang điểm lâu trôi sâu bên trong lỗ chân lông, đồng thời làm mờ vết sạm , dưỡng trắng cho làn da ẩm mịn, sáng rạng rỡ
- Tinh chất Hoa Anh Đào Fuji Nhật Bản giúp nuôi dưỡng làn da trắng sáng tự nhiên
- Chiết xuất Tơ tằm trắng & gấp đôi Hyaluronic Acid dưỡng ẩm
', N'Nước tẩy trang dưỡng trắng Senka All Clear Water Micellar Formula White 230ml không cồn dịu nhẹ cho da giúp làm sạch bụi bẩn, bã nhờn, lớp trang điểm lâu trôi sâu bên trong lỗ chân lông, đồng thời làm mờ vết sạm , dưỡng trắng cho làn da ẩm mịn, sáng rạng rỡ
- Tinh chất Hoa Anh Đào Fuji Nhật Bản giúp nuôi dưỡng làn da trắng sáng tự nhiên
- Chiết xuất Tơ tằm trắng & gấp đôi Hyaluronic Acid dưỡng ẩm
- KHÔNG CỒN. Không chứa dầu. Không màu. Không mùi. Không gây kích ứng.
- Dịu nhẹ - Phù hợp cho mọi loại da, kể cả da nhạy cảm', N'sp10.jpg', N'sp10-1.jpg', N'sp10-2.jpg', N'sp10-3.jpg', 600000, 1, 15, NULL, 2, 1, 2
),
(
    N'Toner Simple Nước Hoa Hồng Tonner cho Da Nhạy Cảm Dầu Mụn ', N'Nước hoa hồng Simple Kind To Skin Soothing Facial giúp cân bằng độ pH cho làn da, giúp da được đưa về độ pH chuẩn , không quá khô, không quá nhờn để chuẩn bị cho các bước dưỡng da tiếp theo được hấp thụ tốt hơn.', N'Nước hoa hồng Simple Kind To Skin Soothing Facial giúp cân bằng độ pH cho làn da, giúp da được đưa về độ pH chuẩn , không quá khô, không quá nhờn để chuẩn bị cho các bước dưỡng da tiếp theo được hấp thụ tốt hơn.', N'sp15.jpg', N'sp15-1.jpg', N'sp15-2.jpg', N'sp15-3.jpg', 700000, 1, 12, NULL, 1, 2, 3
),
( N'Toner Klairs Không Mùi [ CÔNG TY ] Tonner Nước Hoa Hồng Klairs Không Mùi Supple Preparation Unscented Toner 180ML', N'Toner Klairs Không Mùi [ CÔNG TY ] Tonner Nước Hoa Hồng Klairs Không Mùi Supple Preparation Unscented Toner 180ML', N'Toner Klairs Không Mùi [ CÔNG TY ] Tonner Nước Hoa Hồng Klairs Không Mùi Supple Preparation Unscented Toner 180ML', N'sp16.jpg', N'sp16-1.jpg', N'sp16-2.jpg', N'sp16-3.jpg', 800000, 0, 10, 30.00, 1, 1, 2), 
(
  N'Nước hoa hồng Mamonde Toner 250ml - Tonner hoa hồng cấp ẩm, kiềm dầu, se khít lỗ chân lông cao cấp', N'Mamonde Rose Water Toner ( màu hồng ): chiết xuất từ hoa hồng dành cho mọi loại da, có tác dụng dưỡng ẩm và làm sạch sâu da. Da nào dùng cũng được ạ, loại mọi ng hay dùng nhất ý', N'Mamonde Rose Water Toner ( màu hồng ): chiết xuất từ hoa hồng dành cho mọi loại da, có tác dụng dưỡng ẩm và làm sạch sâu da. Da nào dùng cũng được ạ, loại mọi ng hay dùng nhất ý', N'sp17.jpg', N'sp17-1.jpg', N'sp17-2.jpg', N'sp17-3.jpg', 900000, 1, 8, NULL, 1, 3, 1
)

;



