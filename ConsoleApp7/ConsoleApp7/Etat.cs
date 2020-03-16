using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    public class Etat
    {
         public int id;
        static int cpt = 0;
       public  List<Etat> list_etat_suiv = new List<Etat>();
      public   List<Complex_etat> list_etat_complex_suiv = new List<Complex_etat>();
        public List<Transition> list_transition_partant = new List<Transition>();

       public Boolean final;
        public Etat(Boolean final)
        {
            this.id = cpt;
            cpt++;
            this.final = final;

        }
        
    public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            // TODO: write your implementation of Equals() here
            throw new NotImplementedException();
            return base.Equals(obj);
        }

        
         
    }
}
