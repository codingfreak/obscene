using System.Text;

using codingfreaks.obscene.Ui.TestConsole;

Console.OutputEncoding = Encoding.UTF8;
//var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "test.json");
//await Concept.DrawObsDeviceOverlayAsync("SYS CamCircle");
//await Concept.DrawObsDeviceOverlayAsync(path, "1080 BottomLeft", "SYS CamCircle");
await Concept.RunbObsConnectionDemoAsync();
