
namespace BinaryTreeTask
{
    class BinaryTreeNode
    {
        public int Value { get; }
        public BinaryTreeNode Right { get; set; }
        public BinaryTreeNode Left { get; set; }

        public BinaryTreeNode(int newValue)
        {
            this.Value = newValue;
        }
    }
}
