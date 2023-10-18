namespace Tomori.Epartner.Web.Component.Models
{
    public class FilterSelect
    {
        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;

        public FilterSelect(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
