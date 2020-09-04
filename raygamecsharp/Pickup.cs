using System;
using System.Collections.Generic;
using System.Text;
using static Raylib_cs.Raylib;  // core methods (InitWindow, BeginDrawing())
using static Raylib_cs.Color;   // color (RAYWHITE, MAROON, etc.)
using static Raylib_cs.Raymath; // mathematics utilities and operations (Vector2Add, etc.)
using System.Numerics;          // mathematics types (Vector2, Vector3, etc.)
using Examples;

namespace raygamecsharp
{
    class Pickup : Sprite
    {
        List<Vector2> locations = new List<Vector2>();

        public int screenWidth { get; private set; }
        public int screenHeight { get; private set; }

        //void SpawnRing()
        //{
        //    Random rand = new Random();

        //    for (int i = 0; i < 10; i++)
        //    {
        //        Vector2 tmpLocation = new Vector2(rand.Next(25, screenWidth - 25), rand.Next(25, screenHeight - 25));

        //        while (ListContains(tmpLocation))
        //        {
        //            tmpLocation = new Vector2(rand.Next(25, screenWidth - 25), rand.Next(25, screenHeight - 25));
        //        }
        //        locations.Add(tmpLocation);


        //    }

        //}
        //bool ListContains(Vector2 vector)
        //{
        //    for (int i = 0; i < locations.Count; i++)
        //    {
        //        if (locations[i].X == vector.X && locations[i].Y == vector.Y)
        //        {
        //            return false;
        //        }

        //    }
        //    return true;
        //}
        public Pickup()
        {
            myColor = GOLD;
        }


        public void Draw()
        {
            if (!active)
            {
                return;
            }
            
            DrawRing(position, 5, 10, 0, 360, 36, myColor);
        }



    }
}
