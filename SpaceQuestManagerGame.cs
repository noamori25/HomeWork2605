using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2605
{
    class SpaceQuestManagerGame
    {
        private int _goodSpaceShipHitPoints = 100;
        private int _shipXLocation;
        private int _shipYLocation;
        private int _numberOfBadShips;
        private int _currentLevel;

        public event EventHandler<PointsEventArgs> GoodSpaceShipHPChanged;
        public event EventHandler<LocationEventArgs> GoodSpaceShipLcationChanged;
        public event EventHandler<LocationEventArgs> GoodSpaceShipDestroyed;
        public event EventHandler<BadShipsExplodedEventArgs> BadShipsExploded;
        public event EventHandler<LevelUpEventArgs> LevelUpReached;


        public SpaceQuestManagerGame(int _goodSpaceShipHitPoints, int _shipXLocation, int _shipYLocation, int _numberOfBadShips)
        {
            this._goodSpaceShipHitPoints = _goodSpaceShipHitPoints;
            this._shipXLocation = _shipXLocation;
            this._shipYLocation = _shipYLocation;
            this._numberOfBadShips = _numberOfBadShips;
            _currentLevel = 1;

        }

        public void MoveSpaceShip (int newX, int newY)
        {
            this._shipXLocation = newX;
            this._shipYLocation = newY;
            OnGoodSpaceShipLocation();
        }

        public void GoodSpaceShipGotDamaged (int damage)
        {
            this._goodSpaceShipHitPoints -= damage;
            OnGoodSpaceShipHPChanged();

            if (_goodSpaceShipHitPoints <= 0)
            {
                OnGoodSpaceShipDestroyed();
                _currentLevel = 1;
            }
        }

        public void GoodSpaceShipGotExtraHP (int extra)
        {
            this._goodSpaceShipHitPoints += extra;
            OnGoodSpaceShipHPChanged();

        }

        public void EnemyShipsDestroyed (int numberOfBadShipsDestroyed)
        {
            _numberOfBadShips -= numberOfBadShipsDestroyed;
            OnBadShipsExploded();
            if (_numberOfBadShips <= 0)
            {
                OnLevelUpReached();
                _goodSpaceShipHitPoints = 100;
            }
        }

        private void OnGoodSpaceShipHPChanged ()
        {
            if (GoodSpaceShipHPChanged != null)
            {
                GoodSpaceShipHPChanged.Invoke(this, new PointsEventArgs { HitPoints = _goodSpaceShipHitPoints });
            }
        }
        private void OnGoodSpaceShipLocation()
        {
            if (GoodSpaceShipLcationChanged != null)
            {
                GoodSpaceShipLcationChanged.Invoke(this, new LocationEventArgs { X = _shipXLocation, Y = _shipYLocation });
            }
        }
        private void OnGoodSpaceShipDestroyed()
        {
            if (GoodSpaceShipDestroyed != null)
            {
                GoodSpaceShipDestroyed.Invoke(this, new LocationEventArgs { X = _shipXLocation, Y = _shipYLocation });
            }
        }
        private void OnBadShipsExploded()
        {
            if (BadShipsExploded != null)
            {
                BadShipsExploded.Invoke(this, new BadShipsExplodedEventArgs { NumberOfExplodedBadShips = _numberOfBadShips });
            }
        }
        private void OnLevelUpReached()
        {
            if (LevelUpReached != null)
            {
                LevelUpReached.Invoke(this, new LevelUpEventArgs { CurrenLevel = _currentLevel });
            }
        }
    }
}
