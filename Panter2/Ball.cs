using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

public class Ball:ThreeColorGameObject
    {
     

    bool shooting;

    SoundEffect soundShoot;
    public Ball(ContentManager Content):base(Content, "spr_ball_red", "spr_ball_green", "spr_ball_blue")
    {
        soundShoot = Content.Load<SoundEffect>("snd_shoot_paint");

    }

        public override void Reset()
        {
        base.Reset();
        position = new Vector2(65, 390);
        color = Color.Blue;
        shooting = false;
        velocity = Vector2.Zero;

    }

 

    public override void HandleInput(InputHelper inputHelper)
        {

        if (inputHelper.MouseLeftButtonPressed() && !shooting)
        {
            shooting = true;
            velocity = (inputHelper.MousePosition - Painter.GameWorld.Cannon.Position) * 1.2f;
            soundShoot.Play();
        }

    }

        public override void Update(GameTime gameTime)
        {

        if (shooting)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            velocity.Y += 400.0f * dt;
            position += velocity * dt;
        }
        else
        {
            color = Painter.GameWorld.Cannon.Color;
            position = Painter.GameWorld.Cannon.BallPosition;
        }

        if (Painter.GameWorld.IsOutsideWorld(position))
        {
            Reset();

        }

        base.Update(gameTime);


    }




}

