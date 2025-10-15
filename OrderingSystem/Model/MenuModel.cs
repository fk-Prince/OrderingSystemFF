using System;
using System.Collections.Generic;
using System.Drawing;

namespace OrderingSystem.Model
{
    public class MenuModel
    {
        public List<IngredientModel> MenuIngredients { get; protected set; }
        public List<MenuModel> MenuVariant { get; protected set; }
        public int MenuId { get; protected set; }
        public string MenuName { get; protected set; }
        public string FlavorName { get; protected set; }
        public string SizeName { get; protected set; }
        public string CategoryName { get; protected set; }
        public string MenuDescription { get; protected set; }
        public TimeSpan EstimatedTime { get; protected set; }
        public Image MenuImage { get; protected set; }
        public byte[] MenuImageByte { get; protected set; }
        public int MenuDetailId { get; protected set; }
        public int PurchaseQty { get; set; }
        public int CategoryId { get; protected set; }
        public double MenuPrice { get; protected set; }
        public int MaxOrder { get; protected set; }
        public double DiscountMenuRate { get; protected set; }
        public int Discountid { get; protected set; }
        public DiscountModel Discount { get; protected set; }
        public CategoryModel Category { get; protected set; }

        public override bool Equals(object obj)
        {
            if (obj is MenuModel menu)
            {
                return FlavorName == menu.FlavorName &&
                       SizeName == menu.SizeName &&
                       EstimatedTime == menu.EstimatedTime &&
                       MenuPrice == menu.MenuPrice;
            }
            return false;
        }
        public interface IMenuBuilder
        {
            MenuBuilder WithIngredients(List<IngredientModel> ing);
            MenuBuilder WithVariant(List<MenuModel> m);
            MenuBuilder WithEstimatedTime(TimeSpan ts);
            MenuBuilder WithCategory(CategoryModel cat);
            MenuBuilder WithCategoryId(int cat);
            MenuBuilder WithMenuImage(Image image);
            MenuBuilder WithMenuImageByte(byte[] image);
            MenuBuilder WithDiscountMenuRate(double rate);
            MenuBuilder WithMenuId(int menuId);
            MenuBuilder WithMaxOrder(int menuId);
            MenuBuilder WithMenuName(string menuName);
            MenuBuilder WithCategoryName(string n);
            MenuBuilder WithFlavorName(string menuName);
            MenuBuilder WithSizeName(string menuName);
            MenuBuilder WithDiscountId(int menuId);
            MenuBuilder WithMenuDescription(string menuDescription);
            MenuBuilder WithMenuDetailId(int lowestMenuDetailId);
            MenuBuilder WithPrice(double lowestMenuPrice);
            MenuModel Build();
        }

        public static MenuBuilder Builder() => new MenuBuilder();

        public double GetDiscountedPrice()
        {
            return MenuPrice - (MenuPrice * DiscountMenuRate);
        }

        public class MenuBuilder : IMenuBuilder
        {
            private readonly MenuModel _menuModel = new MenuModel();
            public MenuBuilder WithMenuId(int menuId)
            {
                _menuModel.MenuId = menuId;
                return this;
            }
            public MenuBuilder WithMenuName(string menuName)
            {
                _menuModel.MenuName = menuName;
                return this;
            }
            public MenuBuilder WithMenuDescription(string menuDescription)
            {
                _menuModel.MenuDescription = menuDescription;
                return this;
            }
            public MenuBuilder WithMenuDetailId(int lowestMenuDetailId)
            {
                _menuModel.MenuDetailId = lowestMenuDetailId;
                return this;
            }
            public MenuBuilder WithPrice(double lowestMenuPrice)
            {
                _menuModel.MenuPrice = lowestMenuPrice;
                return this;
            }
            public MenuModel Build()
            {
                return _menuModel;
            }
            public MenuBuilder WithCategory(CategoryModel category)
            {
                _menuModel.Category = category;
                return this;
            }

            public MenuBuilder WithCategoryId(int cat)
            {
                _menuModel.CategoryId = cat;
                return this;
            }

            public MenuBuilder WithDiscountMenuRate(double rate)
            {
                _menuModel.DiscountMenuRate = rate;
                return this;
            }

            public MenuBuilder WithMenuImage(Image image)
            {
                _menuModel.MenuImage = image;
                return this;
            }

            public MenuBuilder WithMaxOrder(int max)
            {
                _menuModel.MaxOrder = max;
                return this;
            }

            public MenuBuilder WithFlavorName(string menuName)
            {
                _menuModel.FlavorName = menuName;
                return this;
            }

            public MenuBuilder WithSizeName(string menuName)
            {
                _menuModel.SizeName = menuName;
                return this;
            }

            public MenuBuilder WithEstimatedTime(TimeSpan ts)
            {
                _menuModel.EstimatedTime = ts;
                return this;
            }

            public MenuBuilder WithDiscountId(int id)
            {
                _menuModel.Discountid = id;
                return this;
            }

            public MenuBuilder WithIngredients(List<IngredientModel> ing)
            {
                _menuModel.MenuIngredients = ing;
                return this;
            }

            public MenuBuilder WithCategoryName(string n)
            {
                _menuModel.CategoryName = n;
                return this;
            }

            public MenuBuilder WithMenuImageByte(byte[] image)
            {
                _menuModel.MenuImageByte = image;
                return this;
            }

            public MenuBuilder WithVariant(List<MenuModel> m)
            {
                _menuModel.MenuVariant = m;
                return this;
            }
        }
    }
}
