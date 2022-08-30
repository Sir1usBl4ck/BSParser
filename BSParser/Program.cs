using BSParser;

Console.WriteLine("*** BATTLESCRIBE DATA DOWNLOADER***");
Console.WriteLine("--------------------------------------");
Console.WriteLine("This program will download Warcry Battlescribe files from Github and parse them into c# classes");
Console.WriteLine("Check Model Folder for details");
Console.WriteLine("\n");
var url = "https://github.com/BSData/warhammer-age-of-sigmar-warcry/archive/refs/heads/master.zip";
await DownloadService.CheckDownload(url);

var directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Downloads");

var files = Directory.GetFiles(directory, "*.cat", SearchOption.AllDirectories);

var parser = new Parser();

Console.WriteLine("Choose File:");

for (int i = 0; i < files.Length; i++)
{
    Console.WriteLine($"{i}-{Path.GetFileName(files[i])}");
}

var input = Console.ReadLine();
parser.CreateUnits(files[int.Parse(input)]);





