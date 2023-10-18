namespace Tomori.Epartner.Web.Component.Models
{
    public class CompareDataWrapper
    {
        public string Id { get; set; }
        public string Section { get; set; }
        public List<CompareData> Items { get; set; }

        public CompareDataWrapper()
        {

        }

        public CompareDataWrapper(string id, string section, List<CompareData> items)
        {
            Id = id;
            Section = section;
            Items = items;
        }
    }

    public class CompareData
    {
        public string Field { get; set; }
        public string Type { get; set; }
        public string BeforeValue { get; set; }
        public string BeforeValueText { get; set; }
        public string AfterValue { get; set; }
        public string AfterValueText { get; set; }

        public CompareData()
        {

        }

        public CompareData(string field, string type, string beforeValue, string afterValue)
        {
            Field = field;
            Type = type;
            BeforeValue = beforeValue;
            AfterValue = afterValue;
        }

        public CompareData(string field, string type, string beforeValue, string beforeValueText, string afterValue, string afterValueText)
        {
            Field = field;
            Type = type;
            BeforeValue = beforeValue;
            BeforeValueText = beforeValueText;
            AfterValue = afterValue;
            AfterValueText = afterValueText;
        }
    }
}
