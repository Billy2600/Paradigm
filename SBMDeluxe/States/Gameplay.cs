﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace SMBDeluxe.States
{
    class Gameplay : GameState
    {
        private EntityManager entityManager;
        private TileManager tileManager;
        private InputManager inputManager;
        private FloatRect camera;
        private Entities.Player player;
        private AnimManager animManager;

        public Gameplay(ContentManager contentMgr)
        {
            inputManager = new InputManager();
            tileManager = new TileManager();
            entityManager = new EntityManager(contentMgr, animManager);
            animManager = new AnimManager();
        }

        public override void Start(ContentManager content)
        {
            player = new Entities.Player(tileManager, animManager);
            player.animManager = animManager;
            entityManager.Add(player);
            entityManager.LoadContent();
            tileManager.LoadFromFile("Content\\1-1.tmx", content);
            animManager.LoadFromFile("Content\\animations.xml");
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            tileManager.Draw(spriteBatch, camera);
            entityManager.Draw(spriteBatch);
            entityManager.CheckDelete();
        }

        public override void Update(float dt)
        {
            animManager.gameTime = gameTime;
            player.SetInputs(inputManager.ReadInputs());
            entityManager.Think(dt);
        }

        public override void HandleInput()
        {

        }
    }
}
