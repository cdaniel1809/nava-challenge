using System;
using System.Collections.Generic;

namespace nava_challenge.Decoder
{
    public class LowerDecoder : IDecoder
    {
         private readonly Dictionary<int, int> codes = new Dictionary<int, int> 
         {
                {1, 97}, //A
                {2, 98}, //B
                {3, 99}, //C
                {4, 100}, //D
                {5, 101}, //E
                {6, 102}, //F
                {7, 103}, //G
                {8, 104}, //H
                {9, 105}, //I
                {10, 106}, //J
                {11, 107}, //K
                {12, 108}, //L
                {13, 109}, //M
                {14, 110}, //N
                {15, 111}, //O
                {16, 112}, //P
                {17, 113}, //Q
                {18, 114}, //R
                {19, 115}, //S
                {20, 116}, //T
                {21, 117}, //U
                {22, 118}, //V
                {23, 119}, //W
                {24, 120}, //X
                {25, 121}, //Y
                {26, 122}, //Z

         };
        
        public string Decode(int code)
        {
            int expected = 0; // NULL in ascii

              if(this.codes.TryGetValue(code, out expected))
              {
                  return ((char)expected).ToString();
              }
              return String.Empty;
        }
    }
}