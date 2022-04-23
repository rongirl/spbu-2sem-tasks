using System.Runtime.InteropServices;

namespace Task7._2;
public partial class Clock : Form
{
    [DllImport("user32", CharSet = CharSet.Auto)]
    internal extern static bool PostMessage(IntPtr hWnd, uint Msg, uint WParam, uint LParam);

    [DllImport("user32", CharSet = CharSet.Auto)]
    internal extern static bool ReleaseCapture();

    private (int x, int y) center = (175, 175);
    private int secondHand = 100;
    private int minuteHand = 90;
    private int hourHand = 75;
    System.Windows.Forms.Timer clock = new System.Windows.Forms.Timer();
    public Clock()
    {
        InitializeComponent();
        this.BackColor = Color.AliceBlue;
        this.TransparencyKey = this.BackColor;
    }

    private void picture_MouseDown(object sender, MouseEventArgs e)
    {
        const uint WM_SYSCOMMAND = 0x0112;
        const uint DOMOVE = 0xF012;
        ReleaseCapture();
        PostMessage(this.Handle, WM_SYSCOMMAND, DOMOVE, 0);
    }

    private void Clock_Load(object sender, EventArgs e)
    {
        clock.Interval = 1000;
        clock.Tick += new EventHandler(this.clock_Tick);
        clock.Start();
    }

    private (int, int) minuteSecondCoordinates(int count, int handLength)
    {
        (int, int) coordinates;
        count *= 6;
        if (count >= 0 && count <= 180)
        {
            coordinates.Item1 = center.x + (int)(handLength * Math.Sin(Math.PI * count / 180));
            coordinates.Item2 = center.y - (int)(handLength * Math.Cos(Math.PI * count / 180));
        }
        else
        {
            coordinates.Item1 = center.x - (int)(handLength * -Math.Sin(Math.PI * count / 180));
            coordinates.Item2 = center.y - (int)(handLength * Math.Cos(Math.PI * count / 180));
        }
        return coordinates;
    }

    private (int, int) hourCoordinates(int hourCount, int minuteCount, int handLength)
    {
        (int, int) coordinates;
        int count = (int)((hourCount * 30) + (minuteCount * 0.5));
        if (count >= 0 && count <= 180)
        {
            coordinates.Item1 = center.x + (int)(handLength * Math.Sin(Math.PI * count / 180));
            coordinates.Item2 = center.y - (int)(handLength * Math.Cos(Math.PI * count / 180));
        }
        else
        {
            coordinates.Item1 = center.x - (int)(handLength * -Math.Sin(Math.PI * count / 180));
            coordinates.Item2 = center.y - (int)(handLength * Math.Cos(Math.PI * count / 180));
        }
        return coordinates;
    }

    private void clock_Tick(object sender, EventArgs e)
    {
        int seconds = DateTime.Now.Second;
        int minutes = DateTime.Now.Minute;
        int hours = DateTime.Now.Hour;

        (int, int) handCoordinates;

        Graphics graphics = picture.CreateGraphics(); 

        // Стираем предыдущее положения секундной стрелки
        handCoordinates = minuteSecondCoordinates(seconds, secondHand + 4);
        graphics.DrawLine(new Pen(Color.White, 45f), new Point(center.x, center.y), new Point(handCoordinates.Item1, handCoordinates.Item2));

        // Стираем предыдущее положение минутной стрелки
        handCoordinates = minuteSecondCoordinates(minutes, minuteHand + 4);
        graphics.DrawLine(new Pen(Color.White, 40f), new Point(center.x, center.y), new Point(handCoordinates.Item1, handCoordinates.Item2));

        // Стираем предыдущее положение часовой стрелки
        handCoordinates = hourCoordinates(hours % 12, minutes, hourHand + 4);
        graphics.DrawLine(new Pen(Color.White, 20f), new Point(center.x, center.y), new Point(handCoordinates.Item1, handCoordinates.Item2));


        //Отрисовка стрелки часов.
        handCoordinates = hourCoordinates(hours % 12, minutes, hourHand);
        graphics.DrawLine(new Pen(Color.Gray, 4f), new Point(center.x, center.y), new Point(handCoordinates.Item1, handCoordinates.Item2));


        //Отрисовка минутной стрелки
        handCoordinates = minuteSecondCoordinates(minutes, minuteHand);
        graphics.DrawLine(new Pen(Color.Black, 2f), new Point(center.x, center.y), new Point(handCoordinates.Item1, handCoordinates.Item2));

        // Отрисовка секундной стрелки.
        handCoordinates = minuteSecondCoordinates(seconds, secondHand);
        graphics.DrawLine(new Pen(Color.DarkOrange, 2f), new Point(center.x, center.y), new Point(handCoordinates.Item1, handCoordinates.Item2));
    }
}

