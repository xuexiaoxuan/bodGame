// See https://aka.ms/new-console-template for more information
using PodGame;
//初始话玩家
GameContext gameContext = new GameContext();
Player playerA = new Player(Show) { Name = "玩家A" };
playerA.OnPlayerChanged += PlayerA_OnPlayerChanged;
Player playerB = new Player(Show) { Name = "玩家B" };
playerB.OnPlayerChanged += PlayerA_OnPlayerChanged;
gameContext.AddPlayer(playerA);
gameContext.AddPlayer(playerB);
Console.WriteLine("-------------------游戏规则------------------");
Console.WriteLine("-----玩家输入三位非负整数例如（356）3是第一行要保留的数量、5是第二行要保留的数量、6是第三行要保留的数量------------");
Console.WriteLine("-----不允许跨行两个玩家轮流输入，玩家拿到最后全部是0时玩家输注（1是保留数量，0是拿掉数量）-------------------------");
//运行
gameContext.Run();
/// <summary>
/// 展示
/// </summary>
void Show(int[][] _pods)
{
    foreach (var m in _pods)
    {
        foreach (var n in m)
        {
            Console.Write($"--{n}--");
        }
        Console.WriteLine();
    }
}
void PlayerA_OnPlayerChanged(object? sender, DataEventArgs<string> e)
{
    Console.WriteLine(e.Data);
}



