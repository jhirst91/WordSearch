using System;

namespace WordSearch
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();
            char[] arr1 = { 'A', 'B', 'C', 'E' };
            char[] arr2 = { 'S', 'F', 'C', 'S' };
            char[] arr3 = { 'A', 'D', 'E', 'E' };
            string[] words = { "ABCCED","SEE", "ABCB" };

            foreach (var word in words)
            {
                char[][] board = { arr1, arr2, arr3 };
                Console.WriteLine(solution.Exist(board, word));
            }
        }
    }
    public class Solution
    {
        public bool Exist(char[][] board, string word)
        {
            var result = false;
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (DepthFirstSearch(board, word, i, j, 0))
                        result = true;
                }
            }
            return result;
        }

        public bool DepthFirstSearch(char[][] board, string word, int i, int j, int k)
        {
            if (i < 0 || j < 0 || i >= board.Length || j >= board[0].Length)
            {
                return false;
            }
            if (board[i][j] == word[k])
            {
                var holder = board[i][j];
                board[i][j] = '#';
                if (k == word.Length - 1)
                {
                    return true;
                }
                else if (DepthFirstSearch(board, word, i - 1, j, k + 1) || DepthFirstSearch(board, word, i + 1, j, k + 1) || DepthFirstSearch(board, word, i, j - 1, k + 1) || DepthFirstSearch(board, word, i, j + 1, k + 1))
                {
                    return true;
                }
                board[i][j] = holder;
            }
            return false;
        }
    }
}
