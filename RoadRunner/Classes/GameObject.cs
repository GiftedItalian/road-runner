using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace RoadRunner.Classes
{
    class GameObject
    {
        Texture2D asset;
        float xPosition;
        float yPosition;
        int speed;
        
        public GameObject(float xPos, float yPos, int speed)
        {
            xPosition = xPos;
            yPosition = yPos;
            this.speed = speed;
        }

        public Texture2D GetAsset()
        {
            return asset;
        }

        public void SetAsset(Texture2D asset)
        {
            this.asset = asset;
        }

        public float GetxPosition()
        {
            return xPosition;
        }

        public void SetxPosition(float xPosition)
        {
            this.xPosition = xPosition;
        }

        public float GetyPosition()
        {
            return yPosition;
        }

        public void SetyPosition(float yPosition)
        {
            this.yPosition = yPosition;
        }

        public int GetSpeed()
        {
            return speed;
        }

        public void SetSpeed(int speed)
        {
            this.speed = speed;
        }

    }
}
