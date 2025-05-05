using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    public static class ConstantVars
    {
        public const int SELECT_ROWS_GAME = 1; // select for Rows
        public const int SELECT_COLOUMNS_GAME = 2; //select for Columns
        public const int SELECT_TOP_LEFT_DIAGONAL_GAME = 3;// select for Diagonals
        public const int SELECT_TOP_RIGHT_DIAGONAL_GAME = 4;
        public const int SELECT_CENTER_LINE_GAME = 5; // select Center row

        public const string PLAYER_TO_CONTINUE_ACCEPT = "y";
        public const string PLAYER_TO_CONTINUE_DECLINE = "n";

        public const int WINNING_BET = 10;
        public const int BONUS = 50; // use for diagonal wins 
        public const int BONUS_2 = 75; // use for diagonal wins

        public const int LOW = 0; // const low number 
        public const int HIGH = 9; // since 9 is the biggest "ones"
  
    }
}
