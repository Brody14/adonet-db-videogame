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

                        case 2:
                        {
                            try
                            {
                                Console.Write("Inserisci l'ID del videogioco che vuoi cercare: ");
                                long idSearched = long.Parse(Console.ReadLine());
                                VideogameManager.GetVideogameById(idSearched);
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                        }

                        break;

                        case 3:
                        {

                            Console.Write("Inserisci la parola che vuoi cercare all'interno del nome del videogioco: ");
                            string input = Console.ReadLine();
                            List<Videogame> videogames = VideogameManager.GetVideogameByInput(input);

                           if(videogames.Count > 0)
                            {
                                foreach (Videogame vid in videogames)
                                {
                                    Console.WriteLine(vid);
                                }
                            }
                           
                        }
                        break;

                        case 4:
                        {
                            Console.Write("Inserisci l'ID del videogioco che vuoi cancellare: ");
                            long idToDelete = long.Parse(Console.ReadLine());

                            bool deleted = VideogameManager.DeleteVideogame(idToDelete);

                            if (deleted)
                            {
                                Console.WriteLine($"Il videogioco con ID {idToDelete} è stato cancellato");
                            }
                            else
                            {
                                Console.WriteLine($"Il videogioco con ID {idToDelete} non è stato cancellato");
                            }


                        }
                        break;

                    case 5:
                        {
                            Environment.Exit(0);
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Non hai selezionato un opzione valida!");
                        }
                        break;
                }
            }
        }
    }
}