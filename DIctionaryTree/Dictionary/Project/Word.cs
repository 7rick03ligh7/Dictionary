using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    public class Word : IEquatable<Word>, IComparable<Word>
    {
        public Word left
        {
            get; set;
        }//левый потомок
        public Word right
        {
            get;
            set;
        }//правый потомок
        public Word parent { get; set; }//родитель
        public bool isRed { get; set; } = true; //по умолчанию красный

        public Word()
        {
            left = null;
            right = null;
            parent = null;
        }


        public string termin { get; set; }
        public string description { get; set; }
        public override string ToString()
        {
            return "termin: " + termin + "   description: " + description;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Word objAsPart = obj as Word;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public int CompareTo(Word comparePart)
        {
            if (comparePart == null)
                return 1;

            else
                return termin.CompareTo(comparePart.termin);
        }
        public override int GetHashCode()
        {
            return termin.GetHashCode();
        }
        public bool Equals(Word other)
        {
            if (other == null) return false;
            return (termin.Equals(other.termin));
        }
        public static bool operator ==(Word word1, Word word2)
        {
            if (ReferenceEquals(word1, word2))
            {
                return true;
            }
            if (((object)word1 == null) || ((object)word2 == null))
            {
                return false;
            }

            return word1.termin == word2.termin && word1.description == word2.description;
        }
        public static bool operator !=(Word word1, Word word2)
        {
            return !(word1 == word2);
        }

    }
}
