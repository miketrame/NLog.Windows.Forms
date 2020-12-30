﻿using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using NLog;
using NLog.Windows.Forms;

namespace TestApplicationCore3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
            Logger.Info("Init");

            RichTextBoxTarget.ReInitializeAllTextboxes(this);

            var thread = new Thread(() =>
            {
                Random rnd = new Random();
                for (int i = 0; i < 10; i++)
                {
                    LogEventInfo theEvent = new LogEventInfo(LogLevel.Debug, "", i + ": a line with some length\n a new line");
                    Logger.Log(theEvent);
                    Thread.Sleep(200);
                }
                Logger.Info("Done");
            });
            Logger.Info("start thread");
            thread.Start();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
