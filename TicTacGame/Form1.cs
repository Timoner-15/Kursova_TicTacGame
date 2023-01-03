namespace TicTacGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Init();
        }

        List<Button> but = new List<Button>();
        string tictac;
        int butdraw = 0;

        bool CheckWin()
        {
            for (int i = 0; i < 9; i += 3)
            {
                if (but[i].Text == but[i + 1].Text && but[i].Text == but[i + 2].Text && but[i].Text != "")
                {
                    return true;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (but[i].Text == but[i + 3].Text && but[i].Text == but[i + 6].Text && but[i].Text != "")
                {
                    return true;
                }
            }
            if (but[0].Text == but[4].Text && but[4].Text == but[8].Text && but[4].Text != "")
            {
                return true;
            }
            if (but[2].Text == but[4].Text && but[4].Text == but[6].Text && but[4].Text != "")
            {
                return true;
            }
            return false;
        }

        private bool AreBtnsFull()
        {
            
            foreach(var item in but)
            {
                if (item.Text == "") return false;
            }
            return true;
        }

            void GenerateTicTac()
        {
            var r = new Random();
            tictac = r.Next(0, 2) == 0 ? "X" : "O";
        }

        void ButtonsInit()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    but.Add(new Button
                    {
                        Size = new Size(200, 200),
                        Location = new Point(i*200, j*200),
                        TabStop = false,
                        Font = new Font("Arial" , 80),

                    });
                    but[but.Count - 1].Click += ButtonClick;
                    Controls.Add(but[but.Count-1]);
                }
            }

        }

        private void ButtonClick(object sender, EventArgs e)
        {
            var CurrentButton = sender as Button;
            CurrentButton.Text = tictac;
            CurrentButton.Click -= ButtonClick;
            if (CheckWin())
            {
                MessageBox.Show("'" + tictac + "'" + " won the game");
                foreach (Button item in but)
                {
                    item.Click -= ButtonClick;
                }
            }
            else if (AreBtnsFull() && !CheckWin())
            {
                MessageBox.Show("It is a DRAW");
                foreach (Button item in but)
                {
                    item.Click -= ButtonClick;
                }
            }
            tictac = tictac == "X" ? "O" : "X";
        }


        void Init()
        {
            ClientSize = new Size(600, 600);
            ButtonsInit();
            GenerateTicTac();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}