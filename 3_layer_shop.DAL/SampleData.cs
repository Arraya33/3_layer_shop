using _3_layer_shop.DAL.EF;
using _3_layer_shop.DAL.Entities;
using _3_layer_shop.DAL.Entities.Abstract;
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
                    Name = "p1",
                    Page = new Page
                    {
                        Alias = "alias_p1",
                        Title = " prod 1",
                        Description = @"product page text product page text product page text
                            product page text product page text product page text product page text"
                    },
                    MainImage = new Image { Path = "/images/product_1.jpg", Alt = "prod1" },
                    Price = 555,
                    DiscountPrice = 123,
                    IntroText = "product description product description product description product description product description",
                    Quantity = 12,
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
                    Name = "p2",
                    Page = new Page
                    {
                        Alias = "alias_p2",
                        Title = " prod 2",
                        Description = @"product page text product page text product page text
                            product page text product page text product page text product page text"
                    },
                    MainImage = new Image { Path = "/images/product_2.jpg", Alt = "prod2" },
                    Price = 444,
                    DiscountPrice = 321,
                    IntroText = "product description product description product description product description product description",
                    Quantity = 0,
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
                    Name = "p3",
                    Page = new Page 
                    { 
                        Alias = "alias_p3",
                        Title = " prod 3",
                        Description = @"product page text product page text product page text
                            product page text product page text product page text product page text"
                    },
                    MainImage = new Image { Path = "/images/product_3.jpg", Alt = "prod3" },
                    Price = 666,
                    DiscountPrice = 53,
                    IntroText = "product description product description product description product description product description",
                    Quantity = 2,
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
                    Name = "p4",
                    Page = new Page
                    {
                        Alias = "alias_p4",
                        Title = " prod 4",
                        Description = @"product page text product page text product page text
                            product page text product page text product page text product page text"
                    },
                    MainImage = new Image { Path = "/images/product_4.jpg", Alt = "prod4" },
                    Price = 777,
                    IntroText = "product description product description product description product description product description",
                    Quantity = 42,
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
                    Name = "p5",
                    Page = new Page
                    {
                        Alias = "alias_p5",
                        Title = " prod 5",
                        Description = @"product page text product page text product page text
                            product page text product page text product page text product page text"
                    },
                    MainImage = new Image { Path = "/images/product_5.jpg", Alt = "prod5" },
                    Price = 888,
                    DiscountPrice = 23,
                    IntroText = "product description product description product description product description product description",
                    Quantity = 0,
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
                    Name = "p6",
                    Page = new Page
                    {
                        Alias = "alias_p6",
                        Title = " prod 6",
                        Description = @"product page text product page text product page text
                            product page text product page text product page text product page text"
                    },
                    MainImage = new Image { Path = "/images/product_6.jpg", Alt = "prod6" },
                    Price = 999,
                    IntroText = "product description product description product description product description product description",
                    Quantity = 4,
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
                    Name = "p7",
                    Page = new Page
                    {
                        Alias = "alias_p7",
                        Title = " prod 7",
                        Description = @"product page text product page text product page text
                            product page text product page text product page text product page text"
                    },
                    MainImage = new Image { Path = "/images/product_7.jpg", Alt = "prod7" },
                    Price = 222,
                    DiscountPrice = 32,
                    IntroText = "product description product description product description product description product description",
                    Quantity = 0,
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
                    Name = "p8",
                    Page = new Page
                    {
                        Alias = "alias_p8",
                        Title = " prod 8",
                        Description = @"product page text product page text product page text
                            product page text product page text product page text product page text"
                    },
                    MainImage = new Image { Path = "/images/product_8.jpg", Alt = "prod8" },
                    Price = 333,
                    DiscountPrice = 51,
                    IntroText = "product description product description product description product description product description",
                    Quantity = 10,
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
                    Name = "p9",
                    Page = new Page
                    {
                        Alias = "alias_p9",
                        Title = " prod 9",
                        Description = @"product page text product page text product page text
                            product page text product page text product page text product page text"
                    },
                    MainImage = new Image { Path = "/images/product_1.jpg", Alt = "prod9" },
                    Price = 111,
                    IntroText = "product description product description product description product description product description",
                    Quantity = 0,
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
                    Name = "p10",
                    Page = new Page
                    {
                        Alias = "alias_p10",
                        Title = " prod 10",
                        Description = @"product page text product page text product page text
                            product page text product page text product page text product page text"
                    },
                    MainImage = new Image { Path = "/images/product_2.jpg", Alt = "prod10" },
                    Price = 444,
                    DiscountPrice = 81,
                    IntroText = "product description product description product description product description product description",
                    Quantity = 8,
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
                    Name = "cat1",
                    Page = new Page
                    {
                        Alias = "alias_cat1",
                        Title = " cat 1",
                        Description = @"category page text category page text category page text
                            category page text category page text category page text category page text"
                    }
                };
                ProductCategory category2 = new ProductCategory
                {
                    Name = "cat2",
                    Page = new Page
                    {
                        Alias = "alias_cat2",
                        Title = " cat 2",
                        Description = @"category page text category page text category page text
                            category page text category page text category page text category page text"
                    }
                };
                ProductCategory category3 = new ProductCategory
                {
                    Name = "cat3",
                    Page = new Page
                    {
                        Alias = "alias_cat3",
                        Title = " cat 3",
                        Description = @"category page text category page text category page text
                            category page text category page text category page text category page text"
                    }
                };
                ProductCategory category4 = new ProductCategory
                {
                    Name = "cat4",
                    Page = new Page
                    {
                        Alias = "alias_cat4",
                        Title = " cat 4",
                        Description = @"category page text category page text category page text
                            category page text category page text category page text category page text"
                    }
                };
                ProductCategory category5 = new ProductCategory
                {
                    Name = "cat5",
                    Page = new Page
                    {
                        Alias = "alias_cat5",
                        Title = " cat 5",
                        Description = @"category page text category page text category page text
                            category page text category page text category page text category page text"
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

                category1.ProductToCategories = productToCategories1;
                category2.ProductToCategories = productToCategories2;
                category3.ProductToCategories = productToCategories3;

                context.ProductCategories.AddRange(category1, category2, category3, category4, category5);
                #endregion

                #region informations-adding
                Information information1 = new Information
                {
                    Content = @"info text 1 info text 1 info text 1 info text 1 info text 1 info text 1 info text 1
                        info text 1 info text 1 info text 1 info text 1 info text 1 info text 1 info text 1 info text 1
                        info text 1 info text 1 info text 1 info text 1 info text 1 info text 1 info text 1 info text 1
                        info text 1 info text 1 info text 1 info text 1 ",
                    Name = "info 1",
                    Page = new Page
                    {
                        Alias = "alias-info1",
                        Title = " info 1",
                        Description = @"info page text info page text info page text
                            info page text info page text info page text info page text"
                    }
                };
                Information information2 = new Information
                {
                    Content = @"info text 2 info text 2 info text 2 info text 2 info text 1 info text 1 info text 1
                        info text 1 info text 1 info text 1 info text 1 info text 1 info text 1 info text 1 info text 1
                        info text 1 info text 1 info text 1 info text 1 info text 1 info text 1 info text 1 info text 1
                        info text 1 info text 1 info text 1 info text 1 ",
                    Name = "info 2",
                    Page = new Page
                    {
                        Alias = "alias-info2",
                        Title = " info 2",
                        Description = @"info page text info page text info page text
                            info page text info page text info page text info page text"
                    }
                };
                Information information3 = new Information
                {
                    Content = @"info text 3 info text 3 info text 3 info text 3 info text 1 info text 1 info text 1
                        info text 1 info text 1 info text 1 info text 1 info text 1 info text 1 info text 1 info text 1
                        info text 1 info text 1 info text 1 info text 1 info text 1 info text 1 info text 1 info text 1
                        info text 1 info text 1 info text 1 info text 1 ",
                    Name = "info 3",
                    Page = new Page
                    {
                        Alias = "alias-info3",
                        Title = " info 3",
                        Description = @"info page text info page text info page text
                            info page text info page text info page text info page text"
                    }
                };
                Information information4 = new Information
                {
                    Content = @"info text 4 info text 4 info text 4 info text 4 info text 4 info text 1 info text 1
                        info text 1 info text 1 info text 1 info text 1 info text 1 info text 1 info text 1 info text 1
                        info text 1 info text 1 info text 1 info text 1 info text 1 info text 1 info text 1 info text 1
                        info text 1 info text 1 info text 1 info text 1 ",
                    Name = "info 4",
                    Page = new Page
                    {
                        Alias = "alias-info4",
                        Title = " info 4",
                        Description = @"info page text info page text info page text
                            info page text info page text info page text info page text"
                    }
                };

                context.Informations.AddRange(information1, information2, information3, information4);
                #endregion

                #region banners-adding
                Banner banner1 = new Banner { Image = new Image { Path = "/images/home_slider_1.jpg", Alt = "home_slider_1" },
                    Description = "banner description 1", Link = "https://www.google.ru", Title = "banner 1" };
                Banner banner2 = new Banner { Image = new Image { Path = "/images/home_slider_1.jpg", Alt = "home_slider_2" },
                    Description = "banner description 2", Link = "https://www.google.ru", Title = "banner 2" };
                Banner banner3 = new Banner { Image = new Image { Path = "/images/home_slider_1.jpg", Alt = "home_slider_3" },
                    Description = "banner description 3", Link = "https://www.google.ru", Title = "banner 3" };
                Banner banner4 = new Banner { Image = new Image { Path = "/images/avds_xl.jpg", Alt = "avds_xl" },
                    Description = "banner description 4", Link = "https://www.google.ru", Title = "banner 4" };
                Banner banner5 = new Banner { Image = new Image { Path = "/images/categories.jpg", Alt = "categories" },
                    Description = "banner description 5", Link = "https://www.google.ru", Title = "banner 5" };

                BannerGroup bannerGroup1 = new BannerGroup { Banners = new List<Banner> { banner1, banner2, banner3 }, Name = "HomePageSlider" };

                context.BannerGroups.Add(bannerGroup1);
                context.Banners.AddRange(banner4, banner5);

                #endregion

                #region settings-adding
                context.SaveChanges();
                Setting homeSliderSet = new Setting { Key = "HomeSliderId", Value = context.BannerGroups.FirstOrDefault(bg => bg == bannerGroup1).Id.ToString() };
                Setting singleBanner1Set = new Setting { Key = "singleBanner1Id", Value = context.Banners.FirstOrDefault(b => b == banner4).Id.ToString() };
                Setting singleBanner2Set = new Setting { Key = "singleBanner2Id", Value = context.Banners.FirstOrDefault(b => b == banner5).Id.ToString() };

                context.Settings.AddRange(homeSliderSet, singleBanner1Set, singleBanner2Set);
                #endregion

                context.SaveChanges();
            }
        }
    }
}
