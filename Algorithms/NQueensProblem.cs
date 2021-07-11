using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgo.Algorithms
{
    //https://www.youtube.com/watch?v=xouin83ebxE&ab_channel=TusharRoy-CodingMadeSimple
    //https://github.com/mission-peace/interview/blob/master/src/com/interview/recursion/NQueenProblem.java
    public class Position
    {
        public int row;
        public int column;
        public Position(int row, int column)
        {
            this.row = row;
            this.column = column;
        }
    }
    public class NQueensProblem
    {
        public void main()
        {
            Position[] positions = SolveNQueen(4);
            foreach (var pos in positions)
            {
                Console.WriteLine(pos.row + "," + pos.column);
            }

            Console.WriteLine("=======SolveNQueenAllSolutions=====");
            List<List<Position>> allPositions = SolveNQueenAllSolutions(4);
            foreach (var item in allPositions)
            {
                foreach (var pos in item)
                {
                    Console.WriteLine(pos.row + "," + pos.column);
                }
                Console.WriteLine("------------");
            }
        }

        public Position[] SolveNQueen(int n)
        {
            Position[] positions = new Position[n];

            if (SolveNQueenUtil(positions, 4, 0))
            {
                return positions;
            }

            return null;
        }

        public bool SolveNQueenUtil(Position[] positions, int n, int row)
        {
            if (row == n)
            {
                return true;
            }

            for (int col = 0; col < n; col++)
            {
                bool isSafe = true;
                for (int queen = 0; queen < row; queen++)
                {
                    if (positions[queen].column == col
                       || positions[queen].row == row
                       || positions[queen].row + positions[queen].column == row + col
                       || positions[queen].row - positions[queen].column == row - col)
                    {
                        isSafe = false;
                        break;
                    }
                }
                if (isSafe)
                {
                    positions[row] = new Position(row, col);
                    if (SolveNQueenUtil(positions, n, row + 1))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public List<List<Position>> SolveNQueenAllSolutions(int n)
        {
            List<List<Position>> results = new List<List<Position>>();
            Position[] positions = new Position[n];
            SolveNQueenUtilAllSolutions(results, positions, n, 0);
            return results;
        }

        public void SolveNQueenUtilAllSolutions(List<List<Position>> results, Position[] positions, int n, int row)
        {
            if (row == n)
            {
                List<Position> currentResult = new List<Position>();
                foreach (var position in positions)
                {
                    currentResult.Add(position);
                }
                results.Add(currentResult);
                return;
            }
            for (int col = 0; col < n; col++)
            {
                bool isSafe = true;
                for (int queen = 0; queen < row; queen++)
                {
                    if (positions[queen].row == row || positions[queen].column == col ||
                        positions[queen].row + positions[queen].column == row + col ||
                        positions[queen].row - positions[queen].column == row - col)
                    {
                        isSafe = false;
                        break;
                    }
                }

                if (isSafe)
                {
                    positions[row] = new Position(row, col);
                    SolveNQueenUtilAllSolutions(results, positions, n, row + 1);
                }
            }

        }
    }
}