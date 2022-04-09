using System.Collections.Generic;

namespace nava_challenge.Tree
{
    public interface INode
    {
         public INode ParentNode {get; set;} 

        public INode LeftNode {get; set;}

        public INode RigthNode {get; set;}

        public int Code {get; set;}

        public void Print(string string_to_print);
    }
}