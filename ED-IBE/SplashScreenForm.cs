﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IBE.Enums_and_Utility_Classes;

namespace IBE
{
    public partial class SplashScreenForm : Form
    {
        System.Windows.Forms.Timer _CloseTimer;

        static SplashScreenForm SplashObject = null;

        public SplashScreenForm()
        {
            InitializeComponent();
            SplashInfo.Items.Add("");
            SplashObject = this;
        }

        public void InfoAdd(string Info)
        { 
            SplashInfo.Items.Insert(SplashInfo.Items.Count-1, Info);
            SplashInfo.SelectedIndex = SplashInfo.Items.Count-1;
            SplashInfo.SelectedIndex = -1;
            this.Refresh();
        }

        public void InfoChange(string Info)
        { 
            SplashInfo.Items[SplashInfo.Items.Count-2] = Info;
            SplashInfo.SelectedIndex = SplashInfo.Items.Count-1;
            SplashInfo.SelectedIndex = -1;
            this.Refresh();
        }

        public void InfoAppendLast(string Info)
        {
            SplashInfo.Items[SplashInfo.Items.Count - 2] += Info;
            SplashInfo.SelectedIndex = SplashInfo.Items.Count - 1;
            SplashInfo.SelectedIndex = -1;
            Refresh();
        }

        public void CloseDelayed()
        {
            _CloseTimer = new System.Windows.Forms.Timer();
            _CloseTimer.Tick += _CloseTimer_Tick;
            _CloseTimer.Interval = 1000;
            _CloseTimer.Start();
            this.Refresh();
        }

        void _CloseTimer_Tick(object sender, EventArgs e)
        {
            _CloseTimer.Dispose();
            this.Close();
        }

        internal void setPosition(WindowData windowData)
        {
            if((windowData != null) && (windowData.Position.Top >= 0))
            {
                System.Drawing.Rectangle rec_WA = Screen.FromRectangle(windowData.Position).WorkingArea;

                this.Location = new Point((Int32)(rec_WA.X + ((rec_WA.Width - this.Width) / 2)), (Int32)(rec_WA.Y + ((rec_WA.Height - this.Height) / 2)));
            }
        }
    }
}
