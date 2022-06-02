using System.IO;
using System.Text.Json;


namespace BinaryTreeTask
{
    class JsonTreeWriter
    {
        public void WriteTreeToFile(object tree)
        {
            string Path = Directory.GetCurrentDirectory() + "/BinaryTree.txt";
            FileInfo treeJsonFile = new FileInfo(Path);

            if (!treeJsonFile.Exists)
                File.Create(Path).Close();

            string serializedTree = JsonSerializer.Serialize(tree);
            StreamWriter jsonWriter = new StreamWriter(Path);
            jsonWriter.WriteLine(serializedTree);
            jsonWriter.Flush();
            jsonWriter.Close();
        }

    }
}
