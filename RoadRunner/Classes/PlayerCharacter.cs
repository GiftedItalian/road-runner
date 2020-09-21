using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Transactions;

namespace RoadRunner.Classes
{
    class PlayerCharacter : GameObject
    {
        public PlayerCharacter(float xPos, float yPos, int speed) : base(xPos, yPos, speed)
        {

        }


        public void Movement(float xPos, float yPos, int speed, GameTime gameTime, Texture2D backgroundBorder)
        {
            var kstate = Keyboard.GetState();

            if (this.GetxPosition() >= backgroundBorder.Width * 3.125 - 125 )
            {
                if (kstate.IsKeyDown(Keys.Up))
                {
                    this.SetyPosition(this.GetyPosition() - this.GetSpeed() * (float)gameTime.ElapsedGameTime.TotalSeconds);
                }
                if (kstate.IsKeyDown(Keys.Down))
                {
                    this.SetyPosition(this.GetyPosition() + this.GetSpeed() * (float)gameTime.ElapsedGameTime.TotalSeconds);
                }
                if (kstate.IsKeyDown(Keys.Left))
                {
                    this.SetxPosition(this.GetxPosition() - this.GetSpeed() * (float)gameTime.ElapsedGameTime.TotalSeconds);
                }
            }
            else if (this.GetxPosition() <= 0 + 125)
            {
                if (kstate.IsKeyDown(Keys.Up))
                {
                    this.SetyPosition(this.GetyPosition() - this.GetSpeed() * (float)gameTime.ElapsedGameTime.TotalSeconds);
                }
                if (kstate.IsKeyDown(Keys.Down))
                {
                    this.SetyPosition(this.GetyPosition() + this.GetSpeed() * (float)gameTime.ElapsedGameTime.TotalSeconds);
                }
                if (kstate.IsKeyDown(Keys.Right))
                {
                    this.SetxPosition(this.GetxPosition() + this.GetSpeed() * (float)gameTime.ElapsedGameTime.TotalSeconds);
                }
            }
            else if (this.GetyPosition() >= backgroundBorder.Height * 3.15)
            {
                if (kstate.IsKeyDown(Keys.Up))
                {
                    this.SetyPosition(this.GetyPosition() - this.GetSpeed() * (float)gameTime.ElapsedGameTime.TotalSeconds);
                }
                if (kstate.IsKeyDown(Keys.Left))
                {
                    this.SetxPosition(this.GetxPosition() - this.GetSpeed() * (float)gameTime.ElapsedGameTime.TotalSeconds);
                }
                if (kstate.IsKeyDown(Keys.Right))
                {
                    this.SetxPosition(this.GetxPosition() + this.GetSpeed() * (float)gameTime.ElapsedGameTime.TotalSeconds);
                }
            }
            else if (this.GetyPosition() <= 0)
            {
                if (kstate.IsKeyDown(Keys.Down))
                {
                    this.SetyPosition(this.GetyPosition() + this.GetSpeed() * (float)gameTime.ElapsedGameTime.TotalSeconds);
                }
                if (kstate.IsKeyDown(Keys.Left))
                {
                    this.SetxPosition(this.GetxPosition() - this.GetSpeed() * (float)gameTime.ElapsedGameTime.TotalSeconds);
                }
                if (kstate.IsKeyDown(Keys.Right))
                {
                    this.SetxPosition(this.GetxPosition() + this.GetSpeed() * (float)gameTime.ElapsedGameTime.TotalSeconds);
                }
            }
            else
            {
                if (kstate.IsKeyDown(Keys.Up))
                {
                    this.SetyPosition(this.GetyPosition() - this.GetSpeed() * (float)gameTime.ElapsedGameTime.TotalSeconds);
                }
                if (kstate.IsKeyDown(Keys.Down))
                {
                    this.SetyPosition(this.GetyPosition() + this.GetSpeed() * (float)gameTime.ElapsedGameTime.TotalSeconds);
                }
                if (kstate.IsKeyDown(Keys.Left))
                {
                    this.SetxPosition(this.GetxPosition() - this.GetSpeed() * (float)gameTime.ElapsedGameTime.TotalSeconds);
                }
                if (kstate.IsKeyDown(Keys.Right))
                {
                    this.SetxPosition(this.GetxPosition() + this.GetSpeed() * (float)gameTime.ElapsedGameTime.TotalSeconds);
                }
            }
        }

        public void CollisionDetection(GameObject objectOne, GameObject objectTwo, int height, int width, GameManager game)
        {
            Rectangle objectOneOutline = new Rectangle((int)objectOne.GetxPosition(), (int)objectOne.GetyPosition(), height, width);
            Rectangle objectTwoOutline = new Rectangle((int)objectTwo.GetxPosition(), (int)objectTwo.GetyPosition(), height, width);

            if (objectOneOutline.Intersects(objectTwoOutline))
            {
                if (objectTwo.GetAsset().Name == "treasure")
                {
                    game.SetIsTreasureReached(true);
                }

                if (objectTwo.GetAsset().Name == "enemy")
                    game.SetIsGameOver(true);
            }
        }
    }
}
