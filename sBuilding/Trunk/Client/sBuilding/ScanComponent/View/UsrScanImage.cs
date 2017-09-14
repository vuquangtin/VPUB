using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScanComponent.View {
    public partial class UsrScanImage : UserControl {

        public event EventHandler StartRequested;
        public event EventHandler StopRequested;

        public UsrScanImage() {
            InitializeComponent();

            miConnectScanner.Click += miConnectScanner_Click;
            miDisconnectScanner.Click += miDisconnectScanner_Click;
        }

        public string Message {
            set {
                if (!IsHandleCreated) {
                    return;
                }
                if (InvokeRequired) {
                    Invoke(new Action(() => { lblMessage.Text = value; }));
                } else {
                    lblMessage.Text = value;
                }
            }
        }

        public Image Image {
            set {
                if (!IsHandleCreated) {
                    return;
                }
                if (InvokeRequired) {
                    Invoke(new Action(() => { pbxImage.Image = value; }));
                } else {
                    pbxImage.Image = value;
                }
            }
        }

        public bool ShowImage {
            set {
                if (!IsHandleCreated) {
                    return;
                }
                if (InvokeRequired) {
                    Invoke(new Action(() => { pbxImage.Visible = value; }));
                } else {
                    pbxImage.Visible = value;
                }
            }
        }

        private void miConnectScanner_Click(object sender, EventArgs e) {
            // Connect to scanner
            StartRequested(this, EventArgs.Empty);
        }

        private void miDisconnectScanner_Click(object sender, EventArgs e) {
            // Disconnet scanner
            StopRequested(this, EventArgs.Empty);
        }
    }
}
