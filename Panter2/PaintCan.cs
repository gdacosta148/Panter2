using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

public class PaintCan :ThreeColorGameObject
    {

   
    Color targetcolor;

    float minSpeed;

    SoundEffect correctscore;

    public PaintCan(ContentManager Content, float positionOffset, Color target):base (Content, "spr_can_red", "spr_can_green", "spr_can_blue")
 {


        targetcolor = target;
        position = new Vector2(positionOffset, -origin.Y);
        minSpeed = 30;

        correctscore = Content.Load<SoundEffect>("snd_collect_points");

    }

    public override void Update(GameTime gameTime)
 {
        // TODO: We’ll fill in this method soon.

       

        float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
        minSpeed += 0.01f * dt;

        base.Update(gameTime);

       rotation = (float)Math.Sin(position.Y / 50.0) * 0.05f;

        if (velocity != Vector2.Zero)
        {
            position += velocity * dt;

            if (BoundingBox.Intersects(Painter.GameWorld.Ball.BoundingBox))
            {
                color = Painter.GameWorld.Ball.Color;
                Painter.GameWorld.Ball.Reset();
            }

            // reset the can if it leaves the screen
            if (Painter.GameWorld.IsOutsideWorld(position - origin))
            {
                if (color != targetcolor)
                {
                    Painter.GameWorld.LoseLife();
                }

                else
                {
                    Painter.GameWorld.Score += 10; // this line is new!

                    correctscore.Play();

                }
                Reset();
            }
        }

        else if(Painter.Random.NextDouble() < 0.01)
        {
            velocity = CalculateRandomVelocity();
            color = CalculateRandomColor();
        }

        
    }



    public override void Reset()
 {
        base.Reset();
        color = Color.Blue;
        position.Y = -origin.Y;
        velocity = Vector2.Zero;
    }

    public void ResetMinSpeed()
    {
        minSpeed = 30;
    }

    Vector2 CalculateRandomVelocity()
    {
        return new Vector2(0.0f, (float)Painter.Random.NextDouble() * 30 + minSpeed);
    }

    Color CalculateRandomColor()
    {
        int randomval = Painter.Random.Next(3);
        if (randomval == 0)
            return Color.Red;
        else if (randomval == 1)
            return Color.Green;
        else
            return Color.Blue;
    }



}

