using Raylib_cs;

Raylib.InitWindow(800, 600, "Whatever we wanted it or not...");
Raylib.SetTargetFPS(60);

Color aquamarine = new Color(127, 255, 231, 255);
Color clear = new Color(255, 255, 255, 0);

Texture2D avatar = Raylib.LoadTexture("test avatar.png");
Texture2D background = Raylib.LoadTexture("8bit grass.png");
Texture2D endScreen = Raylib.LoadTexture("blue screen.png");

Rectangle playerRect = new Rectangle(0, 0, avatar.width, avatar.height);
Rectangle trapRect = new Rectangle(700, 500, 64, 64);

float speed = 5;

string currentScene = "start"; // start, game, end

while (Raylib.WindowShouldClose() == false)
{
    //Graphics

    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.WHITE);
    if (currentScene == "game")
    {
        Raylib.DrawTexture(background, 0, 0, Color.WHITE);
        Raylib.DrawRectangleRec(playerRect, clear);
        Raylib.DrawTexture(avatar, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
        Raylib.DrawRectangleRec(trapRect, Color.BLACK);
         //casting: används för bla göra float till int

    }
    else if (currentScene == "start")
    {
        Raylib.DrawText("Press ENTER to start", 250, 250, 24, Color.BLACK);
    }
    else if (currentScene == "end")
    {
        Raylib.DrawTexture(endScreen, 0, 0, Color.WHITE);
    }
    //Raylib.DrawRectangle(0, 0, 32, 32, aquamarine);
    Raylib.EndDrawing();
    //Logic

    if (currentScene == "game")
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
        {
            playerRect.x += speed;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
        {
            playerRect.x -= speed;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
        {
            playerRect.y -= speed;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
        {
            playerRect.y += speed;
        }

        if(Raylib.CheckCollisionRecs(playerRect, trapRect))
        {
            currentScene = "end";
        }
    }
    else if (currentScene == "start")
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_ENTER))
        {
            currentScene = "game";
        }


    }
    else if (currentScene == "end")
    {

    }




}

