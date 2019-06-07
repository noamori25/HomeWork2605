using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2605
{
    class Program
    {
        static void Main(string[] args)
        {
            GameViewer gv = new GameViewer();
            SpaceQuestManagerGame sp = new SpaceQuestManagerGame(100, 3, 5, 20);

            sp.BadShipsExploded += gv.BadShipsExplodedEventHandler;
            sp.GoodSpaceShipDestroyed += gv.GoodSpaceShipDestroyedEventHandler;
            sp.GoodSpaceShipHPChanged += gv.GoodSpaceShipHPChangedEventHandler;
            sp.LevelUpReached += gv.LevelUpReachedEventHandler;
            sp.GoodSpaceShipLcationChanged += gv.GoodSpaceShipLocationEventHandler;

            Random rnd = new Random();
            int result = rnd.Next(1, 5);
            switch (result)
            {
                case 1:
                    sp.EnemyShipsDestroyed(20);
                    break;
                case 2:
                    sp.GoodSpaceShipGotDamaged(65);
                    break;
                case 3:
                    sp.GoodSpaceShipGotExtraHP(55);
                    break;
                case 4:
                    sp.MoveSpaceShip(6, 8);
                    break;
            }
        }


    }
}
