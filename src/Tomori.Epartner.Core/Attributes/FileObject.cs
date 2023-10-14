namespace Tomori.Epartner.Core.Attributes
{
    public class FileObject
    {
        public string Filename { get; set; }
        public string MimeType { get; set; }
        public string Base64 { get; set; }
    }

    public class FileByteObject
    {
        public byte[] FIle { get; set; }
        public string Filename { get; set; }
        public string MimeType { get; set; }
    }
}
