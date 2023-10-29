namespace Tomori.Epartner.Web.Component.Models
{
    public class FormWizardWrapperModel
    {
        public int CurrentStep { get; set; }
        public List<FormWizardItemModel> Items { get; set; } = new List<FormWizardItemModel>();
    }

    public class FormWizardItemModel
    {
        public string Title { get; set; }
        public int Step { get; set; }
        public string ComponentType { get; set; }
        public Dictionary<string, object> Param { get; set; }

        public FormWizardItemModel()
        {

        }

        public FormWizardItemModel(string title, int step, string componentType, Dictionary<string, object> param)
        {
            Title = title;
            Step = step;
            ComponentType = componentType;
            Param = param;
        }
    }
}
