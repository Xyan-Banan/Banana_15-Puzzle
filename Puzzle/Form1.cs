using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle
{
    public partial class Form1 : Form
    {
        PictureBox[] frames;
        Image[] original;
        Image[] parts;
        int blackIndex;
        int moves;
        int estimatedTime;

        public Form1()
        {
            InitializeComponent();
            initGame();
            gameTimer.Interval = 1000;
        }

        void initGame()
        {
            frames = new PictureBox[] { frame1, frame2, frame3, frame4, frame5, frame6, frame7, frame8, frame9 };
            original = new Image[]
            {
                Properties.Resources.image_part_001,
                Properties.Resources.image_part_002,
                Properties.Resources.image_part_003,
                Properties.Resources.image_part_004,
                Properties.Resources.image_part_005,
                Properties.Resources.image_part_006,
                Properties.Resources.image_part_007,
                Properties.Resources.image_part_008,
                Properties.Resources.black_square
            };
            parts = new Image[9];
            original.CopyTo(parts, 0);
            moves = 0;
            estimatedTime = 60;
            blackIndex = 0;
            shuffle();
            show();
        }

        void shuffle()
        {
            List<int> freeIndexes = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            Random random = new Random();

            for(int i = 0; i < parts.Length; i++)
            {
                int usedIndex = freeIndexes[random.Next(freeIndexes.Count)];
                parts[i] = original[usedIndex];
                freeIndexes.Remove(usedIndex);
                if (usedIndex == 8) blackIndex = i;
            }
            gameTimer.Stop();
            moves = 0;
            movesLbl.Text = $"Moves made: {moves}";
            estimatedTime = 60;
            timeLbl.Text = "01:00";
        }

        void show()
        {
            for (int i = 0; i < frames.Length; i++)
                frames[i].Image = parts[i];
        }


        private void shuffleBtn_Click(object sender, EventArgs e)
        {
            shuffle();
            show();
        }
        private void QuitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            estimatedTime--;
            int seconds = estimatedTime % 60;
            int minutes = estimatedTime / 60;
            timeLbl.Text = $"0{minutes}:";
            timeLbl.Text += (seconds < 10) ? ("0" + seconds) : (seconds.ToString());
            if (estimatedTime == 0) gameOver(isWin: false);
        }

        private void gameOver(bool isWin)
        {
            gameTimer.Stop();
            MessageBox.Show(isWin ? "You win! 🥳" : "You lose! 😟");
        }

        void swap(int i, int j)
        {
            Image tmp = parts[i];
            parts[i] = parts[j];
            parts[j] = tmp;
        }

        private void frame1_Click(object sender, EventArgs e)
        {
            if (blackIndex != 1 || blackIndex != 3) return;

            if (blackIndex == 0) return;

            //если таймер выключен - то включить (запустить)

            //поменять местами элемент на позиции blackIndex и текущий (0)
            //отобразить изменения на экране
            //указать, что теперь blackIndex находится на позиции 0
            //увеличить количество сделанных ходов
            //отобразить количество ходов


        }

    }
}
