using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV.UI;

namespace Asistente
{
    public class DataContainer
    {

        private static DataContainer oInstance;

        public ImageBox ImageBox { get; set; }
       
        protected DataContainer()
        {
        }

        public static DataContainer Instance()
        {

            if (oInstance == null)
                oInstance = new DataContainer();
            return oInstance;

        }


    }
}
