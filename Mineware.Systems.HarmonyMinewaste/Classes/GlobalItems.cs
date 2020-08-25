using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Mineware.Systems.Minewaste
{
    public class GlobalItems
    {

        public delegate void EventNotificationDone(object sender, EventNotificationDoneArg e);

        public class EventNotificationDoneArg : EventArgs
        {
            public EventNotificationDoneArg(int thePos)
            {
                ThePos = thePos;
            }
            public int ThePos { get; set; }
        }

        //private static int m_Prod = 0;
        //private static string m_Prod2 = "";

        //public static int Prod { get { return m_Prod; } set { m_Prod = value; } }
        //public static string Prod2 { get { return m_Prod2; } set { m_Prod2 = value; } }

        public string Prod2 = "";
        public int Prod = 0;

        public void ProdMonthCalc(int ProdMonth1)
        {
            //int Prod;
            Decimal month = Convert.ToDecimal(ProdMonth1);
            String PMonth = month.ToString();
            PMonth.Substring(4, 2);
            if (Convert.ToInt32(PMonth.Substring(4, 2)) > 12)
            {
                int M = Convert.ToInt32(PMonth.Substring(0, 4));
                M++;
                PMonth = M.ToString();
                PMonth = PMonth + "01";
                ProdMonth1 = Convert.ToInt32(PMonth);
            }
            else
            {
                if (Convert.ToInt32(PMonth.Substring(4, 2)) < 1)
                {
                    int M = Convert.ToInt32(PMonth.Substring(0, 4));
                    M--;
                    PMonth = M.ToString();
                    PMonth = PMonth + "12";
                    ProdMonth1 = Convert.ToInt32(PMonth);
                }
            }
            Prod = ProdMonth1;
        }


        public void ProdMonthVis(int ProdMonth1)
        {


            Prod2 = ProdMonth1.ToString().Substring(0, 4);

            if (ProdMonth1.ToString().Substring(4, 2) == "01")
            {
                Prod2 = "Jan-" + Prod2;
            }

            if (ProdMonth1.ToString().Substring(4, 2) == "02")
            {
                Prod2 = "Feb-" + Prod2;
            }

            if (ProdMonth1.ToString().Substring(4, 2) == "03")
            {
                Prod2 = "Mar-" + Prod2;
            }

            if (ProdMonth1.ToString().Substring(4, 2) == "04")
            {
                Prod2 = "Apr-" + Prod2;
            }

            if (ProdMonth1.ToString().Substring(4, 2) == "05")
            {
                Prod2 = "May-" + Prod2;
            }

            if (ProdMonth1.ToString().Substring(4, 2) == "06")
            {
                Prod2 = "Jun-" + Prod2;
            }

            if (ProdMonth1.ToString().Substring(4, 2) == "07")
            {
                Prod2 = "Jul-" + Prod2;
            }

            if (ProdMonth1.ToString().Substring(4, 2) == "08")
            {
                Prod2 = "Aug-" + Prod2;
            }

            if (ProdMonth1.ToString().Substring(4, 2) == "09")
            {
                Prod2 = "Sep-" + Prod2;
            }

            if (ProdMonth1.ToString().Substring(4, 2) == "10")
            {
                Prod2 = "Oct-" + Prod2;
            }

            if (ProdMonth1.ToString().Substring(4, 2) == "11")
            {
                Prod2 = "Nov-" + Prod2;
            }

            if (ProdMonth1.ToString().Substring(4, 2) == "12")
            {
                Prod2 = "Dec-" + Prod2;
            }
        }

        //extracts the string value before the colon
        public string ExtractBeforeColon(string TheString)
        {
            if (TheString != "")
            {
                string BeforeColon;

                int index = TheString.IndexOf(":");

                BeforeColon = TheString.Substring(0, index);

                return BeforeColon;
            }
            else
            {
                return "";
            }
        }


       

        //extracts the string value after the colon
        public string ExtractAfterColon(string TheString)
        {
            string AfterColon;

            int index = TheString.IndexOf(":"); // Kry die postion van die :

            AfterColon = TheString.Substring(index + 1); // kry alles na :

            return AfterColon;
        }




    }
}
