
-- Category Table
If Not Exists(select top 1 * from [Core].[Category])
Begin 
Set Identity_insert [Core].[category] On
INSERT INTO [Core].[Category]	([CategoryId],[Name],[Description],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	values (1, 'English', 'This content is made for English learning', 1, 'Initial Setup', GETDATE(), 'Initial Setup', getdate())
INSERT INTO [Core].[Category]	([CategoryId],[Name],[Description],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	values (2, 'Physics', 'This content is made for Physics learning', 1, 'Initial Setup', GETDATE(), 'Initial Setup', getdate())
INSERT INTO [Core].[Category]	([CategoryId],[Name],[Description],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	values (3, 'Chemistry', 'This content is made for Chemistry learning', 1, 'Initial Setup', GETDATE(), 'Initial Setup', getdate())
INSERT INTO [Core].[Category]	([CategoryId],[Name],[Description],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	values (4, 'History', 'This content is made for History knowledge', 1, 'Initial Setup', GETDATE(), 'Initial Setup', getdate())
INSERT INTO [Core].[Category]	([CategoryId],[Name],[Description],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	values (5, 'Mathematics', 'This content is made for Mathematics learning', 1, 'Initial Setup', GETDATE(), 'Initial Setup', getdate())
INSERT INTO [Core].[Category]	([CategoryId],[Name],[Description],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	values (6, 'Biology', 'This content is made for Biology learning', 1, 'Initial Setup', GETDATE(), 'Initial Setup', getdate())
INSERT INTO [Core].[Category]	([CategoryId],[Name],[Description],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	values (7, 'Computer Science', 'This content is made for Computer Science learning', 1, 'Initial Setup', GETDATE(), 'Initial Setup', getdate())
INSERT INTO [Core].[Category]	([CategoryId],[Name],[Description],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	values (8, 'civil engineering', 'This content is made for Civil Engineering learning', 1, 'Initial Setup', GETDATE(), 'Initial Setup', getdate())
INSERT INTO [Core].[Category]	([CategoryId],[Name],[Description],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	values (9, 'Data analytics', 'This content is made for Data analytics learning', 1, 'Initial Setup', GETDATE(), 'Initial Setup', getdate())
Set Identity_insert [Core].[category] Off
End


-- Brand Table
If Not Exists(select top 1 * from [Core].[Brand])
Begin 
Set Identity_insert [Core].[Brand] On
INSERT INTO [Core].[Brand]	([BrandId],[Name],[Description],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	values (1, 'AAkash', 'This content is made by Akash for mathematics', 1, 'Initial Setup', GETDATE(), 'Initial Setup', getdate())
INSERT INTO [Core].[Brand]	([BrandId],[Name],[Description],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	values (2, 'BHU', 'This content is made by BHU for physics BHU', 1, 'Initial Setup', GETDATE(), 'Initial Setup', getdate())
INSERT INTO [Core].[Brand]	([BrandId],[Name],[Description],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	values (3, 'ABC Engineering', 'This content is made by ABC Engineers for Civil', 1, 'Initial Setup', GETDATE(), 'Initial Setup', getdate())
INSERT INTO [Core].[Brand]	([BrandId],[Name],[Description],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	values (4, 'University of PQR', 'This content is made by PQR university for history', 1, 'Initial Setup', GETDATE(), 'Initial Setup', getdate())
INSERT INTO [Core].[Brand]	([BrandId],[Name],[Description],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	values (5, 'JRS T', 'This content is made by JRS for Chemistry', 1, 'Initial Setup', GETDATE(), 'Initial Setup', getdate())
INSERT INTO [Core].[Brand]	([BrandId],[Name],[Description],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	values (6, 'BITS', 'This content is made by Bits for BITS Civil', 1, 'Initial Setup', GETDATE(), 'Initial Setup', getdate())
INSERT INTO [Core].[Brand]	([BrandId],[Name],[Description],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	values (7, 'Analytics Insight', 'This content is made to understand data analytics', 1, 'Initial Setup', GETDATE(), 'Initial Setup', getdate())
INSERT INTO [Core].[Brand]	([BrandId],[Name],[Description],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	values (8, 'Universty of History education', 'This content is made to understand history', 1, 'Initial Setup', GETDATE(), 'Initial Setup', getdate())
Set Identity_insert [Core].[Brand] Off
End

-- SubCategory

If Not Exists(select top 1 * from [Core].[SubCategory])
Begin 
Set Identity_insert [Core].[SubCategory] On
INSERT INTO [Core].[SubCategory]	([SubCategoryId],[Name],[CategoryId],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	values (1, 'ABC Topic', 1, 1, 'Initial Setup', GETDATE(), 'Initial Setup', getdate())
INSERT INTO [Core].[SubCategory]	([SubCategoryId],[Name],[CategoryId],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	values (2, 'A Topic', 2, 1, 'Initial Setup', GETDATE(), 'Initial Setup', getdate())
INSERT INTO [Core].[SubCategory]	([SubCategoryId],[Name],[CategoryId],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	values (3, 'B Topic', 3, 1, 'Initial Setup', GETDATE(), 'Initial Setup', getdate())
INSERT INTO [Core].[SubCategory]	([SubCategoryId],[Name],[CategoryId],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	values (4, 'C Topic', 4, 1, 'Initial Setup', GETDATE(), 'Initial Setup', getdate())
INSERT INTO [Core].[SubCategory]	([SubCategoryId],[Name],[CategoryId],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	values (5, 'X Topic', 1, 1, 'Initial Setup', GETDATE(), 'Initial Setup', getdate())
Set Identity_insert [Core].[SubCategory] Off
End

-- Section

If Not Exists(select top 1 * from [Core].[Section])
Begin 
Set Identity_insert [Core].[Section] On
INSERT INTO [Core].[Section]	([SectionId],[Name], [Description],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	values (1,'X Section ', 'This is specificially in abc section', 1, 'Initial Setup', GETDATE(), 'Initial Setup', getdate())
INSERT INTO [Core].[Section]	([SectionId],[Name], [Description],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	values (2,'Y Section ', 'This is specificially in abc section', 1, 'Initial Setup', GETDATE(), 'Initial Setup', getdate())
INSERT INTO [Core].[Section]	([SectionId],[Name], [Description],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	values (3,'Z Section ', 'This is specificially in abc section', 1, 'Initial Setup', GETDATE(), 'Initial Setup', getdate())
INSERT INTO [Core].[Section]	([SectionId],[Name], [Description],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	values (4,'P Section ', 'This is specificially in abc section', 1, 'Initial Setup', GETDATE(), 'Initial Setup', getdate())
INSERT INTO [Core].[Section]	([SectionId],[Name], [Description],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	values (5,'Q Section ', 'This is specificially in abc section', 1, 'Initial Setup', GETDATE(), 'Initial Setup', getdate())
INSERT INTO [Core].[Section]	([SectionId],[Name], [Description],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	values (6,'T Section ', 'This is specificially in abc section', 1, 'Initial Setup', GETDATE(), 'Initial Setup', getdate())
INSERT INTO [Core].[Section]	([SectionId],[Name], [Description],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	values (7,'S Section ', 'This is specificially in abc section', 1, 'Initial Setup', GETDATE(), 'Initial Setup', getdate())
Set Identity_insert [Core].[Section] Off
End

-- Grade


If Not Exists(select top 1 * from [Core].[Grade])
Begin 
Set Identity_insert [Core].[Grade] On
INSERT INTO [Core].[Grade]	([GradeId],[Name], [Description],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	values (1,' 10thGrade', 'This is good material for x grade', 1, 'Initial Setup', GETDATE(), 'Initial Setup', getdate())
INSERT INTO [Core].[Grade]	([GradeId],[Name], [Description],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	values (2,' 11thGrade', 'This is good material for x grade', 1, 'Initial Setup', GETDATE(), 'Initial Setup', getdate())
INSERT INTO [Core].[Grade]	([GradeId],[Name], [Description],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	values (3,' 12thGrade', 'This is good material for x grade', 1, 'Initial Setup', GETDATE(), 'Initial Setup', getdate())
INSERT INTO [Core].[Grade]	([GradeId],[Name], [Description],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	values (4,' Graduation 1st year', 'This is good material for x grade', 1, 'Initial Setup', GETDATE(), 'Initial Setup', getdate())
INSERT INTO [Core].[Grade]	([GradeId],[Name], [Description],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	values (5,' Graduation 2nd year', 'This is good material for x grade', 1, 'Initial Setup', GETDATE(), 'Initial Setup', getdate())
INSERT INTO [Core].[Grade]	([GradeId],[Name], [Description],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	values (6,' Graduation 3rd year', 'This is good material for x grade', 1, 'Initial Setup', GETDATE(), 'Initial Setup', getdate())
INSERT INTO [Core].[Grade]	([GradeId],[Name], [Description],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	values (7,' Masters 1st year', 'This is good material for x grade', 1, 'Initial Setup', GETDATE(), 'Initial Setup', getdate())
INSERT INTO [Core].[Grade]	([GradeId],[Name], [Description],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	values (8,' Phd Research', 'This is good material for x grade', 1, 'Initial Setup', GETDATE(), 'Initial Setup', getdate())
Set Identity_insert [Core].[Grade] Off
End

If Not Exists(select top 1 * from [Core].[Product])
Begin 
Set Identity_insert [Core].[Product] On
INSERT INTO [Core].[Product]	([ProductId],[Title], [Name], [Description], [Price], [CategoryId],[SubCategoryId],[GradeId],[SectionId],[BrandId],[ShortPictureUrl],[PictureUrl],[ProductManufacturer],[ProductManufacturerPicture],[ProductManufacturerProfile],[DocumentUrl],[DocumentType],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	VALUES(1, 'The Color Purpul', 'The Color Purpul: The classic ','The Color Purpul : The classic, Pulitzer Prize - winning novel', 149.21, 1, 1, 1, 1, 1, 'https://www.amazon.in/gp/product/147460725X', 'https://www.abc.com/images/colorpurple', 'Alice Walker', 'https://www.abc.com/Images/Manufacturer/Alice', 'https://www.abc.com/Profile/Manufacturer/Alice', 'https://www.abc.com/product/colorpurple_1238-xxxx-1234-eyzx.pdf', 1, 1, 'Initial setup', GETDATE(), 'Initial Setup', GETDATE())
INSERT INTO [Core].[Product]	([ProductId],[Title], [Name], [Description], [Price], [CategoryId],[SubCategoryId],[GradeId],[SectionId],[BrandId],[ShortPictureUrl],[PictureUrl],[ProductManufacturer],[ProductManufacturerPicture],[ProductManufacturerProfile],[DocumentUrl],[DocumentType],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	VALUES(2, 'NE-Physics-8', 'NE-Physics-8 ','NE-Physics Bok binding', 277.73, 1, 2,3, 1, 4, 'https://www.amazon.in/gp/product/B0848TTVGC', 'https://www.abc.com/images/colorpurple', 'Nooton', 'https://www.abc.com/Images/Manufacturer/Alice', 'https://www.abc.com/Profile/Manufacturer/Alice', 'https://www.abc.com/product/colorpurple_1238-xxxx-1234-eyzx.pdf', 1, 1, 'Initial setup', GETDATE(), 'Initial Setup', GETDATE())
INSERT INTO [Core].[Product]	([ProductId],[Title], [Name], [Description], [Price], [CategoryId],[SubCategoryId],[GradeId],[SectionId],[BrandId],[ShortPictureUrl],[PictureUrl],[ProductManufacturer],[ProductManufacturerPicture],[ProductManufacturerProfile],[DocumentUrl],[DocumentType],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	VALUES(3, 'Advance Problem in Organic Chemistry', 'Advance Problem in Organic Chemistry for JEE','Advance Problem in Organic Chemistry with solution 14\e (2020-2021) session', 575.00, 1, 3, 4,5, 3, 'https://www.amazon.in/gp/product/147460725X', 'https://www.abc.com/images/colorpurple', 'Alice Walker', 'https://www.abc.com/Images/Manufacturer/Alice', 'https://www.abc.com/Profile/Manufacturer/Alice', 'https://www.abc.com/product/colorpurple_1238-xxxx-1234-eyzx.pdf', 1, 1, 'Initial setup', GETDATE(), 'Initial Setup', GETDATE())
INSERT INTO [Core].[Product]	([ProductId],[Title], [Name], [Description], [Price], [CategoryId],[SubCategoryId],[GradeId],[SectionId],[BrandId],[ShortPictureUrl],[PictureUrl],[ProductManufacturer],[ProductManufacturerPicture],[ProductManufacturerProfile],[DocumentUrl],[DocumentType],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	VALUES(4, 'The mathematics of life', 'Mathematics  in the given world','Mathematics changes the life of norman human', 179.25, 5, 2, 4, 4, 4, 'https://www.amazon.in/gp/product/147460725X', 'https://www.abc.com/images/colorpurple', 'Alice Walker', 'https://www.abc.com/Images/Manufacturer/Alice', 'https://www.abc.com/Profile/Manufacturer/Alice', 'https://www.abc.com/product/colorpurple_1238-xxxx-1234-eyzx.pdf', 1, 1, 'Initial setup', GETDATE(), 'Initial Setup', GETDATE())
INSERT INTO [Core].[Product]	([ProductId],[Title], [Name], [Description], [Price], [CategoryId],[SubCategoryId],[GradeId],[SectionId],[BrandId],[ShortPictureUrl],[PictureUrl],[ProductManufacturer],[ProductManufacturerPicture],[ProductManufacturerProfile],[DocumentUrl],[DocumentType],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	VALUES(5, 'Birth of computer science', 'Birth of computer science','compter comes into the existence to be a family member', 149.21, 7, 4, 2, 4, 1, 'https://www.amazon.in/gp/product/147460725X', 'https://www.abc.com/images/colorpurple', 'Alice Walker', 'https://www.abc.com/Images/Manufacturer/Alice', 'https://www.abc.com/Profile/Manufacturer/Alice', 'https://www.abc.com/product/colorpurple_1238-xxxx-1234-eyzx.pdf', 1, 1, 'Initial setup', GETDATE(), 'Initial Setup', GETDATE())
INSERT INTO [Core].[Product]	([ProductId],[Title], [Name], [Description], [Price], [CategoryId],[SubCategoryId],[GradeId],[SectionId],[BrandId],[ShortPictureUrl],[PictureUrl],[ProductManufacturer],[ProductManufacturerPicture],[ProductManufacturerProfile],[DocumentUrl],[DocumentType],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	VALUES(6, 'The art of construction', 'The art of construction','Construction is also all about art', 149.21, 2, 1, 1, 1, 1, 'https://www.amazon.in/gp/product/147460725X', 'https://www.abc.com/images/colorpurple', 'Alice Walker', 'https://www.abc.com/Images/Manufacturer/Alice', 'https://www.abc.com/Profile/Manufacturer/Alice', 'https://www.abc.com/product/colorpurple_1238-xxxx-1234-eyzx.pdf', 1, 1, 'Initial setup', GETDATE(), 'Initial Setup', GETDATE())
INSERT INTO [Core].[Product]	([ProductId],[Title], [Name], [Description], [Price], [CategoryId],[SubCategoryId],[GradeId],[SectionId],[BrandId],[ShortPictureUrl],[PictureUrl],[ProductManufacturer],[ProductManufacturerPicture],[ProductManufacturerProfile],[DocumentUrl],[DocumentType],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	VALUES(7, 'All about machines', 'Machine and its begenning ','Machine started helpin human life not only for good but for bad also', 149.21, 5, 1, 2, 3, 4, 'https://www.amazon.in/gp/product/147460725X', 'https://www.abc.com/images/colorpurple', 'Alice Walker', 'https://www.abc.com/Images/Manufacturer/Alice', 'https://www.abc.com/Profile/Manufacturer/Alice', 'https://www.abc.com/product/colorpurple_1238-xxxx-1234-eyzx.pdf', 1, 1, 'Initial setup', GETDATE(), 'Initial Setup', GETDATE())
INSERT INTO [Core].[Product]	([ProductId],[Title], [Name], [Description], [Price], [CategoryId],[SubCategoryId],[GradeId],[SectionId],[BrandId],[ShortPictureUrl],[PictureUrl],[ProductManufacturer],[ProductManufacturerPicture],[ProductManufacturerProfile],[DocumentUrl],[DocumentType],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	VALUES(8, 'Machine and the human', 'Machine and the human ','Machine taking path to make human life better', 224.90, 4, 1, 1, 1, 1, 'https://www.amazon.in/gp/product/147460725X', 'https://www.abc.com/images/colorpurple', 'Alice Walker', 'https://www.abc.com/Images/Manufacturer/Alice', 'https://www.abc.com/Profile/Manufacturer/Alice', 'https://www.abc.com/product/colorpurple_1238-xxxx-1234-eyzx.pdf', 1, 1, 'Initial setup', GETDATE(), 'Initial Setup', GETDATE())
INSERT INTO [Core].[Product]	([ProductId],[Title], [Name], [Description], [Price], [CategoryId],[SubCategoryId],[GradeId],[SectionId],[BrandId],[ShortPictureUrl],[PictureUrl],[ProductManufacturer],[ProductManufacturerPicture],[ProductManufacturerProfile],[DocumentUrl],[DocumentType],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	VALUES(9, 'Data analytics', 'Data for analysis','The better the data the better the anaysis become and the better result', 449.75, 5, 1, 1, 1, 1, 'https://www.amazon.in/gp/product/147460725X', 'https://www.abc.com/images/colorpurple', 'Alice Walker', 'https://www.abc.com/Images/Manufacturer/Alice', 'https://www.abc.com/Profile/Manufacturer/Alice', 'https://www.abc.com/product/colorpurple_1238-xxxx-1234-eyzx.pdf', 1, 1, 'Initial setup', GETDATE(), 'Initial Setup', GETDATE())
INSERT INTO [Core].[Product]	([ProductId],[Title], [Name], [Description], [Price], [CategoryId],[SubCategoryId],[GradeId],[SectionId],[BrandId],[ShortPictureUrl],[PictureUrl],[ProductManufacturer],[ProductManufacturerPicture],[ProductManufacturerProfile],[DocumentUrl],[DocumentType],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	VALUES(10, 'Physics and universe', 'Physics and universe','How the physics is connected with universe and so is the infiniy', 779.25, 2, 2, 3, 4, 5, 'https://www.amazon.in/gp/product/147460725X', 'https://www.abc.com/images/colorpurple', 'Alice Walker', 'https://www.abc.com/Images/Manufacturer/Alice', 'https://www.abc.com/Profile/Manufacturer/Alice', 'https://www.abc.com/product/colorpurple_1238-xxxx-1234-eyzx.pdf', 1, 1, 'Initial setup', GETDATE(), 'Initial Setup', GETDATE())
INSERT INTO [Core].[Product]	([ProductId],[Title], [Name], [Description], [Price], [CategoryId],[SubCategoryId],[GradeId],[SectionId],[BrandId],[ShortPictureUrl],[PictureUrl],[ProductManufacturer],[ProductManufacturerPicture],[ProductManufacturerProfile],[DocumentUrl],[DocumentType],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	VALUES(11, 'Bond of organic compound', 'Organic Chemistry','Explains all the kind of bonding occurs  in Organic chemistry', 249.50, 3, 5,4, 3, 2, 'https://www.amazon.in/gp/product/147460725X', 'https://www.abc.com/images/colorpurple', 'Alice Walker', 'https://www.abc.com/Images/Manufacturer/Alice', 'https://www.abc.com/Profile/Manufacturer/Alice', 'https://www.abc.com/product/colorpurple_1238-xxxx-1234-eyzx.pdf', 1, 1, 'Initial setup', GETDATE(), 'Initial Setup', GETDATE())
INSERT INTO [Core].[Product]	([ProductId],[Title], [Name], [Description], [Price], [CategoryId],[SubCategoryId],[GradeId],[SectionId],[BrandId],[ShortPictureUrl],[PictureUrl],[ProductManufacturer],[ProductManufacturerPicture],[ProductManufacturerProfile],[DocumentUrl],[DocumentType],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	VALUES(12, 'Knight and the king', 'Knight and the king','Good to learn and understand english', 249.50, 3, 5,4, 3, 2, 'https://www.amazon.in/gp/product/147460725X', 'https://www.abc.com/images/colorpurple', 'Alice Walker', 'https://www.abc.com/Images/Manufacturer/Alice', 'https://www.abc.com/Profile/Manufacturer/Alice', 'https://www.abc.com/product/colorpurple_1238-xxxx-1234-eyzx.pdf', 1, 1, 'Initial setup', GETDATE(), 'Initial Setup', GETDATE())
INSERT INTO [Core].[Product]	([ProductId],[Title], [Name], [Description], [Price], [CategoryId],[SubCategoryId],[GradeId],[SectionId],[BrandId],[ShortPictureUrl],[PictureUrl],[ProductManufacturer],[ProductManufacturerPicture],[ProductManufacturerProfile],[DocumentUrl],[DocumentType],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	VALUES(13, 'The Number system', 'The number system','All about numbers', 171.00, 5, 4, 4, 4, 4, 'https://www.amazon.in/gp/product/147460725X', 'https://www.abc.com/images/colorpurple', 'Alice Walker', 'https://www.abc.com/Images/Manufacturer/Alice', 'https://www.abc.com/Profile/Manufacturer/Alice', 'https://www.abc.com/product/colorpurple_1238-xxxx-1234-eyzx.pdf', 1, 1, 'Initial setup', GETDATE(), 'Initial Setup', GETDATE())
INSERT INTO [Core].[Product]	([ProductId],[Title], [Name], [Description], [Price], [CategoryId],[SubCategoryId],[GradeId],[SectionId],[BrandId],[ShortPictureUrl],[PictureUrl],[ProductManufacturer],[ProductManufacturerPicture],[ProductManufacturerProfile],[DocumentUrl],[DocumentType],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	VALUES(14, 'Data for BI Reports', 'BI Report with Data ','Data binding among different kind of BI Reports', 790.00, 9, 1, 1, 1, 1, 'https://www.amazon.in/gp/product/147460725X', 'https://www.abc.com/images/colorpurple', 'Alice Walker', 'https://www.abc.com/Images/Manufacturer/Alice', 'https://www.abc.com/Profile/Manufacturer/Alice', 'https://www.abc.com/product/colorpurple_1238-xxxx-1234-eyzx.pdf', 1, 1, 'Initial setup', GETDATE(), 'Initial Setup', GETDATE())
INSERT INTO [Core].[Product]	([ProductId],[Title], [Name], [Description], [Price], [CategoryId],[SubCategoryId],[GradeId],[SectionId],[BrandId],[ShortPictureUrl],[PictureUrl],[ProductManufacturer],[ProductManufacturerPicture],[ProductManufacturerProfile],[DocumentUrl],[DocumentType],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	VALUES(15, 'The Human evolution', 'Time and the man','Evolution of the human', 450.25, 4, 4,2,3, 3, 'https://www.amazon.in/gp/product/147460725X', 'https://www.abc.com/images/colorpurple', 'Alice Walker', 'https://www.abc.com/Images/Manufacturer/Alice', 'https://www.abc.com/Profile/Manufacturer/Alice', 'https://www.abc.com/product/colorpurple_1238-xxxx-1234-eyzx.pdf', 1, 1, 'Initial setup', GETDATE(), 'Initial Setup', GETDATE())
INSERT INTO [Core].[Product]	([ProductId],[Title], [Name], [Description], [Price], [CategoryId],[SubCategoryId],[GradeId],[SectionId],[BrandId],[ShortPictureUrl],[PictureUrl],[ProductManufacturer],[ProductManufacturerPicture],[ProductManufacturerProfile],[DocumentUrl],[DocumentType],[IsActive],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])	VALUES(16, 'History of India', 'History Of India by British ','Explain the indian time during 17th and 18th centuaries', 740.50, 4, 5, 4, 2, 1, 'https://www.amazon.in/gp/product/147460725X', 'https://www.abc.com/images/colorpurple', 'Alice Walker', 'https://www.abc.com/Images/Manufacturer/Alice', 'https://www.abc.com/Profile/Manufacturer/Alice', 'https://www.abc.com/product/colorpurple_1238-xxxx-1234-eyzx.pdf', 1, 1, 'Initial setup', GETDATE(), 'Initial Setup', GETDATE())

Set Identity_insert [Core].[Product] Off
End


--  [Order].[DeliveryMethod]

If Not Exists(select top 1 1 from [Order].[DeliveryMethod])
Begin 
Set Identity_insert [Order].[DeliveryMethod] On
INSERT INTO [Order].[DeliveryMethod]	([DeliveryMethodId],[ShortName], [Description],[DeliveryTime],[Price],[IsActive])	values (1, 'Self Receive', 'Individual should go to the respectivce locaation and collect it', '2 Days', 0.00, 1)
INSERT INTO [Order].[DeliveryMethod]	([DeliveryMethodId],[ShortName], [Description],[DeliveryTime],[Price],[IsActive])	values (2, 'Normal Post', 'Send it by goverment post office', '30 Days', 40.00, 1)
INSERT INTO [Order].[DeliveryMethod]	([DeliveryMethodId],[ShortName], [Description],[DeliveryTime],[Price],[IsActive])	values (3, 'Speed Post', 'Use speed post service to deliver', '12 Days', 60.00, 1)
INSERT INTO [Order].[DeliveryMethod]	([DeliveryMethodId],[ShortName], [Description],[DeliveryTime],[Price],[IsActive])	values (4, 'Courier Service', 'Use Private courier service to deliver', '7 Days', 100.00, 1)
Set Identity_insert [Order].[DeliveryMethod] Off
End

--  [Core].[ProductType]

If Not Exists(select top 1 1 from [Core].[ProductType])
Begin 
Set Identity_insert [Core].[ProductType] On
INSERT INTO [Core].[ProductType]	([ProductTypeId], [Name], [Description],[IsActive])	values (1, 'Paperback', 'this type represent hard copy', 1)
INSERT INTO [Core].[ProductType]	([ProductTypeId], [Name], [Description],[IsActive])	values (2, 'Ebook', 'this is soft copy version', 1)
INSERT INTO [Core].[ProductType]	([ProductTypeId], [Name], [Description],[IsActive])	values (3, 'Subscribe', 'subscriable product', 1)
Set Identity_insert [Core].[ProductType] Off
End

--  [Core].[ProductTypeMapping]

If Not Exists(select top 1 1 from [Core].[ProductTypeMapping])
Begin 
Set Identity_insert [Core].[ProductTypeMapping] On
INSERT INTO [Core].[ProductTypeMapping]	([ProductTypeMappingId], [ProductId],[ProductTypeId], [Description],[Price], [IsActive])	values (1,1,1, 'This is hard copy product', 255.23, 1)
INSERT INTO [Core].[ProductTypeMapping]	([ProductTypeMappingId], [ProductId],[ProductTypeId], [Description],[Price], [IsActive])	values (2,1,2, 'This is soft copy of the product', 155.00, 1)
INSERT INTO [Core].[ProductTypeMapping]	([ProductTypeMappingId], [ProductId],[ProductTypeId], [Description],[Price], [IsActive])	values (3,1,3, 'Need to subscribe in order to get this product', 25.99, 1)
INSERT INTO [Core].[ProductTypeMapping]	([ProductTypeMappingId], [ProductId],[ProductTypeId], [Description],[Price], [IsActive])	values (4,2,2, 'This is soft copy of the product', 755.25, 1)
INSERT INTO [Core].[ProductTypeMapping]	([ProductTypeMappingId], [ProductId],[ProductTypeId], [Description],[Price], [IsActive])	values (5,2,3, 'Need to subscribe in order to get this product', 15.99, 1)
INSERT INTO [Core].[ProductTypeMapping]	([ProductTypeMappingId], [ProductId],[ProductTypeId], [Description],[Price], [IsActive])	values (6,3,1, 'This is hard copy product', 524.25, 1)
INSERT INTO [Core].[ProductTypeMapping]	([ProductTypeMappingId], [ProductId],[ProductTypeId], [Description],[Price], [IsActive])	values (7,3,2, 'This is soft copy of the product', 221.75, 1)
INSERT INTO [Core].[ProductTypeMapping]	([ProductTypeMappingId], [ProductId],[ProductTypeId], [Description],[Price], [IsActive])	values (8,4,1, 'This is hard copy product', 115.50, 1)
INSERT INTO [Core].[ProductTypeMapping]	([ProductTypeMappingId], [ProductId],[ProductTypeId], [Description],[Price], [IsActive])	values (9,4,2, 'This is soft copy of the product', 55.00, 1)
INSERT INTO [Core].[ProductTypeMapping]	([ProductTypeMappingId], [ProductId],[ProductTypeId], [Description],[Price], [IsActive])	values (10,4,3, 'Need to subscribe in order to get this product', 17.99, 1)
INSERT INTO [Core].[ProductTypeMapping]	([ProductTypeMappingId], [ProductId],[ProductTypeId], [Description],[Price], [IsActive])	values (11,5,1, 'This is hard copy product', 647.00, 1)
INSERT INTO [Core].[ProductTypeMapping]	([ProductTypeMappingId], [ProductId],[ProductTypeId], [Description],[Price], [IsActive])	values (12,6,2, 'This is soft copy of the product', 235.25, 1)
INSERT INTO [Core].[ProductTypeMapping]	([ProductTypeMappingId], [ProductId],[ProductTypeId], [Description],[Price], [IsActive])	values (13,7,3, 'Need to subscribe in order to get this product', 45.99, 1)
Set Identity_insert [Core].[ProductTypeMapping] Off
End


--  [Staging].[ProductStatus]

If Not Exists(select top 1 1 from [Staging].[ProductStatus])
Begin 
Set Identity_insert [Staging].[ProductStatus] On
INSERT INTO [Staging].[ProductStatus]	([ProductStatusId], [status], [Description],[IsActive])	values (1, 'Send For suggestion', 'this status represents items send for Suggestion', 1)
INSERT INTO [Staging].[ProductStatus]	([ProductStatusId], [status], [Description],[IsActive])	values (2, 'Send For Correction', 'this status represents items send for Correction', 1)
INSERT INTO [Staging].[ProductStatus]	([ProductStatusId], [status], [Description],[IsActive])	values (3, 'Send For approval', 'this status represents items send for approval', 1)
INSERT INTO [Staging].[ProductStatus]	([ProductStatusId], [status], [Description],[IsActive])	values (4, 'In Progress', 'In Progress', 1)
INSERT INTO [Staging].[ProductStatus]	([ProductStatusId], [status], [Description],[IsActive])	values (5, 'Approved', 'this status represents approved product and ready for sell', 1)
INSERT INTO [Staging].[ProductStatus]	([ProductStatusId], [status], [Description],[IsActive])	values (6, 'Rejected', 'this status represents Rejected product either send for correct or rremove it from seeling list', 1)
Set Identity_insert [Staging].[ProductStatus] Off
End