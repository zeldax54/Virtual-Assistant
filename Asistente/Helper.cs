using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Asistente
{
    public static class Helper
    {

        public static string[] PasilloEstante(string var)
        {
            string temp = var.Remove(0, 25);
            string tempnum = "";
            int s = 0;
            if (int.TryParse(temp[0].ToString(), out s))
            {
                foreach (char l in temp)
                {
                    if (!IsLetra(l)|| l=='.')
                        tempnum += l;
                    else
                        break;
                }
                return tempnum.Split('.');
            }
            return null;
        }


        private static bool IsLetra(char l)
        {
            if (l == 32)
                return true;
            for (char i = 'A'; i <='Z'; i++)
            {
                if (l == i)
                    return true;
            }
            return false;
        }
    }
}
