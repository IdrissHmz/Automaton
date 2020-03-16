using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    public class Complex_etat :IComparable
    {
        public int id;
        public List<Etat> list_etat = new List<Etat>();
        public List<Etat> list_etat_suiv = new List<Etat>();
        public List<Complex_etat> list_etat_complex_suiv = new List<Complex_etat>();
        public List<Transition> list_transition_partant = new List<Transition>();
        public Complex_etat()
        {
        }
        public Boolean final()
        {
            
            foreach (Etat et in list_etat)
            {
                if (et.final == true) return true;
            }
            return false;
        }
        public List<Char> char_list()
        {
            List<Char> car = new List<Char>();
            foreach(Transition t in list_transition_partant)
            {
                if (!car.Contains(t.car[0])) { car.Add(t.car[0]); }
            }
            return car;
        }
       

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Complex_etat cet = obj as Complex_etat;
            if (cet != null)
            {
                Boolean vrai = true;
                foreach(Etat et in list_etat)
                {
                    if (!cet.list_etat.Contains(et)) return 2;
                }
                return 0;

            }
            else
                throw new ArgumentException("Object is not a Temperature"); 
        }
    }
}
