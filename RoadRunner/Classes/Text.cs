using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoadRunner.Classes
{
    class Text : GameObject
    {
        SpriteFont text;

        public Text(float xPos, float yPos, int speed) : base(xPos, yPos, speed)
        {

        }

        public SpriteFont GetText()
        {
            return text;
        }

        public void SetText(SpriteFont text)
        {
            this.text = text;
        }
    }
}
