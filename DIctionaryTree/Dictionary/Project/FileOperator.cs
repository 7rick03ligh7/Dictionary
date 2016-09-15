using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dictionary
{
    class FileOperator
    {
        static public Tree ReadFile(Tree tree)
        {

            FileStream file1 = new FileStream("C:\\Users\\Алексей\\Desktop\\Project\\OZHEGOV.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(file1))
            {
                string line = "";
                bool flag;
                line = reader.ReadLine();
                Word first = new Word();                


                first.termin = null;
                first.description = null;

                flag = false;

                foreach (char symb in line)
                {
                    if (symb == '|')
                    {
                        flag = true;
                    }
                    else
                    {
                        if (flag == false)
                        {
                            first.termin += symb;
                        }
                        else
                        {
                            first.description += symb;
                        }
                    }
                }
                tree = new Tree(first.termin, first.description);



                while (line != null)
                {
                    Word word = new Word();

                    line = reader.ReadLine();
                    if (line != null)
                    {
                        word.termin = null;
                        word.description = null;

                        flag = false;

                        foreach (char symb in line)
                        {
                            if (symb == '|')
                            {
                                flag = true;
                            }
                            else
                            {
                                if (flag == false)
                                {
                                    word.termin += symb;
                                }
                                else
                                {
                                    word.description += symb;
                                }
                            }
                        }
                        tree.Insert(word.termin, word.description);
                    }
                }
                file1.Close();
                return tree;
            }

        }
        static public void WriteFile(Word root)
        {
            FileStream file1 = new FileStream("C:\\Users\\Алексей\\Desktop\\Project\\cash\\OZHEGOV.txt", FileMode.Create);
            using (StreamWriter writer = new StreamWriter(file1))
            {
                WriterToF(root, writer);
            }
            File.Copy("C:\\Users\\Алексей\\Desktop\\Project\\cash\\OZHEGOV.txt", "C:\\Users\\Алексей\\Desktop\\Project\\OZHEGOV.txt", true);
        }
        static private void WriterToF(Word node, StreamWriter writer)
        {
            if (node == null)
                return;
            WriterToF(node.left, writer);
            writer.WriteLine(node.termin + "||||" + node.description + "||");
            WriterToF(node.right, writer);
        }
        static public void RestoreDefault()
        {
            File.Copy("C:\\Users\\Алексей\\Desktop\\Project\\DEFAULT.txt", "C:\\Users\\Алексей\\Desktop\\Project\\OZHEGOV.txt", true);
        }
        static public void MakeBackup(char str)
        {
            File.Copy("C:\\Users\\Алексей\\Desktop\\Project\\OZHEGOV.txt", "C:\\Users\\Алексей\\Desktop\\Project\\Backup" + str + ".txt", true);
        }
        static public void RestoreBackup(char str)
        {
            File.Copy("C:\\Users\\Алексей\\Desktop\\Project\\Backup" + str + ".txt", "C:\\Users\\Алексей\\Desktop\\Project\\OZHEGOV.txt", true);
        }
    }
}
