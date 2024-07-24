// See https://aka.ms/new-console-template for more information
using AsciiGames;

Console.WriteLine("SPECTREK 0.1");

SpecTrek specTrek = SpecTrek.Instance;
specTrek.Init();
specTrek.Play();