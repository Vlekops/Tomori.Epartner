namespace Tomori.Epartner.Core.Attributes
{
    public class CompareDataWrapper
    {
        public string Id { get; set; }
        public string Section { get; set; }
        public List<CompareData> Items { get; set; }
    }

    public class CompareData
    {
        public string Field { get; set; }
        public string Type { get; set; }
        public string BeforeValue { get; set; }
        public string BeforeValueText { get; set; }
        public string AfterValue { get; set; }
        public string AfterValueText { get; set; }
    }
}
