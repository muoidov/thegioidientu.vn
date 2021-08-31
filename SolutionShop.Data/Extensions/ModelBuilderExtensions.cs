﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SolutionShop.Data.Entities;
using SolutionShop.Data.Enums;
using System;

namespace SolutionShop.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
            new AppConfig() { Key = "HomeTitle", Value = "This is home page of eShopSolution" },
            new AppConfig() { Key = "HomeKeyword", Value = "This is keyword of eShopSolution" },
            new AppConfig() { Key = "HomeDescription", Value = "This is description of eShopSolution" }
            );
            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = "vi-VN", Name = "Tiếng Việt", IsDefault = true },
                new Language() { Id = "en-US", Name = "English", IsDefault = false });

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    IsShowHome = true,
                    ParenId = null,
                    SortOrder = 1,
                    Status = 1,
                },
                 new Category()
                 {
                     Id = 2,
                     IsShowHome = true,
                     ParenId = null,
                     SortOrder = 2,
                     Status = 1
                 });

            modelBuilder.Entity<CategoryTranslation>().HasData(
                  new CategoryTranslation() { Id = 1, CategoryId = 1, Name = "Áo nam", LanguageId = "vi-VN", SeoAlias = "ao-nam", SeoDescription = "Sản phẩm áo thời trang nam", SeoTitle = "Sản phẩm áo thời trang nam" },
                  new CategoryTranslation() { Id = 2, CategoryId = 1, Name = "Men Shirt", LanguageId = "en-US", SeoAlias = "men-shirt", SeoDescription = "The shirt products for men", SeoTitle = "The shirt products for men" },
                  new CategoryTranslation() { Id = 3, CategoryId = 2, Name = "Áo nữ", LanguageId = "vi-VN", SeoAlias = "ao-nu", SeoDescription = "Sản phẩm áo thời trang nữ", SeoTitle = "Sản phẩm áo thời trang women" },
                  new CategoryTranslation() { Id = 4, CategoryId = 2, Name = "Women Shirt", LanguageId = "en-US", SeoAlias = "women-shirt", SeoDescription = "The shirt products for women", SeoTitle = "The shirt products for women" }
                    );

            modelBuilder.Entity<Product>().HasData(
           new Product()
           {
               Id = 1,
               DateCreated = DateTime.Now,
               OriginalPrice = 100000,
               Price = 200000,
               Stock = 0,
               ViewCount = 0,
           });
            modelBuilder.Entity<ProductTranslation>().HasData(
                 new ProductTranslation()
                 {
                     Id = 1,
                     ProductId = 1,
                     Name = "Áo sơ mi nam trắng Việt Tiến",
                     LanguageId = "vi-VN",
                     SeoAlias = "ao-so-mi-nam-trang-viet-tien",
                     SeoDescription = "Áo sơ mi nam trắng Việt Tiến",
                     SeoTitle = "Áo sơ mi nam trắng Việt Tiến",
                     Details = "Áo sơ mi nam trắng Việt Tiến",
                     Description = "Áo sơ mi nam trắng Việt Tiến"
                 },
                    new ProductTranslation()
                    {
                        Id = 2,
                        ProductId = 1,
                        Name = "Viet Tien Men T-Shirt",
                        LanguageId = "en-US",
                        SeoAlias = "viet-tien-men-t-shirt",
                        SeoDescription = "Viet Tien Men T-Shirt",
                        SeoTitle = "Viet Tien Men T-Shirt",
                        Details = "Viet Tien Men T-Shirt",
                        Description = "Viet Tien Men T-Shirt"
                    });
            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory() { ProductId = 1, CategoryId = 1 }
                );
            //seeding cho identity
            var roleId = new Guid("1D529FB1-5CC0-4C3B-9515-38DA1DBE5FFF");
            var adminId = new Guid("5B317695-2B4C-4F23-8016-0791EB37578B");
            modelBuilder.Entity<AppRole>().HasData(
                new AppRole
                {
                    Id = roleId,
                    Name = "admin",
                    NormalizedName = "admin",
                    Description = "Administrator role"
                });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = new Guid("A694485E-A98D-42F6-84D9-C0B4C7A2F27D"),
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "domuoi70@gmail.com",
                NormalizedEmail = "domuoi70@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Dovanmuoi1@"),
                SecurityStamp = string.Empty,
                FirstName = "Muoi",
                LastName = "Do",
                Dob = new DateTime(2020, 11, 29)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });
            modelBuilder.Entity<Slide>().HasData(
               new Slide() { Id = 1, Name = "Second Thumbnail label", Description = "Cras justo odio", SortOrder = 1, Url = "#", Image = "/themes/images/carousel/1.png", Status = Status.Active },
               new Slide() { Id = 2, Name = "Second Thumbnail label", Description = "Cras justo odio", SortOrder = 2, Url = "#", Image = "/themes/images/carousel/2.png", Status = Status.Active },
               new Slide() { Id = 3, Name = "Second Thumbnail label", Description = "Cras justo odio,", SortOrder = 3, Url = "#", Image = "/themes/images/carousel/3.png", Status = Status.Active },
               new Slide() { Id = 4, Name = "Second Thumbnail label", Description = "Cras justo odio,", SortOrder = 4, Url = "#", Image = "/themes/images/carousel/4.png", Status = Status.Active },
               new Slide() { Id = 5, Name = "Second Thumbnail label", Description = "Cras justo odio,", SortOrder = 5, Url = "#", Image = "/themes/images/carousel/5.png", Status = Status.Active },
               new Slide() { Id = 6, Name = "Second Thumbnail label", Description = "Cras justo odio, ", SortOrder = 6, Url = "#", Image = "/themes/images/carousel/6.png", Status = Status.Active }
               );

            //modelBuilder.Entity<Slide>().HasData(
            //  new Slide() { Id = 1, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 1, Url = "#", Image = "/themes/images/carousel/1.png", Status = Status.Active },
            //  new Slide() { Id = 2, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 2, Url = "#", Image = "/themes/images/carousel/2.png", Status = Status.Active },
            //  new Slide() { Id = 3, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 3, Url = "#", Image = "/themes/images/carousel/3.png", Status = Status.Active },
            //  new Slide() { Id = 4, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 4, Url = "#", Image = "/themes/images/carousel/4.png", Status = Status.Active },
            //  new Slide() { Id = 5, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 5, Url = "#", Image = "/themes/images/carousel/5.png", Status = Status.Active },
            //  new Slide() { Id = 6, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 6, Url = "#", Image = "/themes/images/carousel/6.png", Status = Status.Active }
            //  );
        }
    }
}