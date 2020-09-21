using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoadRunner.Classes
{
    class GameManager
    {
        private bool isGameOver = false;
        private bool isTreasureReached = false;
        private int playerLevel = 1;
        
        public void SetIsGameOver(bool isGameOver)
        {
            this.isGameOver = isGameOver;
        }

        public bool GetIsGameOver()
        {
            return isGameOver;
        }

        public void SetIsTreasureReached(bool isTreasureReached)
        {
            this.isTreasureReached = isTreasureReached;
        }

        public bool GetIsTreasureReached()
        {
            return isTreasureReached;
        }

        public void SetPlayerLevel(int playerLevel)
        {
            this.playerLevel = playerLevel;
        }

        public int GetPlayerLevel()
        {
            return playerLevel;
        }

        public void GameLogic(PlayerCharacter player, EnemyCharacter enemy, EnemyCharacter enemy2, EnemyCharacter enemy3, EnemyCharacter enemy4, EnemyCharacter enemy5, GameObject treasure, GameTime gameTime, Texture2D background)
        {
            List<EnemyCharacter> enemyList = new List<EnemyCharacter>();


            if (this.GetIsGameOver() == false && this.GetIsTreasureReached() == false)
            {
                // TODO: Add your update logic here
                player.Movement(player.GetxPosition(), player.GetyPosition(), player.GetSpeed(), gameTime, background);
                enemy.Movement(enemy.GetxPosition(), enemy.GetSpeed(), gameTime);
                enemy2.Movement(enemy2.GetxPosition(), enemy2.GetSpeed(), gameTime);
                enemy3.Movement(enemy3.GetxPosition(), enemy3.GetSpeed(), gameTime);
                enemy4.Movement(enemy4.GetxPosition(), enemy4.GetSpeed(), gameTime);
                enemy5.Movement(enemy5.GetxPosition(), enemy5.GetSpeed(), gameTime);

                player.CollisionDetection(player, enemy, 36, 36, this);
                player.CollisionDetection(player, enemy2, 36, 36, this);
                player.CollisionDetection(player, enemy3, 36, 36, this);
                player.CollisionDetection(player, enemy4, 36, 36, this);
                player.CollisionDetection(player, enemy5, 36, 36, this);
                player.CollisionDetection(player, treasure, 36, 36, this);

            }
            else if (this.GetIsGameOver() == true)
            {
                this.SetPlayerLevel(1);
                enemy.ResetSpeed();
                enemy2.ResetSpeed();
                enemy3.ResetSpeed();
                enemy4.ResetSpeed();
                enemy5.ResetSpeed();
                player.SetyPosition(775);
                player.SetxPosition(400);
                this.SetIsGameOver(false);
            }
            else if (this.GetIsTreasureReached() == true)
            {
                this.SetPlayerLevel(this.GetPlayerLevel() + 1);
                enemy.IncreaseSpeed(this);
                enemy2.IncreaseSpeed(this);
                enemy3.IncreaseSpeed(this);
                enemy4.IncreaseSpeed(this);
                enemy5.IncreaseSpeed(this);

                player.SetyPosition(775);
                player.SetxPosition(400);
                this.SetIsTreasureReached(false);
            }
        }

    }
}
