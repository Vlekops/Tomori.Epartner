namespace Tomori.Epartner.Web.Component.Pages.Home
{
    public partial class Dashboard : ComponentBase
    {
        #region Override
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                DataChart();
            }

            await base.OnAfterRenderAsync(firstRender);
        }
        #endregion

        #region Inject, Cascading, Parameter

        [Parameter]
        public TokenModel Token { get; set; }

        private double[] _DataDounatChart = { 25, 77};
        private string[] _LabelsDounatChart = { "Oil", "Coal"};
        private ChartOptions _ChartOption = new ChartOptions();
        private List<ChartSeries> _DataChart = new List<ChartSeries>();
        private string[] XAxisLabels = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep" };

        #endregion

        #region Method

        private void DataChart()
        {
            _DataChart = new List<ChartSeries>()
            {
                new ChartSeries() { Name = "Series 1", Data = new double[] { 90, 79, 72, 69, 62, 62, 55, 65, 70 } },
                new ChartSeries() { Name = "Series 2", Data = new double[] { 35, 41, 35, 51, 49, 62, 69, 91, 148 } },
            };
            _ChartOption.InterpolationOption = InterpolationOption.NaturalSpline;
            _ChartOption.YAxisFormat = "c2";
            StateHasChanged();
        }

        #endregion
    }
}
