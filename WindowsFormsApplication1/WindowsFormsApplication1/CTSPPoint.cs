﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class CTSPPoint
    {
        public float x = 0;
        public float y = 0;
        protected string mLabel;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="label">Label des Punktes</param>
        public CTSPPoint(string label = "")
        {
            mLabel = label;

            // es wurde ein Punkt erzeugt .. also ein Schritt erfolgreich abgearbeteitet
            CProgressManager.stepDone();
        }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="inX">X-Koordinate des Punktes</param>
        /// <param name="inY">Y-Koordinate des Punktes</param>
        /// <param name="label">Labes des Punktes</param>
        public CTSPPoint(float inX, float inY, string label = ""  )
        {
            x = inX;
            y = inY;
            mLabel = label;

            // es wurde ein Punkt erzeugt .. also ein Schritt erfolgreich abgearbeteitet
            CProgressManager.stepDone();
        }

        /// <summary>
        /// gibt das Label des Punktes zurück
        /// </summary>
        /// <returns>Label des Punktes</returns>
        public string getLabel()
        {
            return mLabel;
        }

        public void setLabel(string label)
        {
            mLabel = label;
        }

        public override string ToString()
        {
            return mLabel + " X=" + x + " Y=" + y + " ";
        }
    }
}
