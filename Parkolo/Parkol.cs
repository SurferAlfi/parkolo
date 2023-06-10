using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkolo
{
    enum PKategoria { Dolgozó, Vendég, Mozgássérült }
    internal class Parkol
    {
        private int erkezes;
        private int tavozas;
        private string rsz;
        private PKategoria pk;
        public Parkol(string sor)
        {
            string[] d = sor.Split();
            erkezes = int.Parse(d[1]);
            tavozas = int.Parse(d[2]);
            switch (d[3])
            {
                case "D":
                    pk = PKategoria.Dolgozó;
                    break;
                case "V":
                    pk = PKategoria.Vendég;
                    break;
                case "M":
                    pk = PKategoria.Mozgássérült;
                    break;
                default:
                    break;
            }
            rsz = d[4];
        }
        public string Rsz
        {
            get { return rsz; }
            set
            {
                if (value.Length == 7 && value[3] == '-')
                    rsz = value;
            }
        }
        public int ParkolasiIdo
        {
            get
            {
                int parkido = tavozas - erkezes;
                if (parkido > 0)
                    return parkido;
                return 0;
            }
        }
        public int Fizetes()
        {
            int parkido = 0;
            switch (pk)
            {
                case PKategoria.Dolgozó:
                case PKategoria.Mozgássérült:
                    parkido = 0;
                    break;
                case PKategoria.Vendég:
                    if (ParkolasiIdo < 700)
                        parkido = 0;
                    else
                        parkido = (ParkolasiIdo / 3600 + 1)*300;
                        //vagy egészre kerekítés felfelé (így az egész órákkal is jól dolgozik)
                        //parkido = (int)(Math.Ceiling((double)ParkolasiIdo / 3600) * 300);
                    break;
            }
            return parkido;
        }
        public override string ToString()
        {
            return string.Format($"{rsz} {erkezes}-{tavozas} * {ParkolasiIdo} * {Fizetes()} Ft # {pk}");
        }
    }
}
