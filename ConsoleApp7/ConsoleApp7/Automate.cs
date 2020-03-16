using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    
        public class Automate
        {
            public List<Char> alph = new List<Char>();
            public List<Etat> list_etat = new List<Etat>();
            int nb_etat;
            public List<Complex_etat> list_complex = new List<Complex_etat>();
            public List<Transition> list_transition = new List<Transition>();
            public Automate()
            {
                Console.Out.WriteLine("definissez l'alphabet ");
                Console.Out.WriteLine("donnez le nbre de lettres ");

                int n =Int16.Parse(Console.ReadLine()) ;
                for (int i = 0; i < n; i++)
                {
                        Console.Out.WriteLine("donnez la lettre suivante ");
                        alph.Add(Console.ReadLine()[0]);
                }
                Console.Out.WriteLine("donnez le nbre d'etats ");
                nb_etat = Int16.Parse(Console.ReadLine());
                int nb_trans;
            
                    for (int i = 0; i < nb_etat; i++)
                    {
                        Etat etat;
                        Console.Out.WriteLine("le'etats "+i+" et il final ? ");
                        if (Int16.Parse(Console.ReadLine()) == 0) {  etat = new Etat(true); }
                        else {  etat = new Etat(false); }
                        list_etat.Add(etat);
                    }
                    foreach (Etat etat in list_etat)
                    {

            
           
                        Console.Out.WriteLine("donnez le nbre de transitions partant de l'etat s"+etat.id);
                        nb_trans = Int16.Parse(Console.ReadLine());
                        for (int i = 0; i < nb_trans; i++)
                        {

                            //String s = Console.ReadLine();
                            Console.Out.WriteLine("donnez l'etat d'arrivé(s"+i+"):");

                            int b =Int16.Parse(Console.ReadLine());
                            Etat ett=new Etat(true);
                            //Complex_etat ettc = new Complex_etat();

                          foreach (Etat et in list_etat)
                            {
                                if (b == et.id)
                                {
                                    ett = et;
                                    break;
                                }
                            }
                          etat.list_etat_suiv.Add(ett);
                            //etat.list_etat_complex_suiv.Add(ettc);
                   
                    
                            Transition transition = new Transition(etat, ett);
                            Console.Out.WriteLine("construis la chaine");
                            Console.Out.WriteLine("donnez le nbre de lettres de votre chaine ");
                            int k = Console.ReadLine()[0];
                            for (int j = 0; j < k; j++) ;
                            {
                                transition.car.Add(Console.ReadLine()[0]);
                            }
                            list_transition.Add(transition);
                            etat.list_transition_partant.Add(transition);

                        }
                    }
            }


            public void simple()
                {
                    //enlever les transitions complexes 
                    foreach(Transition t in list_transition)
                    {
                        Etat etat = t.initial;
                        if (t.car.LongCount()!=1)
                        {
                            for(int i=1;i<t.car.LongCount();i++)
                            {
                       
                                Etat et = new Etat(false);
                                Transition tr = new Transition(etat,et);
                                tr.car[0] = t.car[i - 1] ;
                                if(i==1)etat.list_etat_suiv.Remove(t.final);
                                etat.list_etat_suiv.Add(et);
                                list_transition.Add(tr);
                                list_etat.Add(et);
                                etat = et;

                            }
                            list_transition.Remove(t);

                        }
                
               
                    }

                    //enlever les #
                    Boolean repeat = true;
                    while (repeat == true)
                    {
                        repeat = false;
                        foreach( Transition tran in list_transition)
                        {
                            if (tran.car[0] == '#')
                            {
                                repeat = true;
                                Etat fin = tran.final;
                                Etat init = tran.initial;
                                list_transition.Remove(tran);
                                if (fin.list_transition_partant.LongCount() == 0) {
                                    init.final = true;
                                    //sauvegarder dans liste detats
                                }
                                else
                                {
                                    foreach(Transition et in fin.list_transition_partant)
                                    {
                                        Transition tr = new Transition(tran.initial, et.final);
                                        tr.car[0] = et.car[0];
                                    }
                                }
                        
                            }
                        }
                    }
            
            
            }

                public void deterministe()
                {

                    //List<Complex_etat> nouvel_list = new List<Complex_etat>();
                    Complex_etat et = new Complex_etat();
                    et.list_etat.Add(list_etat[0]);
                    et.list_transition_partant.AddRange(list_etat[0].list_transition_partant);
                    list_complex.Add(et);

                    Complex_etat sauvegarde= new Complex_etat(); ;
                        sauvegarde = et;
                        Boolean cont = true;
                        int id = 100;
                        while(cont)
                        {
                            cont = false;
                            foreach (Complex_etat e in list_complex)
                            {
                                    List<Char> car = new List<Char>();
                                    car = e.char_list();
                                    
                                    foreach(Char i in car)
                                    {
                                        Complex_etat nv_etat_comp = new Complex_etat();
                                        foreach (Transition suiv in e.list_transition_partant)
                                        {
                                            
                                           if (suiv.car[0] == i)
                                           {
                                                
                                                if(!nv_etat_comp.list_etat.Contains(suiv.final)) nv_etat_comp.list_etat.Add(suiv.final);
                                                if(!nv_etat_comp.list_transition_partant.Contains(suiv)) nv_etat_comp.list_transition_partant.Add(suiv);

                                           }

                                        }
                                        foreach(Complex_etat cet in list_complex)
                                        {
                                            if (!(nv_etat_comp.CompareTo(cet) == 0))
                                            {
                                           
                                                nv_etat_comp.id= id;
                                                id++;
                                                sauvegarde.list_etat_complex_suiv.Add(nv_etat_comp);
                                                sauvegarde.list_etat_suiv.AddRange(nv_etat_comp.list_etat);
                                                list_complex.Add(nv_etat_comp);
                                                sauvegarde = nv_etat_comp;
                                            }
                                            cont = true;
                                        }

                                    }


                            }
                        }
                     
                }



        public List<Etat> complement()
        {
            Etat et = new Etat(true);
            Boolean bl = false;
            List<Etat> list = new List<Etat>();
            foreach (Etat e in list_etat)
            {
                foreach (Char c in alph)
                {
                    int i = 0;
                    Boolean b = false;
                    while (b == false && i < e.list_transition_partant.LongCount())
                    {
                        if (e.list_transition_partant[i].car[0] == c) { b = true; bl = true; }
                        i++;


                    }
                    if (b == false)
                    {
                        Transition t = new Transition(e, et);
                        t.car[0] = c;
                        list_transition.Add(t);


                    }
                }
                if (e.final == true) { e.final = true; }
                else { e.final = false; }
                list.Add(e);
                if (bl == true) list.Add(et);

            }
            return list;
        }

        public void miroir()
        {
            Etat e = new Etat(false);
            foreach (Etat et in list_etat)
            {
                if (et.final == true)
                {
                    Transition t = new Transition(et, e);
                    t.car[0] = '#';
                    list_transition.Add(t);

                }
                for (int i = 0; i < list_transition.LongCount(); i++)
                {
                    list_transition[i].inverser();
                }
            }


        }








        public void reduction(){
                    List<Etat> list_etat_accessible = new List<Etat>();
                    List<Etat> list_etat_co_accessible = new List<Etat>();
                    //suppression des etats non accessibles
                    list_etat_accessible.Add(list_etat[0]);
                    Boolean trouva=true;
                    while (trouva)
                    {
                        trouva = false;
                        foreach (Transition tra in list_transition)
                        {
                        /*Boolean accessible;
                        Etat tmp;*/
                        if ((list_etat_accessible.Contains(tra.initial))&&(!list_etat_accessible.Contains(tra.final))){ list_etat_accessible.Add(tra.final);trouva = true; }                    
                        }

                    }
                    foreach(Transition tr in list_transition)
                    {
                        if ((!list_etat_accessible.Contains(tr.initial)) || (!list_etat_accessible.Contains(tr.final))){
                            list_transition.Remove(tr);
                        }
                    }
            
                    foreach (Etat et in list_etat)
                    {
                        if (!list_etat_accessible.Contains(et)) list_etat.Remove(et);
                    }





                    //supression des etats non coaccessible 
                    foreach(Etat et in list_etat)
                    {
                        if (et.final == true) list_etat_co_accessible.Add(et);
                    }
                    Boolean trouv = true;
                    while (trouv)
                    {
                        trouv = false;
                        foreach (Transition tra in list_transition)
                        {
                            /*Boolean accessible;
                            Etat tmp;*/
                            if ((list_etat_co_accessible.Contains(tra.final)) && (!list_etat_co_accessible.Contains(tra.initial))) { list_etat_co_accessible.Add(tra.initial); trouv = true; }
                        }

                    }
                    foreach (Transition tr in list_transition)
                    {
                        if ((!list_etat_co_accessible.Contains(tr.initial)) || (!list_etat_co_accessible.Contains(tr.final)))
                        {
                            list_transition.Remove(tr);
                        }
                    }

                    foreach (Etat et in list_etat)
                    {
                        if (!list_etat_co_accessible.Contains(et)) list_etat.Remove(et);
                    }
                }








        // methodes de listage

        public void etats()
        {
            foreach(Etat e in list_etat)
            {
                Console.WriteLine("Etat n"+e.id+" :");
                Console.WriteLine("               pointe vers :");
                foreach(Transition t in e.list_transition_partant)
                {
                    Console.WriteLine("               "+t.final.id+" avec l'alphabet :"+t.car);
                }
            }

        }
        public void alphabet()
        {
            Console.WriteLine("l'alphabet de cet automat est :");
            foreach (Char e in alph)
            {
                Console.WriteLine(e);
            }

        }
        public void etats_complex()
        {
            foreach (Complex_etat e in list_complex)
            {
                Console.WriteLine("Etat n" + e.id + " :");
                Console.WriteLine("               contiens les etats :");
                foreach (Etat ine in e.list_etat)
                {
                    Console.WriteLine("               " + ine.id );
                }
            }

        }
        public void transitions()
        {
            foreach (Transition e in list_transition)
            {
                Console.WriteLine("("+e.initial.id+" , "+e.car+" , "+ e.final.id + ")");
            }

        }




















    }
}
