using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class GameScreen
{
    public Rectangle GripZone { get; private set; }
    public Rectangle StackZone { get; private set; }
    public Rectangle HeapZone { get; private set; }

    public Rectangle RunnerZone { get; private set; }
    public Rectangle CorpZone { get; private set; }
    
    public Rectangle HQZone { get; private set; }
    public Rectangle RnDZone { get; private set; }
    public Rectangle ArchivesZone { get; private set; }
    
    public Rectangle ScoreZone { get; private set; }
    public Rectangle CreditZone { get; private set; }
    public Rectangle RunnerClickZone { get; private set; }
    public Rectangle CorpClickZone { get; private set; }
    public Rectangle RunnerActionZone { get; private set; }
    public Rectangle CorpActionZone { get; private set; }

    public Rectangle HardWareZone { get; private set; }
    public Rectangle ProgramZone { get; private set; }
    public Rectangle ResourceZone { get; private set; }
    
    public Rectangle RemoteServerZone { get; private set; }
    public Rectangle IceZone { get; private set; }

    public Color CorpColor { get; private set; }
    public Color RunnerColor { get; private set; }

    public GameScreen()
    {
        RunnerZone = new Rectangle(0, 0, 800, 200);
        CorpZone = new Rectangle(0, 400, 800, 200);

        //create the grip in the middle of the runner zone
        GripZone = new Rectangle(300, 0, 200, 200);

        //create the stack and heap to the left of the grip
        StackZone = new Rectangle(0, 0, 100, 200);
        HeapZone = new Rectangle(500, 0, 100, 200);

        //create the corp zones
        HQZone = new Rectangle(0, 400, 200, 200);
        RnDZone = new Rectangle(200, 400, 200, 200);
        ArchivesZone = new Rectangle(400, 400, 200, 200);

        
        ScoreZone = new Rectangle(200, 200, 100, 100);
        CreditZone = new Rectangle(300, 200, 100, 100);
        RunnerClickZone = new Rectangle(400, 200, 100, 100);
        CorpClickZone = new Rectangle(500, 200, 100, 100);
        RunnerActionZone = new Rectangle(600, 200, 100, 100);
        HardWareZone = new Rectangle(0, 300, 100, 100);
        ProgramZone = new Rectangle(100, 300, 100, 100);
        ResourceZone = new Rectangle(200, 300, 100, 100);
        RemoteServerZone = new Rectangle(300, 300, 100, 100);
        IceZone = new Rectangle(400, 300, 100, 100);

        CorpColor = Color.Blue;
        RunnerColor = Color.Red;
        
    }

    private Rectangle CreateZone(int x, int y, int width, int height)
    {
        return new Rectangle(x, y, width, height);
    }

}
