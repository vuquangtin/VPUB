using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sAccessControl.View
{
    internal partial class UsrCameraCanvas : UserControl
    {
        public event EventHandler StartRequested;
        public event EventHandler StopRequested;

        public UsrCameraCanvas()
        {
            InitializeComponent();

            tsmiStart.Click += tsmiStart_Click;
            tsmiStop.Click += tsmiStop_Click;
        }

        public string Message
        {
            set
            {
                if (!IsHandleCreated)
                {
                    return;
                }
                if (InvokeRequired)
                {
                    Invoke(new Action(() => { lblMessage.Text = value; }));
                }
                else
                {
                    lblMessage.Text = value;
                }
            }
        }

        private void tsmiStart_Click(object sender, EventArgs e)
        {
            if (StartRequested != null)
            {
                StartRequested(this, EventArgs.Empty);
            }
        }

        private void tsmiStop_Click(object sender, EventArgs e)
        {
            if (StopRequested != null)
            {
                StopRequested(this, EventArgs.Empty);
            }
        }
    }
}
