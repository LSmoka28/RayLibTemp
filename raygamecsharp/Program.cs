/*******************************************************************************************
*
*   raylib [core] example - Basic window
*
*   Welcome to raylib!
*
*   To test examples, just press F6 and execute raylib_compile_execute script
*   Note that compiled executable is placed in the same folder as .c file
*
*   You can find all basic examples on C:\raylib\raylib\examples folder or
*
*   Enjoy using raylib. :)
*
*   This example has been created using raylib-cs 3.0 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   This example was lightly modified to provide additional 'using' directives to make
*   common math types and utilities readily available, though they are not using in this sample.
*
*   Copyright (c) 2019-2020 Academy of Interactive Entertainment (@aie_usa)
*   Copyright (c) 2013-2016 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using static Raylib_cs.Raylib;  // core methods (InitWindow, BeginDrawing())
using static Raylib_cs.Color;   // color (RAYWHITE, MAROON, etc.)
using static Raylib_cs.Raymath; // mathematics utilities and operations (Vector2Add, etc.)
using System.Numerics;          // mathematics types (Vector2, Vector3, etc.)
using raygamecsharp;
using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace Examples
{
    public class core_basic_window
    {
        public static int Main()
        {
            // Initialization
            //--------------------------------------------------------------------------------------
            const int screenWidth = 800;
            const int screenHeight = 450;

            InitWindow(screenWidth, screenHeight, "raylib [core] example - basic window");

            SetTargetFPS(60);
            //--------------------------------------------------------------------------------------
            Random rand = new Random();
            Player myPlayer = new Player();
            
            bool gameRunning = true;

            Pickup[] rings = new Pickup[10];
            List<int> sonicRings = new List<int>();

            List<Vector2> locations = new List<Vector2>();



            for (int i = 0; i < 10; i++)
            {
                rings[i] = new Pickup();
                int randX = rand.Next(25, screenWidth - 25);
                int randY = rand.Next(25, screenHeight - 25);
                rings[i].position.X = randX;
                rings[i].position.Y = randY;

                

            }

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
            //    for(int i = 0; i < locations.Count; i++)
            //    {
            //        if (locations[i].X == vector.X && locations[i].Y == vector.Y)
            //        {
            //            return false;
            //        }
                    
            //    }
            //    return true;
            //}


            int score = 0;
            // Main game loop
            while (!WindowShouldClose() && gameRunning)    // Detect window close button or ESC key
            {
                // Update
                //----------------------------------------------------------------------------------
                // TODO: Update your variables here
                //----------------------------------------------------------------------------------

                // Draw
                //----------------------------------------------------------------------------------

                myPlayer.Update();

                foreach (Pickup points in rings)
                {
                    if (points.active && CheckCollisionCircles(myPlayer.position, myPlayer.radius, points.position, points.radius))
                    {
                        points.active = false;
                        score += 10;
                    }
                }

                BeginDrawing();

                ClearBackground(RAYWHITE);
               
                foreach (Pickup points in rings)
                {
                    points.Draw();
                    
                }
                myPlayer.Draw();

                int time = (int)GetTime();

                Vector2 mPosition = GetMousePosition();

                DrawText($"Score: {score} ", 20, 20, 20, MAROON);
                DrawText($"Time elapsed: {time}", 20, 40, 20, MAROON);
                if (time == 10)
                {
                    DrawText($"GAME OVER", 100, 150, 75, RED);
                    gameRunning = false;
                }
                if(score == 100)
                {
                    DrawText($"GAME OVER", 100, 150, 75, RED);
                    
                    gameRunning = false;
                }

                EndDrawing();
                //----------------------------------------------------------------------------------
            }

            // De-Initialization
            //--------------------------------------------------------------------------------------
            CloseWindow();        // Close window and OpenGL context
            //--------------------------------------------------------------------------------------

            return 0;
        }
    }
}