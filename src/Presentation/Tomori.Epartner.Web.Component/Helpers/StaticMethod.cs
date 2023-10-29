namespace Tomori.Epartner.Web.Component.Helpers
{
    public static class StaticMethod
    {
        public static int GetTotalPage(int dataCount, int pageSize)
        {
            return (int)(dataCount % pageSize == 0 ? Math.Floor((double)dataCount / pageSize) : Math.Floor((double)dataCount / pageSize) + 1);
        }

        public static int GetStartRowNumber(int page, int pageSize)
        {
            return ((page - 1) * pageSize) + 1;
        }

        public static string GetExtension(string filename)
        {
            var arr = filename.Split('.');
            return $".{arr.LastOrDefault()}";
        }

        public static int[] GetPageSize(List<int> items = null, bool replace = false)
        {
            items ??= new List<int>();

            var list = new List<int> { 10, 20, 50, 100 };
            if (items.Any())
            {
                if (replace)
                    list = items;
                else
                    list.AddRange(items);
            }
            return list.OrderBy(_ => _).ToArray();
        }

        public static MarkupString SetCreatedUpdatedInfo(DateTime? datetime, string inputer)
        {
            string result = "-";

            if (datetime.HasValue)
            {
                inputer = inputer.Split("|").LastOrDefault();
                result = $@"<div>{datetime.Value:yyyy-MM-dd HH:mm:ss}</div><div>{inputer}</div>";
            }

            return new MarkupString(result);
        }

        public static bool CheckPermission(string parameter, List<string> permissions)
        {
            if (permissions != null && permissions.Any(d => d.Trim().ToLower() == parameter.Trim().ToLower()))
                return true;
            return false;
        }

        public static bool CheckPermission(PermissionEnum parameter, List<string> permissions)
        {
            string _param = string.Empty;
            switch (parameter)
            {
                case PermissionEnum.ADD: _param = ".add"; break;
                case PermissionEnum.EDIT: _param = ".edit"; break;
                case PermissionEnum.DELETE: _param = ".delete"; break;
                default: _param = ".view"; break;
            }
            if (permissions != null && permissions.Any(d => d.Trim().ToLower() == _param))
                return true;
            return false;
        }

        public static string GetQueryParm(NavigationManager navigation, string parmName)
        {
            var uriBuilder = new UriBuilder(navigation.Uri);
            var q = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);
            return q[parmName] ?? "";
        }


        public static MarkupString GetStatus(StatusApproval status)
        {
            string text = string.Empty;
            string type = string.Empty;

            switch (status)
            {
                case StatusApproval.None:
                case StatusApproval.NotActive:
                    text = status == StatusApproval.None ? "None" : "Belum Aktif";
                    type = "dark";
                    break;

                case StatusApproval.Draft:
                    text = StatusApproval.Draft.ToString();
                    type = "primary";
                    break;

                case StatusApproval.ProcessApproval:
                case StatusApproval.ProcessApprovalEdit:
                    text = "Dalam Proses Approval";
                    type = "warning";
                    break;

                case StatusApproval.Rejected:
                    text = StatusApproval.Rejected.ToString();
                    type = "danger";
                    break;

                case StatusApproval.Approved:
                    text = StatusApproval.Approved.ToString();
                    type = "success";
                    break;

                case StatusApproval.Active:
                case StatusApproval.ActiveEdit:
                    text = "Aktif";
                    type = "success";
                    break;
            }

            return new MarkupString($"<span class=\"badge badge-light-{type} p-3\">{text}</span>");
        }

        public static MarkupString GetStatus(WorkflowStatusEnum status)
        {
            string text = status.ToString();
            string type = "dark";

            switch (status)
            {
                
                case WorkflowStatusEnum.Reject:
                case WorkflowStatusEnum.Reject_Parallel:
                    text = "Rejected";
                    type = "danger";
                    break;

                case WorkflowStatusEnum.Approve:
                case WorkflowStatusEnum.Approve_Parallel:
                    text = "Selesai";
                    type = "success";
                    break;
            }

            return new MarkupString($"<span class=\"badge badge-light-{type} p-3\">{text}</span>");
        }

        public static MarkupString GetStatus(WorkflowEnum status)
        {
            string text = status.ToString();
            string type = "dark";

            switch (status)
            {
                case WorkflowEnum.Reject:
                    text = "Rejected";
                    type = "danger";
                    break;

                case WorkflowEnum.Approved:
                    text = "Selesai";
                    type = "success";
                    break;
            }

            return new MarkupString($"<span class=\"badge badge-light-{type} p-3\">{text}</span>");
        }

        public static string ParseType(Type type)
        {
            string typename = type.FullName.ToLower();
            if (typename.Contains("guid"))
                return "Guid";
            else if (typename.Contains("boolean"))
                return "bool";
            else if (typename.Contains("datetime"))
                return "DateTime";
            else if (typename.Contains("decimal"))
                return "decimal";
            else if (typename.Contains("double"))
                return "double";
            else if (typename.Contains("int32"))
                return "int";
            else if (typename.Contains("int64"))
                return "long";
            else if (typename.Contains("int16"))
                return "short";
            else if (typename.Contains("single"))
                return "float";
            else if (typename.Contains("string"))
                return "string";
            else if (typename.Contains("byte[]"))
                return "byte[]";
            else
                return type.FullName;
        }
    }

    public static class DialogWidth
    {
        public static DialogOptions XS = new DialogOptions { MaxWidth = MaxWidth.ExtraSmall };
        public static DialogOptions SM = new DialogOptions { MaxWidth = MaxWidth.Small };
        public static DialogOptions MD = new DialogOptions { MaxWidth = MaxWidth.Medium };
        public static DialogOptions LG = new DialogOptions { MaxWidth = MaxWidth.Large };
        public static DialogOptions XL = new DialogOptions { MaxWidth = MaxWidth.ExtraLarge };
        public static DialogOptions XXL = new DialogOptions { MaxWidth = MaxWidth.ExtraExtraLarge};
    }

    public static class CompareHelper
    {
        public static List<CompareData> DoCompareData(object lama, object baru)
        {
            var result = new List<CompareData>();

            var lamaProps = lama.GetType().GetProperties().ToList();
            var baruProps = baru.GetType().GetProperties().ToList();
            var join = (from a in baruProps
                        join b in lamaProps
                        on a.Name equals b.Name
                        select new CompareData
                        {
                            Field = a.Name,
                            Type = StaticMethod.ParseType(a.PropertyType),
                            BeforeValue = lama.GetType().GetProperty(a.Name).GetValue(lama, null)?.ToString() ?? string.Empty,
                            BeforeValueText = string.Empty,
                            AfterValue = baru.GetType().GetProperty(a.Name).GetValue(baru, null)?.ToString() ?? string.Empty,
                            AfterValueText = string.Empty
                        }).ToList();

            return join.Where(_ => _.BeforeValue != _.AfterValue).ToList();
        }

        public static bool CheckIsFieldChanged(List<CompareDataWrapper> data, string section, string field)
        {
            return data.Any(_ => _.Section == section && _.Items.Any(__ => __.Field == field));
        }

        public static string GetValueChanged(List<CompareDataWrapper> data, string section, string field, string defaultValue)
        {
            string result = defaultValue;
            var _data = data.Where(_ => _.Section == section).SelectMany(_ => _.Items).Where(_ => _.Field == field).FirstOrDefault();
            if (_data != null)
            {
                result = string.IsNullOrEmpty(_data.AfterValueText) ? _data.AfterValue : _data.AfterValueText;

                switch (_data.Type)
                {
                    case "DateTime":
                        if (DateTime.TryParse(_data.AfterValue, out DateTime parseResult))
                            result = parseResult.ToString("dd MMMM yyyy");
                        break;

                    case "decimal":
                        if (decimal.TryParse(_data.AfterValue, out decimal decimalParseResult))
                            result = decimalParseResult.ToCurrencyFormat();
                        break;
                }
            }
            return result;
        }
    }
}
