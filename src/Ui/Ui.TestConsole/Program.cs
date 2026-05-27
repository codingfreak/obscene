using System.Drawing;

using codingfreaks.obscene.Ui.TestConsole;

// var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "test.json");
// var camera = await Concept.GetObsCameraSettingsAsync(path, "1080 BottomLeft", "SYS CamCircle");
// var position = new Point((int)camera.pos.x, (int)camera.pos.y);
// var radius = (int)(camera.scale.x * camera.scale_ref.x) / 2;
// Concept.Demo(() =>
// {
//     Console.WriteLine("Circles drawn. Hit any key to exit.");
//     Console.ReadKey();
// }, position, radius);
// TODO
// - if the x and/or y of the geometry is smaller that the radius it will not draw
// - OBS has some offsets on my camera overlay. we need to consider this
Concept.Demo(() =>
{
    Console.WriteLine("Circles drawn. Hit any key to exit.");
    Console.ReadKey();
}, new Point(100,100), 100);
