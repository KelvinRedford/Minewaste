using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mineware.Systems.Minewaste
{
    public class Record
    {
        private string DATE;
        private string ID;
        private string DUMP;
        private string DAM;
        private string GUN;
        private string BENCH;
        private string DIRECTION;
        private string POSITION;
        private string STREAM;
        private string DURATION;
        private string RATE;
        private string START;
        private string FINNISH;
        private string AU;
        private string TONNES;
        private string KG;
        private string KGREC;

        public string Dates
        {
            get { return DATE; }
            set { DATE = value; }
        }

        public string IDs
        {
            get { return ID; }
            set { ID = value; }
        }

        public string Dumps
        {
            get { return DUMP; }
            set { DUMP = value; }
        }

        public string Dams
        {
            get { return DAM; }
            set { DAM = value; }
        }

        public string Guns
        {
            get { return GUN; }
            set { GUN = value; }
        }

        public string Benchs
        {
            get { return BENCH; }
            set { BENCH = value; }
        }

        public string Directions
        {
            get { return DIRECTION; }
            set { DIRECTION = value; }
        }

        public string Positions
        {
            get { return POSITION; }
            set { POSITION = value; }
        }

        public string Streams
        {
            get { return STREAM; }
            set { STREAM = value; }
        }

        public string Durations
        {
            get { return DURATION; }
            set { DURATION = value; }
        }

        public string Rates
        {
            get { return RATE; }
            set { RATE = value; }
        }

        public string Starts
        {
            get { return START; }
            set { START = value; }
        }

        public string Finnishs
        {
            get { return FINNISH; }
            set { FINNISH = value; }
        }

        public string AUs
        {
            get { return AU; }
            set { AU = value; }
        }

        public string Tonness
        {
            get { return TONNES; }
            set { TONNES = value; }
        }

        public string KGs
        {
            get { return KG; }
            set { KG = value; }
        }

        public string RecievedKgs
        {
            get { return KGREC; }
            set { KGREC = value; }
        }     
    }

}
