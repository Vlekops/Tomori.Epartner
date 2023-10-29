namespace Tomori.Epartner.Web.App.Models
{
    public class MenuWrapperModel
    {
        public string Section { get; set; }
        public int Sort { get; set; }
        public List<MenuItemModel> Menus { get; set; } = new List<MenuItemModel>();
    }

    public class MenuItemModel
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Navigation { get; set; }
        public string Icon { get; set; }
        public int Sort { get; set; }
        public List<MenuItemModel> Items { get; set; } = new List<MenuItemModel>();
    }
}
