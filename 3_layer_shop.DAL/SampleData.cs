using _3_layer_shop.DAL.EF;
using _3_layer_shop.DAL.Entities;
using _3_layer_shop.DAL.Entities.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3_layer_shop.DAL
{
    public class SampleData
    {
        public static void InitData(SiteDbContext context)
        {
            if (!context.Products.Any())
            {
                #region products-adding
                Product product1 = new Product
                {
                    Name = "Телефон",
                    Page = new Page
                    {
                        Alias = "phone",
                        Title = "Телефон",
                        Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie.
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie."
                    },
                    MainImage = new Image { Path = "/images/product_1.jpg", Alt = "Телефон" },
                    Price = 555,
                    DiscountPrice = 123,
                    IntroText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie.",
                    Quantity = 12,
                    DateAdded = new DateTime(2015, 6, 17),
                    Images = new List<ImageToProduct> 
                    {
                        new ImageToProduct { Image = new Image { Path = "/images/product_2.jpg", Alt = "prod1" } },
                        new ImageToProduct { Image = new Image { Path = "/images/product_3.jpg", Alt = "prod1" } },
                        new ImageToProduct { Image = new Image { Path = "/images/product_4.jpg", Alt = "prod1" } },
                        new ImageToProduct { Image = new Image { Path = "/images/product_5.jpg", Alt = "prod1" } },
                        new ImageToProduct { Image = new Image { Path = "/images/product_6.jpg", Alt = "prod1" } }
                    }
                };
                Product product2 = new Product
                {
                    Name = "Колонки",
                    Page = new Page
                    {
                        Alias = "speakers",
                        Title = " Колонки",
                        Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie.
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie."
                    },
                    MainImage = new Image { Path = "/images/product_2.jpg", Alt = "Колонки" },
                    Price = 444,
                    DiscountPrice = 321,
                    IntroText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie.",
                    Quantity = 0,
                    DateAdded = new DateTime(2015, 3, 12),
                    Images = new List<ImageToProduct>
                    {
                        new ImageToProduct { Image = new Image { Path = "/images/product_1.jpg", Alt = "prod2" } },
                        new ImageToProduct { Image = new Image { Path = "/images/product_3.jpg", Alt = "prod2" } },
                        new ImageToProduct { Image = new Image { Path = "/images/product_4.jpg", Alt = "prod2" } },
                        new ImageToProduct { Image = new Image { Path = "/images/product_5.jpg", Alt = "prod2" } },
                        new ImageToProduct { Image = new Image { Path = "/images/product_6.jpg", Alt = "prod2" } }
                    }
                };
                Product product3 = new Product
                {
                    Name = "Usb шнур",
                    Page = new Page 
                    { 
                        Alias = "usb_cord",
                        Title = "Usb шнур",
                        Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie.
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie."
                    },
                    MainImage = new Image { Path = "/images/product_3.jpg", Alt = "Usb шнур" },
                    Price = 666,
                    DiscountPrice = 53,
                    IntroText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie.",
                    Quantity = 2,
                    DateAdded = new DateTime(2015, 8, 1),
                    Images = new List<ImageToProduct>
                    {
                        new ImageToProduct { Image = new Image { Path = "/images/product_2.jpg", Alt = "prod3" } },
                        new ImageToProduct { Image = new Image { Path = "/images/product_1.jpg", Alt = "prod3" } },
                        new ImageToProduct { Image = new Image { Path = "/images/product_4.jpg", Alt = "prod3" } },
                        new ImageToProduct { Image = new Image { Path = "/images/product_5.jpg", Alt = "prod3" } },
                        new ImageToProduct { Image = new Image { Path = "/images/product_6.jpg", Alt = "prod3" } }
                    }
                };
                Product product4 = new Product
                {
                    Name = "Ноутбук",
                    Page = new Page
                    {
                        Alias = "Notebook",
                        Title = " Ноутбук",
                        Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie.
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie."
                    },
                    MainImage = new Image { Path = "/images/product_4.jpg", Alt = "Ноутбук" },
                    Price = 777,
                    IntroText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie.",
                    Quantity = 42,
                    DateAdded = new DateTime(2016, 5, 30),
                    Images = new List<ImageToProduct>
                    {
                        new ImageToProduct { Image = new Image { Path = "/images/product_2.jpg", Alt = "prod4" } },
                        new ImageToProduct { Image = new Image { Path = "/images/product_3.jpg", Alt = "prod4" } },
                        new ImageToProduct { Image = new Image { Path = "/images/product_1.jpg", Alt = "prod4" } },
                        new ImageToProduct { Image = new Image { Path = "/images/product_5.jpg", Alt = "prod4" } },
                        new ImageToProduct { Image = new Image { Path = "/images/product_6.jpg", Alt = "prod4" } }
                    }
                };
                Product product5 = new Product
                {
                    Name = "Наушники",
                    Page = new Page
                    {
                        Alias = "headphones",
                        Title = "Наушники",
                        Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie.
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie."
                    },
                    MainImage = new Image { Path = "/images/product_5.jpg", Alt = "Наушники" },
                    Price = 888,
                    DiscountPrice = 23,
                    IntroText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie.",
                    Quantity = 0,
                    DateAdded = new DateTime(2016, 1, 8),
                    Images = new List<ImageToProduct>
                    {
                        new ImageToProduct { Image = new Image { Path = "/images/product_2.jpg", Alt = "prod5" } },
                        new ImageToProduct { Image = new Image { Path = "/images/product_3.jpg", Alt = "prod5" } },
                        new ImageToProduct { Image = new Image { Path = "/images/product_4.jpg", Alt = "prod5" } },
                        new ImageToProduct { Image = new Image { Path = "/images/product_7.jpg", Alt = "prod5" } },
                        new ImageToProduct { Image = new Image { Path = "/images/product_6.jpg", Alt = "prod5" } }
                    }
                };
                Product product6 = new Product
                {
                    Name = "Планшет",
                    Page = new Page
                    {
                        Alias = "tablet",
                        Title = "Планшет",
                        Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie.
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie."
                    },
                    MainImage = new Image { Path = "/images/product_6.jpg", Alt = "Планшет" },
                    Price = 999,
                    IntroText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie.",
                    Quantity = 4,
                    DateAdded = new DateTime(2017, 4, 21),
                    Images = new List<ImageToProduct>
                    {
                        new ImageToProduct { Image = new Image { Path = "/images/product_2.jpg", Alt = "prod6" } },
                        new ImageToProduct { Image = new Image { Path = "/images/product_3.jpg", Alt = "prod6" } },
                        new ImageToProduct { Image = new Image { Path = "/images/product_4.jpg", Alt = "prod6" } },
                        new ImageToProduct { Image = new Image { Path = "/images/product_5.jpg", Alt = "prod6" } },
                        new ImageToProduct { Image = new Image { Path = "/images/product_7.jpg", Alt = "prod6" } }
                    }
                };
                Product product7 = new Product
                {
                    Name = "Камера",
                    Page = new Page
                    {
                        Alias = "camera",
                        Title = "Камера",
                        Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie.
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie."
                    },
                    MainImage = new Image { Path = "/images/product_7.jpg", Alt = "Камера" },
                    Price = 222,
                    DiscountPrice = 32,
                    IntroText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie.",
                    Quantity = 0,
                    DateAdded = new DateTime(2015, 9, 22),
                    Images = new List<ImageToProduct>
                    {
                        new ImageToProduct { Image = new Image { Path = "/images/product_2.jpg", Alt = "prod7" } },
                        new ImageToProduct { Image = new Image { Path = "/images/product_3.jpg", Alt = "prod7" } },
                        new ImageToProduct { Image = new Image { Path = "/images/product_4.jpg", Alt = "prod7" } },
                        new ImageToProduct { Image = new Image { Path = "/images/product_5.jpg", Alt = "prod7" } },
                        new ImageToProduct { Image = new Image { Path = "/images/product_6.jpg", Alt = "prod7" } }
                    }
                };
                Product product8 = new Product
                {
                    Name = "Клавиатура",
                    Page = new Page
                    {
                        Alias = "keyboard",
                        Title = "Клавиатура",
                        Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie.
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie."
                    },
                    MainImage = new Image { Path = "/images/product_8.jpg", Alt = "Клавиатура" },
                    Price = 333,
                    DiscountPrice = 51,
                    IntroText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie.",
                    Quantity = 10,
                    DateAdded = new DateTime(2016, 11, 5),
                    Images = new List<ImageToProduct>
                    {
                        new ImageToProduct { Image = new Image { Path = "/images/product_2.jpg", Alt = "prod8" } },
                        new ImageToProduct { Image = new Image { Path = "/images/product_3.jpg", Alt = "prod8" } },
                        new ImageToProduct { Image = new Image { Path = "/images/product_4.jpg", Alt = "prod8" } },
                        new ImageToProduct { Image = new Image { Path = "/images/product_5.jpg", Alt = "prod8" } },
                        new ImageToProduct { Image = new Image { Path = "/images/product_6.jpg", Alt = "prod8" } }
                    }
                };
                Product product9 = new Product
                {
                    Name = "Смартфон",
                    Page = new Page
                    {
                        Alias = "smartphone",
                        Title = " Смартфон",
                        Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie.
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie."
                    },
                    MainImage = new Image { Path = "/images/product_1.jpg", Alt = "Смартфон" },
                    Price = 111,
                    IntroText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie.",
                    Quantity = 0,
                    DateAdded = new DateTime(2014, 9, 17),
                    Images = new List<ImageToProduct>
                    {
                        new ImageToProduct { Image = new Image { Path = "/images/product_2.jpg", Alt = "prod9" } },
                        new ImageToProduct { Image = new Image { Path = "/images/product_3.jpg", Alt = "prod9" } },
                        new ImageToProduct { Image = new Image { Path = "/images/product_4.jpg", Alt = "prod9" } },
                        new ImageToProduct { Image = new Image { Path = "/images/product_5.jpg", Alt = "prod9" } },
                        new ImageToProduct { Image = new Image { Path = "/images/product_6.jpg", Alt = "prod9" } }
                    }
                };
                Product product10 = new Product
                {
                    Name = "Музыкальные колонки",
                    Page = new Page
                    {
                        Alias = "loudspeakers",
                        Title = "Музыкальные колонки",
                        Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie.
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie."
                    },
                    MainImage = new Image { Path = "/images/product_2.jpg", Alt = "Музыкальные колонки" },
                    Price = 444,
                    DiscountPrice = 81,
                    IntroText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie.",
                    Quantity = 8,
                    DateAdded = new DateTime(2017, 2, 21),
                    Images = new List<ImageToProduct>
                    {
                        new ImageToProduct { Image = new Image { Path = "/images/product_1.jpg", Alt = "prod10" } },
                        new ImageToProduct { Image = new Image { Path = "/images/product_3.jpg", Alt = "prod10" } },
                        new ImageToProduct { Image = new Image { Path = "/images/product_4.jpg", Alt = "prod10" } },
                        new ImageToProduct { Image = new Image { Path = "/images/product_5.jpg", Alt = "prod10" } },
                        new ImageToProduct { Image = new Image { Path = "/images/product_6.jpg", Alt = "prod10" } }
                    }
                };

                List<ProductToProduct> productToProducts1 = new List<ProductToProduct>
                {
                    new ProductToProduct { ProductChild = product2 },
                    new ProductToProduct { ProductChild = product3 },
                    new ProductToProduct { ProductChild = product4 }
                };

                List<ProductToProduct> productToProducts2 = new List<ProductToProduct>
                {
                    new ProductToProduct { ProductChild = product3 },
                    new ProductToProduct { ProductChild = product4 }
                };

                List<ProductToProduct> productToProducts4 = new List<ProductToProduct>
                {
                    new ProductToProduct { ProductChild = product5 },
                    new ProductToProduct { ProductChild = product6 },
                    new ProductToProduct { ProductChild = product7 },
                    new ProductToProduct { ProductChild = product8 },
                    new ProductToProduct { ProductChild = product9 },
                    new ProductToProduct { ProductChild = product10 }
                };

                product1.ProductToProductsChilds = productToProducts1;
                product2.ProductToProductsChilds = productToProducts2;
                product4.ProductToProductsChilds = productToProducts4;

                context.Products.AddRange(product1, product2, product3, product4);
                #endregion

                #region product-categoies-adding
                ProductCategory category1 = new ProductCategory
                { 
                    Name = "Телефоны",
                    Page = new Page
                    {
                        Alias = "phones",
                        Title = " Телефоны",
                        Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie.
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie."
                    }
                };
                ProductCategory category2 = new ProductCategory
                {
                    Name = "Акустические системы",
                    Page = new Page
                    {
                        Alias = "acoustic",
                        Title = "Акустические системы",
                        Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie.
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie."
                    }
                };
                ProductCategory category3 = new ProductCategory
                {
                    Name = "Компьютеры",
                    Page = new Page
                    {
                        Alias = "computers",
                        Title = "Компьютеры",
                        Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie.
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie."
                    }
                };
                ProductCategory category4 = new ProductCategory
                {
                    Name = "Расходные материалы",
                    Page = new Page
                    {
                        Alias = "consumables",
                        Title = "Расходные материалы",
                        Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie.
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie."
                    }
                };
                ProductCategory category5 = new ProductCategory
                {
                    Name = "Бытовая техника",
                    Page = new Page
                    {
                        Alias = "appliances",
                        Title = "Бытовая техника",
                        Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie.
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie."
                    }
                };

                List<ProductToCategory> productToCategories1 = new List<ProductToCategory>
                {
                    new ProductToCategory { Product = product1},
                    new ProductToCategory { Product = product3},
                    new ProductToCategory { Product = product7},
                    new ProductToCategory { Product = product10}
                };

                List<ProductToCategory> productToCategories2 = new List<ProductToCategory>
                {
                    new ProductToCategory { Product = product2},
                    new ProductToCategory { Product = product3},
                    new ProductToCategory { Product = product4},
                    new ProductToCategory { Product = product5}
                };

                List<ProductToCategory> productToCategories3 = new List<ProductToCategory>
                {
                    new ProductToCategory { Product = product6},
                    new ProductToCategory { Product = product8},
                    new ProductToCategory { Product = product9}
                };

                List<ProductToCategory> productToCategories4 = new List<ProductToCategory>
                {
                    new ProductToCategory { Product = product2},
                    new ProductToCategory { Product = product3},
                    new ProductToCategory { Product = product6},
                    new ProductToCategory { Product = product9}
                };

                List<ProductToCategory> productToCategories5 = new List<ProductToCategory>
                {
                    new ProductToCategory { Product = product1},
                    new ProductToCategory { Product = product2},
                    new ProductToCategory { Product = product3},
                    new ProductToCategory { Product = product4},
                    new ProductToCategory { Product = product6},
                    new ProductToCategory { Product = product7},
                    new ProductToCategory { Product = product8},
                    new ProductToCategory { Product = product10}
                };

                category1.ProductToCategories = productToCategories1;
                category2.ProductToCategories = productToCategories2;
                category3.ProductToCategories = productToCategories3;
                category4.ProductToCategories = productToCategories4;
                category5.ProductToCategories = productToCategories5;

                context.ProductCategories.AddRange(category1, category2, category3, category4, category5);
                #endregion

                #region informations-adding
                Information information1 = new Information
                {
                    Content = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie. 
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie.",
                    Name = "О нас",
                    Page = new Page
                    {
                        Alias = "about-us",
                        Title = " О нас",
                        Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie."
                    }
                };
                Information information2 = new Information
                {
                    Content = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie. 
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie.",
                    Name = "Доставка и оплата",
                    Page = new Page
                    {
                        Alias = "delivery",
                        Title = " Доставка и оплата",
                        Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie."
                    }
                };

                context.Informations.AddRange(information1, information2);
                #endregion

                #region banners-adding
                Banner banner1 = new Banner { Image = new Image { Path = "/images/home_slider_1.jpg", Alt = "home_slider_1" },
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie.", Link = "/phones", Title = "Телефоны" };
                Banner banner2 = new Banner { Image = new Image { Path = "/images/home_slider_1.jpg", Alt = "home_slider_2" },
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie.", Link = "/computers", Title = "Компьютеры" };
                Banner banner3 = new Banner { Image = new Image { Path = "/images/home_slider_1.jpg", Alt = "home_slider_3" },
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie.", Link = "/appliances", Title = "Бытовая техника" };
                Banner banner4 = new Banner { Image = new Image { Path = "/images/avds_xl.jpg", Alt = "avds_xl" },
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie.", Link = "https://google.ru", Title = "Наушники" };
                Banner banner5 = new Banner { Image = new Image { Path = "/images/categories.jpg", Alt = "categories" },
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam a ultricies metus. Sed nec molestie.", Link = "/article/delivery", Title = "Доставка" };

                BannerGroup bannerGroup1 = new BannerGroup { Banners = new List<Banner> { banner1, banner2, banner3 }, Name = "HomePageSlider" };

                context.BannerGroups.Add(bannerGroup1);
                context.Banners.AddRange(banner4, banner5);

                #endregion

                #region settings-adding
                context.SaveChanges();
                Setting homeSliderSet = new Setting { Key = "HomeSliderId", Value = context.BannerGroups.FirstOrDefault(bg => bg == bannerGroup1).Id.ToString() };
                Setting singleBanner1Set = new Setting { Key = "BigBannerId", Value = context.Banners.FirstOrDefault(b => b == banner4).Id.ToString() };
                Setting singleBanner2Set = new Setting { Key = "SmallBannerId", Value = context.Banners.FirstOrDefault(b => b == banner5).Id.ToString() };

                context.Settings.AddRange(homeSliderSet, singleBanner1Set, singleBanner2Set);
                #endregion

                #region statuses
                Status status1 = new Status { Name = "Новый", Code = 1 };
                Status status2 = new Status { Name = "В обработке", Code = 2 };
                Status status3 = new Status { Name = "Завершен", Code = 3 };
                context.Statuses.AddRange(status1, status2, status3);
                #endregion

                context.SaveChanges();
            }
        }

        public static void InitIdentityData(UserManager<IdentityUser> userManager)
        {
            userManager.CreateAsync(new IdentityUser("Admin"), "wqssd03dn-fFdx").Wait();
        }
    }
}
