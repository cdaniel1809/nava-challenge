using nava_challenge.Decoder;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace nava_challenge.Tree
{
    public class Tree : ITree
    {

        private readonly IDecoder _decoder;
        private readonly ILogger<Tree> _log;

        public Tree(ILogger<Tree> log,
            IDecoder decoder
        )
        {
              this._log = log;
              this._decoder = decoder;  

        }
        public INode RootNode {get; set;}

        public void LoadTree(string stream)
        {
              int offset = 0;
              Node root = new Node(this._decoder);
              //var firstCode = GetIntFromString(offset,  1, stream);
              root.LeftNode  = CheckNode(offset , 1, stream, root);
              root.RigthNode = CheckNode(offset , 2, stream, root);
              this.RootNode = root;
              
        }

        

        private INode CheckNode(int offset, int positions_to_move, string stream, INode Parent)
        {
           
            int code = GetIntFromString(offset, positions_to_move, stream);
            Node Node = null;

            if(code > 0 && code <= 26)
            {
                Node = new Node (this._decoder);
                Node.ParentNode = Parent;
                Node.Code = code;
                int local_offset = offset + positions_to_move;
                Node.LeftNode  = CheckNode(local_offset, 1, stream,Node);
                Node.RigthNode = CheckNode(local_offset, 2, stream,Node);
            }

            return Node;

        }

        private int GetIntFromString(int start_offset, int positions_to_take, string stream)
        {
            int expected = 0;
            if((start_offset + positions_to_take) <= stream.Length)
            {
                int.TryParse(stream.Substring(start_offset, positions_to_take), out expected);
            }
            return expected;

        }
         public void PrintLeafs()
         {

             if(this.RootNode != null)
             {
                 string string_to_print = "";
                 this.RootNode.Print(string_to_print);  
             }
         }
    }
}