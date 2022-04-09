namespace nava_challenge.Tree
{
    public interface ITree
    {

        public INode RootNode {get; set;}
         public void LoadTree(string stream);

         public void PrintLeafs();
    }
}