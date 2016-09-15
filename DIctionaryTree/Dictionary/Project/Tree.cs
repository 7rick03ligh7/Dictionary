using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class Tree : RB_TreeOperator
    {
        public Word Root = new Word();
        public Word root
        {
            get { return Root; }
            set { Root = value; }
        }

        public Tree(string str1, string str2)
        {
            Root.termin = str1;
            Root.description = str2;
            Root.isRed = false;
        } //пользовательский конструктор  - начальное значение для корня


        public void Insert(string termin, string description) // вставка в дерево
        {
            Word z = new Word();
            z.termin = termin;
            z.description = description;
            Word y = null;
            Word x = root;
            while (x != null)
            {
                y = x;
                if (z.termin.CompareTo(y.termin) <= 0)
                {
                    if (z.termin.CompareTo(y.termin) == 0)
                    {
                        if (z.description.CompareTo(y.description) <= 0)
                        {
                            x = x.left;
                        }
                        else
                            x = x.right;
                    }
                    else
                        x = x.left;
                }
                else
                    x = x.right;
            }
            z.parent = y;
            if (y == null)
                root = z;
            else
            {
                if (z.termin.CompareTo(y.termin) <= 0)
                {
                    if (z.termin.CompareTo(y.termin) == 0)
                    {
                        if (z.description.CompareTo(y.description) <= 0)
                        {
                            y.left = z;
                        }
                        else
                            y.right = z;
                    }
                    else
                        y.left = z;
                }
                else
                    y.right = z;
            }
            RB_Insert_Fixup(ref Root, z);
        }
        public List<Word> Tree_Search(Word x, string termin, List<Word> list) // возвращает список искомых элементов
        {
            if (x == null)
                return list;

            Tree_Search(x.left, termin, list);

            if (termin.CompareTo(x.termin) == 0)
            {
                list.Add(x);
                if (x.right != null)
                {
                    Tree_Search(x.right, termin, list);
                }
                return list;
            }

            Tree_Search(x.right, termin, list);
            return list;
        }
        public List<Word> Tree_Search(Word x, char ch, List<Word> list) // возвращает список искомых элементов
        {
            if (x == null)
            {
                return list;
            }

            Tree_Search(x.left, ch, list);

            if (ch.CompareTo(x.termin.First()) == 0)
            {
                list.Add(x);
                if (x.right != null)
                {
                    Tree_Search(x.right, ch, list);
                }
                return list;
            }

            Tree_Search(x.right, ch, list);
            return list;

        }
        public Word Tree_Search(Word x, string termin, string description) // возвращает искомый элемент
        {
            if (x == null || (termin.CompareTo(x.termin) == 0 && description.CompareTo(x.description) == 0))
                return x;
            if (termin.CompareTo(x.termin) <= 0)
            {
                if (termin.CompareTo(x.termin) == 0)
                {
                    if (description.CompareTo(x.description) <= 0)
                        return Tree_Search(x.left, termin, description);
                    else
                        return Tree_Search(x.right, termin, description);
                }
                return Tree_Search(x.left, termin, description);
            }
            else
                return Tree_Search(x.right, termin, description);
        }
        public void Delete(Word root, Word z) // процедура для удаления элемента z из RB_Tree
        {
            Word y = null;
            Word x = null;

            if (z.left == null || z.right == null)
                y = z;
            else
                y = Tree_Successor(z);
            if (y.left != null)
                x = y.left;
            else
                x = y.right;
            if (x != null)
                x.parent = y.parent;

            if (y.parent == null)
                root = x;
            else
            {
                if (y == y.parent.left)
                    y.parent.left = x;
                else
                    y.parent.right = x;
            }
            if (y != z)
            {
                z.termin = y.termin;
                z.description = y.description;
            }
            if (y.isRed == false && x != null)
                RB_Delete_Fixup(ref root, x);
        }
        public void Edit(Word root, Word editable, string newDescription)
        {
            Word editWord = new Word();
            editWord = Tree_Search(root, editable.termin, editable.description);

            editWord.description = newDescription;
            RB_Insert_Fixup(ref Root, editable);
        }
        public Word Tree_Successor(Word x) // возвращает узел, следующий за узлом x (если такой существует)
        {
            Word y = null;
            if (x.right != null)
                return Tree_Minimum(x.right);
            y = x.parent;
            while (y != null && x == y.right)
            {
                x = y;
                y = y.parent;
            }
            return y;
        }
        public Word Tree_Minimum(Word x) // нахождение минимального, x – корень или узел откуда опускатья
        {
            while (x.left != null)
                x = x.left;
            return x;
        }
    }
}
