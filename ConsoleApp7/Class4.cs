using System;

public class Automate
{
   public  List<Char> alph = new List<char>();
   public  List<Etat> list_etat = new List<Etat>();
    int nb_etat;
    public List<Complex_etat> list_complex = new List<Complex_etat>();
   public  List<Transition> list_transition = new List<Transition>();
	public Automate()
	{
        Console.Out.WriteLine("definissez l'alphabet ");
        Console.Out.WriteLine("donnez le nbre de lettres ");

       char n= Console.ReadLine()[0];
        for(int i=0;i<n;i++)
        {
            alph.add(Console.ReadLine()[0]);

        }
        Console.Out.WriteLine("donnez le nbre d'etats ");
        nb_etat=Console.ReadLine()[0];
        int nb_trans;
        for (int i = 0; i < nb_etat; i++)
        {

            Console.Out.WriteLine("etat final ? ");


            if (Console.ReadLine()[0] == 0) { Etat etat = new Etat(true); }
            else { Etat etat = new Etat(false); }
            list_etat.add(etat);
        }
        foreach(Etat etat in list_etat)
            Console.Out.WriteLine("donnez le nbre de transitions partant de cet etat");
            nb_trans= Console.ReadLine()[0];
            for(int i=0;i<nb_trans;i++)
            {
           
            //String s = Console.ReadLine();
            Console.Out.WriteLine("donnez l'etat d'arrivé");

            int b = Console.ReadLine()[0];
            Transition transition = new Transition(etat.id, b);
            Console.Out.WriteLine("donnez la chaine");
            Console.Out.WriteLine("donnez le nbre de lettres de votre chaine ");
            int k = Console.ReadLine()[0];
            for (int j = 0; j < k; j++) ;
            {
                transition.car.add(Console.ReadLine()[0]);
            }
            list_transition.add(transition);



        }
        }


    }
}
