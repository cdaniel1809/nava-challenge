using nava_challenge.Decoder;
using System.Collections.Generic;
using System;

namespace nava_challenge.Tree
{
    public class Node : INode
    {
        public INode ParentNode {get; set;} 

        public INode LeftNode {get; set;}

        public INode RigthNode {get; set;}

        public bool IsLeaf 
        {
            get {
                    bool expected = false; 
                    expected = (this.LeftNode == null && this.RigthNode == null);
                    return expected;
                }
        }

        public int Code {get; set;}

       

         private readonly IDecoder _decoder;
         
         public Node(IDecoder decoder)
        {
            
              this._decoder = decoder;  
             
        }

        public void Print(string string_to_print_from_parent)
        {
           
            string string_to_print = $"{string_to_print_from_parent}{this._decoder.Decode(this.Code)}";
            
            if(this.LeftNode != null)
            {
                this.LeftNode.Print(string_to_print);
            }
           
            if(this.RigthNode != null)
            {
                this.RigthNode.Print(string_to_print);
            }
           
           if(this.IsLeaf)
                Console.WriteLine(string_to_print);
            
        }
    }
}