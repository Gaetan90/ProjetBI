using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateurPalaisDuBonbon
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Commande> pool = GenerateurPalaisDuBonbon.Generateur.PoolCreation();
        }
    }
}
