﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Crosser - 2D animated game using classes and objects
// A. Ansari
// March 2023


namespace Crosser
{
    public partial class Form1 : Form
    {



        public Form1()
        {
            InitializeComponent();
            Form1.ChangeScreen(this, new MenuScreen());
        }

        public static void ChangeScreen(object sender, UserControl next)
        {
            Form f;
            if (sender is Form)
            {
                f = (Form)sender;
            }

            else
            {
                UserControl current = (UserControl)sender;
                f = current.FindForm();
                f.Controls.Remove(current);
            }

            next.Location = new Point((f.ClientSize.Width - next.Width) / 2, (f.ClientSize.Height - next.Height) / 2);

            f.Controls.Add(next);
            next.Focus();
        }
    }
}
