using System.Runtime.InteropServices;

namespace Task7_2;
public partial class Clock : Form
{
    [DllImport("user32", CharSet = CharSet.Auto)]
    internal extern static bool PostMessage(IntPtr hWnd, uint Msg, uint WParam, uint LParam);

    [DllImport("user32", CharSet = CharSet.Auto)]
    internal extern static bool ReleaseCapture();

    /// <summary>
    /// ���������� ������ ����������
    /// </summary>
    private (int x, int y) center = (175, 175);

    /// <summary>
    /// ����� �������� �������
    /// </summary>
    private int secondHandLength = 100;

    /// <summary>
    /// ����� �������� �������
    /// </summary>
    private int minuteHandLength = 90;

    /// <summary>
    /// ����� ������� �������
    /// </summary>
    private int hourHandLength = 75;
    System.Windows.Forms.Timer clock = new System.Windows.Forms.Timer();
    public Clock()
    {
        InitializeComponent();
        this.BackColor = Color.AliceBlue;
        this.TransparencyKey = this.BackColor;
    }

    private void PictureMouseDown(object sender, MouseEventArgs e)
    {
        const uint WM_SYSCOMMAND = 0x0112;
        const uint DOMOVE = 0xF012;
        ReleaseCapture();
        PostMessage(this.Handle, WM_SYSCOMMAND, DOMOVE, 0);
    }

    private void ClockLoad(object sender, EventArgs e)
    {
        clock.Interval = 1000;
        clock.Tick += new EventHandler(this.ClockTick!);
        clock.Start();
    }

    /// <summary>
    /// ���������� ���������� ����� ��������� ��� 
    /// �������� �������
    /// </summary>
    /// <param name="count">���������� ������ ��� ����� </param>
    /// <param name="handLength">����� ��������� ��� �������� �������</param>

    private (int, int) MinuteOrSecondCoordinates(int count, int handLength)
    {
        (int, int) coordinates = (0, 0);
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

    /// <summary>
    /// ���������� ���������� ����� ������� �������
    /// </summary>
    /// <param name="hourCount">���������� �����</param>
    /// <param name="minuteCount">���������� �����</param>
    /// <param name="handLength">����� ������� �������</param>
    private (int, int) HourCoordinates(int hourCount, int minuteCount, int handLength)
    {
        (int, int) coordinates = (0, 0);
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

    /// <summary>
    /// ������ ������� ����� ������ �������
    /// </summary>
    private void ClockTick(object sender, EventArgs e)
    {   
        int seconds = DateTime.Now.Second;
        int minutes = DateTime.Now.Minute;
        int hours = DateTime.Now.Hour;
        (int, int) handCoordinates = (0, 0);
        Graphics graphics = picture.CreateGraphics(); 

        // ������� ���������� ��������� ��������� �������
        handCoordinates = MinuteOrSecondCoordinates(seconds, secondHandLength + 4);
        graphics.DrawLine(new Pen(Color.White, 45f), new Point(center.x, center.y), new Point(handCoordinates.Item1, handCoordinates.Item2));

        // ������� ���������� ��������� �������� �������
        handCoordinates = MinuteOrSecondCoordinates(minutes, minuteHandLength + 4);
        graphics.DrawLine(new Pen(Color.White, 40f), new Point(center.x, center.y), new Point(handCoordinates.Item1, handCoordinates.Item2));

        // ������� ���������� ��������� ������� �������
        handCoordinates = HourCoordinates(hours % 12, minutes, hourHandLength + 4);
        graphics.DrawLine(new Pen(Color.White, 20f), new Point(center.x, center.y), new Point(handCoordinates.Item1, handCoordinates.Item2));


        //��������� ������� �����
        handCoordinates = HourCoordinates(hours % 12, minutes, hourHandLength);
        graphics.DrawLine(new Pen(Color.Gray, 4f), new Point(center.x, center.y), new Point(handCoordinates.Item1, handCoordinates.Item2));


        //��������� �������� �������
        handCoordinates = MinuteOrSecondCoordinates(minutes, minuteHandLength);
        graphics.DrawLine(new Pen(Color.Black, 2f), new Point(center.x, center.y), new Point(handCoordinates.Item1, handCoordinates.Item2));

        // ��������� ��������� �������
        handCoordinates = MinuteOrSecondCoordinates(seconds, secondHandLength);
        graphics.DrawLine(new Pen(Color.DarkOrange, 2f), new Point(center.x, center.y), new Point(handCoordinates.Item1, handCoordinates.Item2));
    }
}