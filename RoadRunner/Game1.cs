using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using RoadRunner.Classes;
using System.Collections.Generic;
using System.Diagnostics;

namespace RoadRunner
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        PlayerCharacter player = new PlayerCharacter(400, 775, 200);
        EnemyCharacter enemy = new EnemyCharacter(650, 650, 200);
        EnemyCharacter enemy2 = new EnemyCharacter(160, 550, 200);
        EnemyCharacter enemy3 = new EnemyCharacter(650, 450, 200);
        EnemyCharacter enemy4 = new EnemyCharacter(160, 350, 200);
        EnemyCharacter enemy5 = new EnemyCharacter(650, 250, 200);
        GameObject treasure = new GameObject(400, 100, 0);
        GameManager game = new GameManager();
        Text levelText = new Text(10,10,0);

        Texture2D background;
        Song song;
        Song treasureSound;
        Song gameOverSound;

        float _scale = 3.125f;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 800;
            _graphics.ApplyChanges();

            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            background = Content.Load<Texture2D>("background");
            player.SetAsset(Content.Load<Texture2D>("player"));
            enemy.SetAsset(Content.Load<Texture2D>("enemy"));
            enemy2.SetAsset(Content.Load<Texture2D>("enemy"));
            enemy3.SetAsset(Content.Load<Texture2D>("enemy"));
            enemy4.SetAsset(Content.Load<Texture2D>("enemy"));
            enemy5.SetAsset(Content.Load<Texture2D>("enemy"));
            treasure.SetAsset(Content.Load<Texture2D>("treasure"));
            levelText.SetText(Content.Load<SpriteFont>("LevelText"));


            song = Content.Load<Song>("game");
            treasureSound = Content.Load<Song>("treasureSound");
            gameOverSound = Content.Load<Song>("enemyCollisionSoundEffect");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (MediaPlayer.State != MediaState.Playing)
            {
                MediaPlayer.Play(song);
            }
            if (game.GetIsTreasureReached() == true)
            {
                MediaPlayer.Play(treasureSound);
            }
            if(game.GetIsGameOver() == true)
            {
                MediaPlayer.Play(gameOverSound);
            }

            game.GameLogic(player, enemy, enemy2, enemy3, enemy4, enemy5, treasure, gameTime, background);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(); 
            _spriteBatch.Draw(background, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, _scale, SpriteEffects.None, 0f);
           
            _spriteBatch.Draw(enemy.GetAsset(), new Vector2(enemy.GetxPosition(), enemy.GetyPosition()), null, Color.White, 0f, new Vector2(enemy.GetAsset().Width / 2, enemy.GetAsset().Height / 2), _scale, SpriteEffects.None, 0f);
            _spriteBatch.Draw(enemy.GetAsset(), new Vector2(enemy2.GetxPosition(), enemy2.GetyPosition()), null, Color.White, 0f, new Vector2(enemy2.GetAsset().Width / 2, enemy2.GetAsset().Height / 2), _scale, SpriteEffects.None, 0f);
            _spriteBatch.Draw(enemy.GetAsset(), new Vector2(enemy3.GetxPosition(), enemy3.GetyPosition()), null, Color.White, 0f, new Vector2(enemy3.GetAsset().Width / 2, enemy3.GetAsset().Height / 2), _scale, SpriteEffects.None, 0f);
            _spriteBatch.Draw(enemy.GetAsset(), new Vector2(enemy4.GetxPosition(), enemy4.GetyPosition()), null, Color.White, 0f, new Vector2(enemy4.GetAsset().Width / 2, enemy4.GetAsset().Height / 2), _scale, SpriteEffects.None, 0f);
            _spriteBatch.Draw(enemy.GetAsset(), new Vector2(enemy5.GetxPosition(), enemy5.GetyPosition()), null, Color.White, 0f, new Vector2(enemy5.GetAsset().Width / 2, enemy5.GetAsset().Height / 2), _scale, SpriteEffects.None, 0f);
            _spriteBatch.Draw(treasure.GetAsset(), new Vector2(treasure.GetxPosition(), treasure.GetyPosition()), null, Color.White, 0f, new Vector2(treasure.GetAsset().Width / 2, treasure.GetAsset().Height / 2), _scale, SpriteEffects.None, 0f);
            _spriteBatch.Draw(player.GetAsset(), new Vector2(player.GetxPosition(), player.GetyPosition()), null, Color.White, 0f, new Vector2(player.GetAsset().Width / 2, player.GetAsset().Height / 2), _scale, SpriteEffects.None, 0f);
            _spriteBatch.DrawString(levelText.GetText(), $"Level   {game.GetPlayerLevel()}", new Vector2(levelText.GetxPosition(), levelText.GetyPosition()), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
