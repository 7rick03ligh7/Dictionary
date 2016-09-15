using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Controls;
using System.Windows;

namespace Dictionary
{
    class Model
    {
        private Word editable = new Word();
        public void SetEditable(ref object sender)
        {
            ListView temp = (ListView)sender;
            if (temp.SelectedItem != null)
                editable = (Word)temp.SelectedItem;
        }

        private Tree tree;
        private char lastVisited = 'а';


        public Model()
        {
            tree = FileOperator.ReadFile(tree);
        }



        public List<Word> Search(List<Word> list, string searched)
        {
            list = tree.Tree_Search(tree.root, searched, list);
            return list;
        }
        public List<Word> Search(List<Word> list, char symb)
        {
            lastVisited = symb;
            list = tree.Tree_Search(tree.root, symb, list);
            return list;
        }
        public List<Word> Search(List<Word> list)
        {
            list = tree.Tree_Search(tree.root, lastVisited, list);
            return list;
        }
        public List<Word> Insert(List<Word> list, string termin, string description)
        {
            termin = Validate.ReturnSkipSpace(termin);
            description = Validate.ReturnSkipSpace(description);

            if (termin != "" && description != "")
            {
                tree.Insert(termin, description);
                FileOperator.WriteFile(tree.root);
            }
            else
            {
                MessageBox.Show("Слово не добавлено");
            }

            list = tree.Tree_Search(tree.root, lastVisited, list);
            return list;
        }
        public List<Word> Edit(string newDescription, List<Word> list)
        {
            if (editable.termin != null && editable.termin != "" && newDescription != "")
            {
                tree.Edit(tree.root, editable, newDescription);
                FileOperator.WriteFile(tree.root);
                list = tree.Tree_Search(tree.root, editable.termin.ToLower().First(), list);
            }
            else
            {
                list = tree.Tree_Search(tree.root, lastVisited, list);
                MessageBox.Show("Слово не отредактировано");
            }
            return list;
        }
        public List<Word> Delete(List<Word> list)
        {
            if (editable.termin != null)
            {
                tree.Delete(tree.root, editable);
                FileOperator.WriteFile(tree.root);
                list = tree.Tree_Search(tree.root, editable.termin.ToLower().First(), list);
            }
            else
            {
                list = tree.Tree_Search(tree.root, lastVisited, list);
                MessageBox.Show("Слово не удалено");
            }


            return list;
        }


        public void RestoreDefault()
        {
            FileOperator.RestoreDefault();
            tree = FileOperator.ReadFile(tree);
            MessageBox.Show("Все слова установлены по умолчанию");            
        }
        public void MakeBackup(char str)
        {
            FileOperator.MakeBackup(str);
            MessageBox.Show("Создан файл бэкапа-" + str);
        }
        public void RestoreBackup(char str)
        {
            FileOperator.RestoreBackup(str);
            tree = FileOperator.ReadFile(tree);
            MessageBox.Show("Все слова восстановлены из бэкапа-" + str);
        }

    }

}
