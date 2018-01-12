using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramLogicUtilits.Bombuzle
{
    public class Game
    {
        private Random rnd = new Random();

        private GameState state = GameState.NOT_STARTED;

        private Cell[,] field = null;

        private int fieldWidth = 0;
        private int fieldHeight = 0;

        private int scores = 0;

        public Game() {

        }

        public void NewGame(int fieldWidth, int fieldHeight)
        {
            this.scores = 0;
            this.fieldWidth = fieldWidth;
            this.fieldHeight = fieldHeight;

            this.field = new Cell[fieldHeight, fieldWidth];

            GenerateField(fieldWidth, fieldHeight);
            state = GameState.PLAYING;
        }

        private void GenerateField(int fieldWidth, int fieldHeight)
        {
            for (int r = 0; r < fieldHeight; r++)
                for (int c = 0; c < fieldWidth; c++)
                    GenerateCell(r, c);
        }

        private void GenerateCell(int row, int column)
        {
            const int maxCellTypes = 4;

            CellState state;

            int probability = rnd.Next(101);

            if (probability < 3)
                state = CellState.Bomb;
            else
                state = (CellState)rnd.Next(maxCellTypes);

            field[row, column] = new Cell { State = state, Marked = false };
        }

        public void SiftDown(int row, int column)
        {
            if (row == fieldHeight - 1)
                return;

            int newRow = row + 1;

            while (newRow < fieldHeight - 1 && field[newRow + 1, column] == null)
            {
                newRow++;
            }

            field[newRow, column] = field[row, column];
            field[row, column] = null;
        }

        public void SelectCell(int row, int column)
        {
            if (field[row, column].Marked)
            {
                DestroyCell(row, column);
                return;
            }

            ClearSelection();

            if (field[row, column].State == CellState.Bomb)
            {
                SelectBombCell(row, column);
            }
            else
            {
                int selectedCells = SelectCellRecursive(row, column);

                if (selectedCells < 3)
                    ClearSelection();
            }
        }

        private void DestroyCell(int row, int column)
        {
            // Удаляем выделенные ячейки
            for (int r = 0; r < fieldHeight; r++)
                for (int c = 0; c < fieldWidth; c++)
                    if (field[r, c].Marked)
                    {
                        if (field[r, c].State == CellState.Bomb)
                            scores += 10;
                        else
                            scores++;

                        field[r, c] = null;
                    }

            // Просеиваем ячейки вниз
            for (int c = 0; c < fieldWidth; c++)
                for (int r = fieldHeight - 2; r >= 0; r--)
                    if (field[r, c] != null && field[r + 1, c] == null)
                        SiftDown(r, c);

            // Заполняем недостающие ячейки
            for (int r = 0; r < fieldHeight; r++)
                for (int c = 0; c < fieldWidth; c++)
                    if (field[r, c] == null)
                        GenerateCell(r, c);
        }

        private void SelectBombCell(int row, int column)
        {
            for (int r = row - 1; r <= row + 1; r++)
                for (int c = column - 1; c <= column + 1; c++)
                    if (IsCellIndexesCorrect(r, c))
                        field[r, c].Marked = true;

            if (IsCellIndexesCorrect(row - 2, column))
                field[row - 2, column].Marked = true;

            if (IsCellIndexesCorrect(row + 2, column))
                field[row + 2, column].Marked = true;

            if (IsCellIndexesCorrect(row, column - 2))
                field[row, column - 2].Marked = true;

            if (IsCellIndexesCorrect(row, column + 2))
                field[row, column + 2].Marked = true;
        }

        private int SelectCellRecursive(int row, int column)
        {
            if (field[row, column].Marked)
                return 0;

            field[row, column].Marked = true;

            int count = 1;

            if (IsStateEquals(row - 1, column, field[row, column].State))
                count += SelectCellRecursive(row-1, column);

            if (IsStateEquals(row + 1, column, field[row, column].State))
                count += SelectCellRecursive(row + 1, column);

            if (IsStateEquals(row, column - 1, field[row, column].State))
                count += SelectCellRecursive(row, column - 1);

            if (IsStateEquals(row, column + 1, field[row, column].State))
                count += SelectCellRecursive(row, column + 1);

            return count;
        }
        
        private bool IsStateEquals(int row, int column, CellState state)
        {
            if (!IsCellIndexesCorrect(row, column))
                return false;

            return field[row, column].State == state;
        }

        private bool IsCellIndexesCorrect(int row, int column)
        {
            return row >= 0 && row < fieldHeight && column >= 0 && column < fieldWidth;
        }

        private void ClearSelection()
        {
            for (int r = 0; r < fieldHeight; r++)
                for (int c = 0; c < fieldWidth; c++)
                    field[r, c].Marked = false;
        }

        public int FieldWidth
        {
            get
            {
                return fieldWidth;
            }
        }

        public int FieldHeight
        {
            get
            {
                return fieldHeight;
            }
        }

        public GameState State
        {
            get
            {
                return state;
            }
        }

        public Cell this[int row, int col]
        {
            get
            {
                return field[row, col];
            }
        }

        // Игровая статистика
        public int Scores
        {
            get
            {
                return scores;
            }
        }
    }
}
