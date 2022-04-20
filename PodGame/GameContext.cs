using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodGame
{
    public class GameContext
    {
        public GameContext()
        {
            players=new List<Player>();
        }
        public void AddPlayer(Player player)
        {
            players.Add(player);
        }
      private List<Player> players { get; set; }
      private Player player { get; set; }
        public int[][] pods =
            {
                new int [] {1,1,1},
                new int [] {1,1,1,1,1},
                new int [] {1,1,1,1,1,1,1},
            };
        public void Run()
        {
            while (true)
            {
                if(player != players[0])
                {
                    player=players[0];
                }else if (player != players[1])
                {
                    player = players[1];
                }
                if (player.Play(pods))
                {
                    break;
                }
            }
        }
    }
}
