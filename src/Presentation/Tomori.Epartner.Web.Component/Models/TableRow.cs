namespace Tomori.Epartner.Web.Component.Models
{
    public class TableRowWrapper<T>
    {
        public int No { get; set; }
        public T Data { get; set; }

        public TableRowWrapper()
        {

        }

        public TableRowWrapper(int no, T data)
        {
            No = no;
            Data = data;
        }
    }
    public class ParameterModel
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
