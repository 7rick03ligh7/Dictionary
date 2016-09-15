using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dictionary
{
    public class RB_TreeOperator
    {
        static protected void RB_Insert_Fixup(ref Word root, Word z) // переставляет элементы согласно правилам RB_Tree
        {
            while (z != root && z.parent.isRed == true) // z!= root для того что бы не делать родитель корня
            {
                if (z.parent == z.parent.parent.left)
                {
                    Word f = new Word();
                    f = z.parent.parent.right;
                    if (f != null && f.isRed == true) // f! = null когда уходит влево ветка (не создаю нулевые листья)
                    {
                        z.parent.isRed = false;
                        f.isRed = false;
                        z.parent.parent.isRed = true;
                        z = z.parent.parent;

                    }
                    else
                    {
                        if (z == z.parent.right)
                        {
                            z = z.parent;
                            Left_Rotate(ref root, z);
                        }
                        z.parent.isRed = false;
                        z.parent.parent.isRed = true;
                        Right_Rotate(ref root, z.parent.parent);
                        root.parent = null;
                    }
                }
                else
                {
                    Word f = z.parent.parent.left;
                    if (f != null && f.isRed == true) // f! = null когда уходит вправо ветка (не создаю нулевые листья)
                    {
                        z.parent.isRed = false;
                        f.isRed = false;
                        z.parent.parent.isRed = true;
                        z = z.parent.parent;
                    }
                    else
                    {
                        if (z == z.parent.left)
                        {
                            z = z.parent;
                            Right_Rotate(ref root, z);
                        }
                        z.parent.isRed = false;
                        z.parent.parent.isRed = true;
                        Left_Rotate(ref root, z.parent.parent);
                        root.parent = null;
                    }
                }
            }
            root.isRed = false;
        }
        static protected void RB_Delete_Fixup(ref Word root, Word x) // переставляет элементы согласно правилам RB_Tree
        {
            if (x.right == null && x.left == null)
            {
                x.isRed = true;
                return;
            }


            Word w = null;
            while (x != root && x.isRed == false)
            {
                if (x == x.parent.left)
                {
                    w = x.parent.right;
                    if (w.isRed == true)
                    {
                        w.isRed = false;
                        x.parent.isRed = true;
                        Left_Rotate(ref root, x.parent);
                        w = x.parent.right;
                    }
                    if (w.left.isRed == false && w.right.isRed == false)
                    {
                        w.isRed = true;
                        x = x.parent;
                    }
                    else
                    {
                        if (w.right.isRed == false)
                        {
                            w.left.isRed = false;
                            w.isRed = true;
                            Right_Rotate(ref root, w);
                            w = x.parent.right;
                        }
                        w.isRed = x.parent.isRed;
                        x.parent.isRed = false;
                        w.right.isRed = false;
                        Left_Rotate(ref root, x.parent);
                        x = root;
                    }
                }
                else
                {
                    w = x.parent.right;
                    if (w.isRed == true)
                    {
                        w.isRed = false;
                        x.parent.isRed = true;
                        Left_Rotate(ref root, x.parent);
                        w = x.parent.right;
                    }
                    if (w.left.isRed == false && w.right.isRed == false)
                    {
                        w.isRed = true;
                        x = x.parent;
                    }
                    else
                    {
                        if (w.left.isRed == false)
                        {
                            w.right.isRed = false;
                            w.isRed = true;
                            Left_Rotate(ref root, w);
                            w = x.parent.left;
                        }
                        w.isRed = x.parent.isRed;
                        x.parent.isRed = false;
                        w.left.isRed = false;
                        Right_Rotate(ref root, x.parent);
                        x = root;
                    }
                }
            }
            x.isRed = false;
        }
        static protected void Left_Rotate(ref Word root, Word x) // левый поворот
        {
            Word f = x.right;
            x.right = f.left;
            if (f.left != null)
                f.left.parent = x;
            if (x.parent != null)
                f.parent = x.parent;
            if (x.parent == null)
                root = f;
            else
            {
                if (x == x.parent.left)
                    x.parent.left = f;
                else
                    x.parent.right = f;
            }
            f.left = x;
            if (x.parent == null)
                root = f;
            x.parent = f;
        }
        static protected void Right_Rotate(ref Word root, Word x) // правый поворот
        {
            Word f = x.left;
            x.left = f.right;
            if (f.right != null)
                f.right.parent = x;
            if (x.parent != null)
                f.parent = x.parent;

            if (x.parent == null)
                root = f;
            else
            {
                if (x == x.parent.right)
                    x.parent.right = f;
                else
                    x.parent.left = f;
            }
            f.right = x;
            if (x.parent == null)
                root = f;
            x.parent = f;
        }

    }
}
