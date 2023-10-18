namespace Tomori.Epartner.Web.Component.Models
{
    public class BreadcrumbModel
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public bool Disabled { get; set; }

        public BreadcrumbModel()
        {

        }

        public BreadcrumbModel(string title, string url, bool disabled = false)
        {
            Title = title;
            Url = url;
            Disabled = disabled;
        }
    }
}
