using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoadRunner.Classes
{
    class EnemyCharacter : GameObject
    {
        public EnemyCharacter(float xPos, float yPos, int speed) : base(xPos, yPos, speed)
        {

        }

        public void Movement(float xPos, int speed, GameTime gameTime)
        {
            if (this.GetxPosition() >= 655 || this.GetxPosition() <= 145)
                this.SetSpeed(this.GetSpeed() * -1);

            this.SetxPosition(this.GetxPosition() - this.GetSpeed() * (float)gameTime.ElapsedGameTime.TotalSeconds);
        }

        public void IncreaseSpeed(GameManager game)
        {
            if (this.GetSpeed() < 0)
            {
                if (this.GetSpeed() <= -1175)
                {
                    //do nothing
                }
                else
                {
                    this.SetSpeed(this.GetSpeed() - game.GetPlayerLevel() * 25);
                }
            }
            else if (this.GetSpeed() >= 0)
            {
                if (this.GetSpeed() >= 1175)
                {
                    //do nothing
                }
                else
                {
                    this.SetSpeed(this.GetSpeed() + game.GetPlayerLevel() * 25);
                }
            }
        }

        public void ResetSpeed()
        {
            this.SetSpeed(200);
        }
    }
}
