namespace MauiApp1
{
    public class MauiApp1
    {
        public static async Task Main(string[] args)
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>();

            var app = builder.Build();

        }
    }

    public interface IFileCopyService
    {
        Task<string> CopyFileAsync(Stream fileStream, string fileName, string targetFolderPath);
    }

    public class FileCopyService : IFileCopyService
    {
        public async Task<string> CopyFileAsync(Stream fileStream, string fileName, string targetFolderPath)
        {
            var targetFilePath = Path.Combine(targetFolderPath, fileName);

            using (var targetFileStream = File.Create(targetFilePath))
            {
                await fileStream.CopyToAsync(targetFileStream);
            }

            return targetFilePath;
        }
    }
}


