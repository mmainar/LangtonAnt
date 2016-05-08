using System;

namespace LangtonAnt
{
    public class LangtonAnt
    {
        // Infinite grid, so we need these
        int maxRow, maxCol, minRow, minCol;

        public int CurrentRow { get; private set; }
        public int CurrentCol { get; private set; }

        public Square CurrentSquare { get; private set; }

        public Direction Direction { get; private set; }

        public LangtonAnt()
        {
            Direction = Direction.RIGHT;
            CurrentCol = CurrentRow = 0;
            CurrentSquare = new Square(CurrentCol, CurrentRow);
        }

        public LangtonAnt(Direction direction, Square sq)
        {
            Direction = direction;
            CurrentSquare = sq;
            CurrentCol = sq.Column;
            CurrentRow = sq.Row;
        }

        public void Move()
        {
            if (CurrentSquare.Color == Color.WHITE)
            {
                CurrentSquare.FlipColor();
                // Turn 90 degress right (clockwise)
                Direction = Direction.TurnClockwise();
            }
            else
            {
                CurrentSquare.FlipColor();
                // Turn 90 degress left (counter-clockwise)
                Direction = Direction.TurnAntiClockwise();
            }

            MoveForward();
        }

        private void MoveForward()
        {
            switch (Direction)
            {
                case Direction.BOTTOM :
                    CurrentRow++;
                    break;
                case Direction.TOP:
                    CurrentRow--;
                    break;
                case Direction.RIGHT:
                    CurrentCol++;
                    break;
                case Direction.LEFT:
                    CurrentCol--;
                    break;
                default: break;
            }
        }

        public void PrintKMoves(int k)
        {
            int totalMoves = k;
            while (totalMoves > 0)
            {
                Move();
                PrintBoard();
                totalMoves--;
            }
        }

        public void PrintBoard()
        {
            // TODO: Print squares and position of the Ant
        }
    }

    public class Square
    {
        public int Column { get; private set; }
        public int Row { get; private set; }

        public Color Color { get; private set; }

        public Square(int col, int row, Color color)
        {
            this.Column = col;
            this.Row = row;
            this.Color = color;
        }

        public Square(int col, int row)
        {
            this.Column = col;
            this.Row = row;
            this.Color = ComputeColor();
        }

        public void FlipColor()
        {
            if (Color == Color.WHITE)
            {
                Color = Color.BLACK;
            }
            else
            {
                Color = Color.WHITE;
            }
        }

        private Color ComputeColor()
        {
            if (Row + Column % 2 == 0)
            {
                return Color.BLACK;
            }
            else
            {
                return Color.WHITE;
            }
        }
    }

    static class DirectionExtensions
    {
        public static Direction TurnClockwise(this Direction direction)
        {
            switch (direction)
            {
                case Direction.BOTTOM:
                    return Direction.LEFT;
                case Direction.TOP:
                    return Direction.RIGHT;
                case Direction.RIGHT:
                    return Direction.BOTTOM;
                case Direction.LEFT:
                    return Direction.TOP;
                default:
                    return Direction.LEFT;
            }
        }

        public static Direction TurnAntiClockwise(this Direction direction)
        {
            switch (direction)
            {
                case Direction.BOTTOM:
                    return Direction.RIGHT;
                case Direction.TOP:
                    return Direction.LEFT;
                case Direction.RIGHT:
                    return Direction.TOP;
                case Direction.LEFT:
                    return Direction.BOTTOM;
                default:
                    return Direction.LEFT;
            }
        }
    }

    public enum Direction
    {
        TOP = 0,
        RIGHT = 1,
        LEFT = 2,
        BOTTOM = 3,
    }

    public enum Color
    {
        WHITE, BLACK
    }
}
