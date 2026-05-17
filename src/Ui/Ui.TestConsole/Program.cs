using System.Drawing;

using codingfreaks.obscene.Ui.TestConsole;

Concept.Demo(() =>
{
    Console.WriteLine("Circle was drawn. Hit any key to exit.");
    Console.ReadKey();
}, new Point(200,200), new Size(100,100));