using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Asistente
{
    public static class FormStuffs
    {

        public static void ShowMensaje(string message)
        {
            MessageBox.Show(message, @"Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

    }
}
