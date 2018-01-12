using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormsUtils;
using ProgramLogicUtilits.Bombuzle;

namespace Bombuzle
{
    public partial class MainForm : Form
    {
        private static int FIELD_WIDTH = 9;
        private static int FIELD_HEIGHT = 11;

        private Game game = new Game();

        private Dictionary<CellState, Brush> colorsMap = new Dictionary<CellState, Brush>() {
            { CellState.Red, Brushes.Red },
            { CellState.Blue, Brushes.Blue },
            { CellState.Green, Brushes.Green },
            { CellState.Yellow, Brushes.Yellow },
            { CellState.Bomb, Brushes.Black },
        };

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            int cellSize = this.Width / FIELD_WIDTH;

            this.Width = cellSize * FIELD_WIDTH + 40;
            this.Height = gameFieldDataGridView.Location.Y + cellSize * FIELD_HEIGHT + 45;

            // настраиваем DataGridView
            gameFieldDataGridView.RowTemplate.Height = cellSize;
            gameFieldDataGridView.Font = new Font("Comic Sans MS", 12);
            DataGridViewUtils.InitGridForArr(gameFieldDataGridView, cellSize, true, false, false, false, false);

            gameFieldDataGridView.Width = cellSize * FIELD_WIDTH + 3;
            gameFieldDataGridView.Height = cellSize * FIELD_HEIGHT + 3;
            gameFieldDataGridView.RowCount = FIELD_HEIGHT;
            gameFieldDataGridView.ColumnCount = FIELD_WIDTH;
        }

        private void UpdateView()
        {
            switch (game.State) {
                case GameState.PLAYING:
                    gameStateLabel.Text = "Игра идет ";
                    gameStateLabel.ForeColor = Color.Black;
                    break;
            }

            scoresLabel.Text = game.Scores.ToString();

            gameFieldDataGridView.Invalidate();
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            game.NewGame(FIELD_WIDTH, FIELD_HEIGHT);
            UpdateView();
        }

        private void gameFieldDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (game.State != GameState.PLAYING)
            {
                e.CellStyle.BackColor = Color.White;
                e.PaintBackground(e.CellBounds, false);

                e.Handled = true;
                return;
            }


            Cell cell = game[e.RowIndex, e.ColumnIndex];

            // отрисовка фона
            if (game[e.RowIndex, e.ColumnIndex].Marked)
            {
                e.CellStyle.BackColor = Color.LightGray; 
            }
            else
            {
                e.CellStyle.BackColor = Color.White;
            }

            e.PaintBackground(e.CellBounds, false);

            int x = e.CellBounds.Location.X + 5;
            int y = e.CellBounds.Location.Y + 10;
            int radius = 50;

            e.Graphics.FillEllipse(colorsMap[cell.State], e.CellBounds.X + 5, e.CellBounds.Y + 5, e.CellBounds.Width - 10, e.CellBounds.Height - 10);

            // сообщаем, что ячейка полностью отрисована
            e.Handled = true;
        }

        private void gameFieldDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (game.State != GameState.PLAYING)
                return;

            game.SelectCell(e.RowIndex, e.ColumnIndex);
            UpdateView();
        }
    }
}
