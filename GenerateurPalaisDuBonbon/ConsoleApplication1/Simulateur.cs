﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateurPalaisDuBonbon
{
    class Simulateur
    {
        // Objet random
        public static Random rnd = new Random();
        
        /**
         * Simulation de la phase de production des bonbons d'une commande
         * @param commande
         * @return double temps en secondes
         */
        public static double simulerFabricationCommande(Commande commande)
        {
            double resultat = 0; // temps nécessaire pour produire la commande
            
            IDictionary<int, double> dictionnaire = new Dictionary<int, double>(); // dictionnaire qui contiendra "tempsFabri/idMachine"

            int nbLignes = commande.nbLignes; // Nombre de lignes dans la commande
            List<Machine> machinesAChoisir; // liste qui contiendra les machines viables pour chaque ligne

            int tmp;
            //Machine[] machines = Machine.creationMachines();
            Machine[] machines = Machine.creationMachinesFabrication();
            List<LigneDeCommande> commandes = commande.lignesDeCommandes;

            int multiplicateur; // multiplicateur utilisé pour calculer le nombre de bonbons selon le conditionnement
            
            if (commandes == null)
            {
                return -1;
            }

            // on sélectionne les lignes de commande une par une
            foreach (LigneDeCommande ligne in commandes)
            {
                machinesAChoisir = new List<Machine>();
                // On récupère les machines viables pour cette ligne de commande
                foreach (Machine machine in machines)
                {
                    if(machine.condition == ligne.variante)
                    {
                        machinesAChoisir.Add(machine);
                    }
                }

                // On prend une machine aléatoirement parmi les machinesAChoisir
                tmp = rnd.Next(machinesAChoisir.Count());

                // on set l'attribut "machine" de la ligne de commande en choisissant une machine aléatoire parmi machinesAChoisir 
                ligne.machineFab = machinesAChoisir[tmp];

                // Ajout de la ligne à la machine
                machinesAChoisir[tmp].ajouterLigne(ligne);
                
            }
            
            // On parcourt toutes les machines en lisant leurs Queues pour ressortir le temps total
            foreach (Machine machine in machines)
            {
                // On ajoute une clé machineID au dictionnaire si elle n'est pas encore présente
                if(!dictionnaire.ContainsKey(machine.idMachine))
                {
                    dictionnaire.Add(machine.idMachine, 0);
                }          
                foreach (LigneDeCommande ligne in machine.machineQueue)
                {
                    // selon le conditionnement, on adapte le nombre de bonbons qui vont devoir passer à la machine
                    if(ligne.conditionnement == 1)
                    {
                        // sachet = 10 bonbons
                        multiplicateur = 10;
                    } else if (ligne.conditionnement == 2)
                    {
                        // boite = 25 bonbons
                        multiplicateur = 25;
                    } else
                    {
                        // échantillon = 1 bonbon
                        multiplicateur = 1;
                    }
                    resultat += (machine.cadence * ligne.nombreConditionnements * multiplicateur);

                    // on place le temps de fabrication de la ligne dans l'attribut
                    ligne.tempsFab = (int) (machine.cadence * ligne.nombreConditionnements * multiplicateur);

                    if (ligne.nomBonbon != machine.tete)
                    {
                        resultat += machine.delai;
                        machine.tete = ligne.nomBonbon;
                        // On vérifie qu'il ne s'agisse pas d'une machine double
                        // Si c'est une machine double, on change également l'attribut tête de sa ou ses paires
                        foreach (Machine machinesMultiples in machines)
                        {
                            if(machinesMultiples.idMachine == machine.idMachine)
                            {
                                machinesMultiples.tete = ligne.nomBonbon;
                            }
                        }
                    }
                    dictionnaire[machine.idMachine] += resultat;
                    resultat = 0;
                }              
            }

            // On met le temps du chemin critique dans le resultat
            foreach (KeyValuePair<int, double> kvp in dictionnaire)
            {
                if (resultat < kvp.Value)
                {
                    resultat = kvp.Value;
                }
            }

            // on clean les lignes associées aux machines
            foreach (Machine machine in machines)
            {
                machine.machineQueue = new List<LigneDeCommande>();
                machine.queueTaille = 0;
            }
            commande.tempsFab = resultat;

            return resultat;
        }

        /**
         * Simulation de la phase de conditionnement des bonbons d'une commande
         * @param commande
         * @return double temps en secondes
         */
        public static double simulerConditionnementCommande(Commande commande)
        {
            double resultat = 0;

            IDictionary<int, double> dictionnaire = new Dictionary<int, double>(); // dictionnaire qui contiendra "tempsFabri/idMachine"

            int nbLignes = commande.nbLignes; // Nombre de lignes dans la commande
            List<Machine> machinesAChoisir; // liste qui contiendra les machines viables pour chaque ligne

            int tmp;
            
            int multiplicateur; // multiplicateur utilisé pour calculer le nombre de bonbons selon le conditionnement

            Machine[] machines = Machine.creationMachinesConditionnement();
            List<LigneDeCommande> commandes = commande.lignesDeCommandes;

            ////////////////////////////////////////////////////////////////////////////////////////
            //int multiplicateur; // multiplicateur utilisé pour calculer le nombre de bonbons selon le conditionnement

            if (commandes == null)
            {
                return -1;
            }

            // on sélectionne les lignes de commande une par une
            foreach (LigneDeCommande ligne in commandes)
            {
                machinesAChoisir = new List<Machine>();
                // On récupère les machines viables pour cette ligne de commande
                foreach (Machine machine in machines)
                {
                    if (machine.condition == ligne.conditionnement)
                    {
                        machinesAChoisir.Add(machine);
                    }
                }

                // On prend une machine aléatoirement parmi les machinesAChoisir
                tmp = rnd.Next(machinesAChoisir.Count());

                // on set l'attribut "machine" de la ligne de commande en choisissant une machine aléatoire parmi machinesAChoisir 
                ligne.machineCond = machinesAChoisir[tmp];

                // Ajout de la ligne à la machine
                machinesAChoisir[tmp].ajouterLigne(ligne);
                

            }

            // On parcourt toutes les machines en lisant leurs Queues pour ressortir le temps total
            foreach (Machine machine in machines)
            {
                // On ajoute une clé idMachine au dictionnaire si elle n'est pas encore présente
                if (!dictionnaire.ContainsKey(machine.idMachine))
                {
                    dictionnaire.Add(machine.idMachine, 0);
                }
                foreach (LigneDeCommande ligne in machine.machineQueue)
                {
                    // selon le conditionnement, on adapte le nombre de bonbons qui vont devoir passer à la machine
                    if (ligne.conditionnement == 1)
                    {
                        // sachet = 10 bonbons
                        multiplicateur = 10;
                    }
                    else if (ligne.conditionnement == 2)
                    {
                        // boite = 25 bonbons
                        multiplicateur = 25;
                    }
                    else
                    {
                        // échantillon = 1 bonbon
                        multiplicateur = 1;
                    }
                    resultat += (machine.cadence * ligne.nombreConditionnements * multiplicateur);

                    // on place le temps de fabrication de la ligne dans l'attribut
                    ligne.tempsCondi = (int)(machine.cadence * ligne.nombreConditionnements * multiplicateur);

                    if (ligne.nomBonbon != machine.tete)
                    {
                        resultat += machine.delai;
                        machine.tete = ligne.nomBonbon;
                        // On vérifie qu'il ne s'agisse pas d'une machine double
                        // Si c'est une machine double, on change également l'attribut tête de sa ou ses paires
                        foreach (Machine machinesMultiples in machines)
                        {
                            if (machinesMultiples.idMachine == machine.idMachine)
                            {
                                machinesMultiples.tete = ligne.nomBonbon;
                            }
                        }
                    }
                    dictionnaire[machine.idMachine] += resultat;
                    resultat = 0;
                }
            }

            // On met le temps du chemin critique dans le resultat
            foreach (KeyValuePair<int, double> kvp in dictionnaire)
            {
                if (resultat < kvp.Value)
                {
                    resultat = kvp.Value;
                }
            }

            // on clean les lignes associées aux machines
            foreach (Machine machine in machines)
            {
                machine.machineQueue = new List<LigneDeCommande>();
                machine.queueTaille = 0;
            }
            commande.tempsCond = resultat;

            return resultat;
        }

        public static void simulerPickingCommande(Commande commande)
        {
            Random rnd = new Random();
            List<int> listGare = new List<int>();
            int lastGare = 0;
            int x = 0;
            int tmpCommande = 40;

            for (int i = 1; i < commande.nbLignes; i++)
            {
                // On choisi autant de gare qu'il y a de ligne de commande aléatoiremant
                listGare.Add(rnd.Next(1, 41));
            }
            // on les trie par ordre croissant
            listGare.Sort();

            // On parcours les différentes gare de destination
            foreach(int gare in listGare)
            {
                // Si on est dans le premier pole de gare
                if (gare < 21)
                {
                    if(x == 0) // première ligne de commande
                    {
                        tmpCommande += gare * 20 + 10;
                    }else
                    {
                        // On calcul le temps entre la gare de destination et la précédente
                        tmpCommande += (gare - lastGare) * 20 + 10;
                    }
                    
                }else
                {
                    if (x == 0) // première ligne de commande
                    {
                        tmpCommande += 20 + 80 + gare * 20 + 10;
                    }else
                    {
                        if(lastGare < 21)
                        {
                            // On calcul le temps entre le pole précédent et le suivant et la gare de destination et la précédente
                            tmpCommande += 80 + (gare - lastGare) * 10 + 10;
                        }else
                        {
                            // On calcul le temps entre la gare de destination et la précédente
                            tmpCommande += (gare - lastGare) * 10 + 10;
                        }
                    }

                    
                }
                lastGare = gare;
                x++;
                
            }
            // On ajoute le temsp de sorti du picking
            if (lastGare < 21)
            {
                tmpCommande += (20 - lastGare) * 20 + 40;
            }else
            {
                tmpCommande += (40 - lastGare) * 20 + 40;
            }
                
                

            commande.tempsPicking = tmpCommande;

        }
    }
}
