// See https://aka.ms/new-console-template for more information


using Domain;
using Microsoft.Extensions.DependencyInjection;
using MinesweeperGame;
using Services;

var serviceCollection = new ServiceCollection();
var serviceProvider = serviceCollection.AddSingleton<Board>(new Board(8))
           .AddSingleton<IPlayerService, PlayerService>()  // Register Service
           .AddSingleton<IBoardService, BoardService>()  // Register Service
           .AddSingleton<MinesweeperController>()
           .AddSingleton<MineSweeperGameConsole>() // Register Console Class
           .BuildServiceProvider();

// Resolve the service
var console = serviceProvider.GetRequiredService<MineSweeperGameConsole>();
// Start the game
console.StartGame();

