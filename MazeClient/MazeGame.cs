using Ninject;
using System;

namespace MazeClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            IKernel kernal = new StandardKernel(new IntegrationModule());
            var game = new GameClient(kernal.Get<IMazeIntegration>());
            game.Play();
            Console.ReadLine();
            Console.ReadLine();
        }
    }
}

