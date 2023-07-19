namespace Yılan_BP_2021512001_MTA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Panel parca;
        Panel elma = new Panel();
        List<Panel> yilan = new List<Panel>();

        string yon = "sağ";
        private void label1_Click(object sender, EventArgs e)
        {
            paneliTemizle();

            parca = new Panel();
            parca.Location = new Point(200, 200);
            parca.Size = new Size(20, 20);
            parca.BackColor = Color.Gray;
            yilan.Add(parca);
            panel1.Controls.Add(yilan[0]);

            timer1.Start();
            elmaOlustur();
        }

        void gameover()
        {
            for (int i = 2; i < yilan.Count; i++)
            {
                if (yilan[0].Location == yilan[i].Location)
                {
                    label2.Visible = true;
                    label2.Text = "KAYBETTİNİZ";
                    timer1.Stop();
                }
            }
        }
        void paneliTemizle()
        {
            panel1.Controls.Clear();
            yilan.Clear();
            label1.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int locX = yilan[0].Location.X;
            int locY = yilan[0].Location.Y;

            yenielma();
            hareket();
            gameover();

            if (yon == "sağ")
            {
                if (locX < 580)
                    locX += 20;
                else
                    locX = 0;
            }
            if (yon == "sol")
            {
                if (locX > 0)
                    locX -= 20;
                else
                    locX = 580;
            }
            if (yon == "aşağı")
            {
                if (locY < 580)
                    locY += 20;
                else
                    locY = 0;
            }
            if (yon == "yukarı")
            {
                if (locY > 0)
                    locY -= 20;
                else
                    locY = 580;
            }

            yilan[0].Location = new Point(locX, locY);
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right && yon != "sol")
                yon = "sağ";
            if (e.KeyCode == Keys.Left && yon != "sağ")
                yon = "sol";
            if (e.KeyCode == Keys.Up && yon != "aşağı")
                yon = "yukarı";
            if (e.KeyCode == Keys.Down && yon != "yukarı")
                yon = "aşağı";
        }

        void elmaOlustur()
        {
            Random rast = new Random();
            int elmaX, elmaY;
            elmaX = rast.Next(580);
            elmaY = rast.Next(580);

            elmaX -= elmaX % 20;
            elmaY -= elmaY % 20;

            elma.Size = new Size(20, 20);
            elma.BackColor = Color.Red;
            elma.Location = new Point(elmaX, elmaY);
            panel1.Controls.Add(elma);
        }
        
        void yenielma()
        {
            if (yilan[0].Location == elma.Location)
            {
                panel1.Controls.Remove(elma);
                elmaOlustur();
                kuyruk();
            }
        }
        
        void kuyruk()
        {
            Panel ekParca = new Panel();
            ekParca.Size = new Size(20, 20);
            ekParca.BackColor = Color.Gray;
            yilan.Add(ekParca);
            panel1.Controls.Add(ekParca);
        }

        void hareket()
        {
            for (int i = yilan.Count - 1; i > 0; i--)
                yilan[i].Location = yilan[i - 1].Location;
        }
    }
}