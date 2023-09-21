namespace adonet_db_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Creiamo quindi una console app che all'avvio mostra un menu con la 
             * possibilità di :
                1 inserire un nuovo videogioco
                2 ricercare un videogioco per id
                3 ricercare tutti i videogiochi aventi il nome contenente una determinata stringa inserita in input
                4 cancellare un videogioco
                5 chiudere il programma*/

            Console.WriteLine("Benvenuto nel nostro gestionale di videogame! Ecco cosa puoi fare:");


            while (true)
            {
                Console.WriteLine(@"
            - 1: Inserisci un nuovo videogame
            - 2: Ricerca un videogame per id
            - 3: Ricerca tutti i videogiochi che contengono nel nome un tuo input
            - 4: Cancella un videogioco
            - 5: Chiudi il programma
            ");

                Console.Write("Seleziona l'opzione --> ");

                int selectedOption = int.Parse(Console.ReadLine());

                switch (selectedOption)
                {
                    case 1:
                        {
                            
                            Console.WriteLine("Inserisci i dati del videogame!");
                            Console.Write("Inserisci il nome: ");
                            string name = Console.ReadLine();

                            Console.Write("Inserisci la trama: ");
                            string overview = Console.ReadLine();

                            Console.Write("Inserisci la data di rilascio (gg/mm/aaaa): ");
                            DateTime releaseDate = DateTime.Parse(Console.ReadLine());

                            Console.Write("Inserisci l'id della Software House: ");
                            long softwareHouse = long.Parse(Console.ReadLine());

                            Videogame newVideogame = new Videogame(0, name, overview, releaseDate, softwareHouse);
                            bool inserted = VideogameManager.AddVideogame(newVideogame);

                            if (inserted)
                            {
                                Console.WriteLine("Il tuo videogioco è stato aggiunto!");
                            }
                            else
                            {
                                Console.WriteLine("Videogioco non inserito!");
                            }
                          
                        }

                        break;
                }
            }
        }
    }
}