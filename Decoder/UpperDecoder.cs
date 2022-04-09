using System;
using System.Collections.Generic;

namespace nava_challenge.Decoder
{
    public class UpperDecoder : IDecoder
    {
         private readonly Dictionary<int, int> codes = new Dictionary<int, int> 
         {
                {1, 65}, //A
                {2, 66}, //B
                {3, 67}, //C
                {4, 68}, //D
                {5, 69}, //E
                {6, 70}, //F
                {7, 71}, //G
                {8, 72}, //H
                {9, 73}, //I
                {10, 74}, //J
                {11, 75}, //K
                {12, 76}, //L
                {13, 77}, //M
                {14, 78}, //N
                {15, 79}, //O
                {16, 80}, //P
                {17, 81}, //Q
                {18, 82}, //R
                {19, 83}, //S
                {20, 84}, //T
                {21, 85}, //U
                {22, 86}, //V
                {23, 87}, //W
                {24, 88}, //X
                {25, 89}, //Y
                {26, 90}, //Z

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