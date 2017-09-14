using System.Windows.Forms;
using System;
using CampusModel;
using Microsoft.Practices.CompositeUI;

namespace DemoComponent
{
    public partial class UcMain : UserControl
    {
        private WorkItem rootWorkItem = null;
        private IPersoService persoServiceProxy = null;

        [ServiceDependency]
        public WorkItem RootWorkItem
        {
            set
            {
                if (rootWorkItem == value)
                    return;
                rootWorkItem = value;
            }
        }

        public IPersoService PersoServiceProxy
        {
            get
            {
                if (persoServiceProxy == null)
                    persoServiceProxy = rootWorkItem.Services.Get<IPersoService>();
                return persoServiceProxy;
            }
        }

        public UcMain()
        {
            InitializeComponent();
            dropDownButton1.Text = "abccc";
            dropDownButton1.AddItem("Phát hành thẻ...",
                (sender, arg) => ShowMessageBox("Phát hành thẻ..."));
            dropDownButton1.AddItem("Cấp lại thẻ...",
                (sender, arg) => ShowMessageBox("Cấp lại thẻ..."));
            dropDownButton1.AddItem("Khóa lượt phát hành...",
                (sender, arg) => ShowMessageBox("Khóa lượt phát hành..."));
            dropDownButton1.AddItem("Mở khóa lượt phát hành...",
                (sender, arg) => ShowMessageBox("Mở khóa lượt phát hành..."));
            dropDownButton1.AddItem("Hủy lượt phát hành...",
                (sender, arg) => ShowMessageBox("Hủy lượt phát hành..."));

            dropDownButton2.AddItem("Phát hành thẻ...",
                (sender, arg) => ShowMessageBox("Phát hành thẻ..."));
            dropDownButton2.AddItem("Cấp lại thẻ...",
                (sender, arg) => ShowMessageBox("Cấp lại thẻ..."));
            dropDownButton2.AddItem("Khóa lượt phát hành...",
                (sender, arg) => ShowMessageBox("Khóa lượt phát hành..."));
            dropDownButton2.AddItem("Mở khóa lượt phát hành...",
                (sender, arg) => ShowMessageBox("Mở khóa lượt phát hành..."));
            dropDownButton2.AddItem("Hủy lượt phát hành...",
                (sender, arg) => ShowMessageBox("Hủy lượt phát hành..."));
        }

        private void ShowMessageBox(string text)
        {
            MessageBox.Show(text);
        }

      

       
    }
}
