namespace TestNinja.Mocking
{
    public class FileDowloadfile
    {
       public interface IFileDownloader
        {
            void DownloadFile(string url, string path);
        }
        public class FileDownloader : IFileDownloader
        {
            public void DowloadFile(string url, string path)
            {
                var client = new WebClient();
                client.DowloadFile(url, path);
            }
        }
    }
}