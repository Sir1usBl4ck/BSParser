using System.IO.Compression;
using System.Net;

namespace BSParser;

public class DownloadService
{
    public static async Task CheckDownload(string requestUrl)
    {
        var directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Downloads");
        var di = new DirectoryInfo(directory);
        if (di.Exists && di.GetFiles("*",SearchOption.AllDirectories).Length > 0)
        {
            Console.WriteLine("Files already present.");
            Console.WriteLine("Do you wish to download them again? : Y/N");
            var input = Console.ReadLine();
            if (input.ToLower() == "y")
            {
                await Download(requestUrl, directory);
                return;

            }

            return;

        }

        Console.WriteLine("Do you want to Download the files from");
        Console.WriteLine($"{requestUrl} ?");
        Console.WriteLine("Y/N");
        var result = Console.ReadLine()?.ToLower();
        if (result == "y")
        {
            await Download(requestUrl, directory);
        }


    }
    public static async Task Download(string requestUrl, string directory)
    {
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        var path = Path.Combine(directory, "repo.zip");

        Console.WriteLine("Downloading...");

        var client = new HttpClient();
        var responseStream = await client.GetStreamAsync(requestUrl);


        using (WebClient Client = new WebClient())
        {
            Client.DownloadFile(requestUrl, path
            );
        }
        Console.WriteLine("Download Completed");
        var di = new DirectoryInfo(directory);
        var files = di.GetFiles();

        ExtractFile(path, directory);
        Console.WriteLine("Cleaning up...");
        foreach (var file in files)
        {
            if (file.Extension != ".cat")
            {
                file.Delete();
            }
        }



    }

    public static void ExtractFile(string sourcePath, string destinationPath)
    {
        Console.WriteLine("Extracting Files...");
        var finalPath = string.Empty;
        using (var archive = ZipFile.OpenRead(sourcePath))
        {
            finalPath = Path.Combine(destinationPath, archive.Entries[0].FullName);
        }

        if (Directory.Exists(finalPath))
        {

            Directory.Delete(finalPath, true);
        }

        ZipFile.ExtractToDirectory(sourcePath, destinationPath);
        Console.WriteLine("Extraction Completed");
        File.Delete(sourcePath);
        Console.WriteLine($"Files Extracted at: {finalPath}");

    }
}