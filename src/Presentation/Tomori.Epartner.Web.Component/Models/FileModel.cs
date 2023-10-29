namespace Tomori.Epartner.Web.Component.Models
{
    public class FileModel
    {
        public int No { get; set; }
        public Guid Id { get; set; } = Guid.Empty;
        public string Kode { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Filename { get; set; }
        public bool IsLoading { get; set; } = false;
        public bool IsUploaded { get; set; } = false;
        public bool IsMandatory { get; set; } = false;
        public string MimeType { get; set; }
        public string Base64 { get; set; }
        public List<string> AcceptTypes { get; set; }
        public long Size { get; set; } = 0;

        public FileModel()
        {

        }

        public FileModel(int no, string kode, string title, string description, bool isMandatory, List<string> acceptTypes)
        {
            No = no;
            Kode = kode;
            Title = title;
            Description = description;
            IsMandatory = isMandatory;
            AcceptTypes = acceptTypes;
        }

        public string GetAcceptType()
        {
            return string.Join(", ", AcceptTypes);
        }
    }
    public class FileModelWrapper<T>
    {
        public Guid Id { get; set; }
        public T Data { get; set; }
        public string Filename { get; set; }
        public bool IsLoading { get; set; }
        public bool IsUploaded { get; set; }

        public FileModelWrapper()
        {

        }

        public FileModelWrapper(T data)
        {
            Id = Guid.NewGuid();
            Data = data;
            Filename = string.Empty;
            IsLoading = false;
            IsUploaded = false;
        }
    }
}
