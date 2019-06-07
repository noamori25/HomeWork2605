using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2605
{
    class GameViewer
    {
        public void GoodSpaceShipHPChangedEventHandler (object o, PointsEventArgs p)
        {
            Console.WriteLine(p.HitPoints);
        }
        public void GoodSpaceShipLocationEventHandler (object o, LocationEventArgs l)
        {
            Console.WriteLine(l.X + " " + l.Y);

        }
        public void GoodSpaceShipDestroyedEventHandler (object o, LocationEventArgs l)
        {
            Console.WriteLine(l.X + " " + l.Y);
        }
        public void BadShipsExplodedEventHandler (object o, BadShipsExplodedEventArgs b)
        {
            Console.WriteLine(b.NumberOfExplodedBadShips);
        }
        public void LevelUpReachedEventHandler (object o, LevelUpEventArgs l)
        {
            Console.WriteLine(l.CurrenLevel);
        }
            
    }
}
