using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
                        BackColor = Color.Azure,

                    });
                    but[but.Count - 1].Click += ButtonClick;
                    Controls.Add(but[but.Count-1]);
                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;
            string name = objTextBox.Text;
            label2.Text = name;
        }



        private void ButtonClick(object sender, EventArgs e)
        {
            var CurrentButton = sender as Button;
            CurrentButton.Text = tictac;
            CurrentButton.Click -= ButtonClick;
            string name = "Timoner_15";
            label2.Text = name;
            if (CheckWin())
            {
                MessageBox.Show("'" + tictac + "'" + " won the game");
                string result = "Win";
                Stat game = new Stat(name, result);
                foreach (Button item in but)
                {
                    item.Click -= ButtonClick;
                }
            }
            else if (AreBtnsFull() && !CheckWin())
            {
                MessageBox.Show("It is a DRAW");
                string result = "Draw";
                Stat game = new Stat(name, result);
                foreach (Button item in but)
                {
                    item.Click -= ButtonClick;
                }
            }
            tictac = tictac == "X" ? "O" : "X";
        }


        private void GetStats(DataGridView gridView, List<Stat> Results)
        {
            gridView.Rows.Clear();

            gridView.ColumnCount = 4;
            gridView.Columns[0].Name = "Index";
            gridView.Columns[1].Name = "Username";
            gridView.Columns[2].Name = "Game Result";
            gridView.Columns[3].Name = "Date";

            int i = 0;

            foreach (Stat game in Results)
            {
                gridView.Rows.Add(i++, game.UserName, game.GameResult, DateTime.Now);
            }

            /*DataGridViewCell Num1 = new DataGridViewTextBoxCell();
                DataGridViewCell User1 = new DataGridViewTextBoxCell();
                DataGridViewCell Game1 = new DataGridViewTextBoxCell();
                DataGridViewCell Dat1 = new DataGridViewTextBoxCell();

                Num1.Value = index++;
                User1.Value = name;
                Game1.Value = result;
                Dat1.Value = DateTime.Now;

                foreach (Game item in Games)
                {
                    DataGridViewRow row1 = new DataGridViewRow();
                    row1.Cells.AddRange(Num1, User1, Game1, Dat1);
                    table.Rows.AddRange(row1);
                }*/
        }


        void Init()
        {
            ClientSize = new Size(1200, 600);
            ButtonsInit();
            GenerateTicTac();
            List<Stat> Results = new List<Stat>();
            GetStats(table, Results);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Button item in but)
            {
                item.Text = "";
                item.Click += ButtonClick;
                tictac = "X";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
    class Stat
    {
        public string UserName { get; set; }
        public string GameResult { get; set; }
        public DateTime Date { get; set; }
        public List<Stat> Results { get; set; }

        public Stat(string name, string result)
        {
            UserName = name;
            GameResult = result;
            Date = DateTime.Now;
            Results = new List<Stat>();
        }
    }
}