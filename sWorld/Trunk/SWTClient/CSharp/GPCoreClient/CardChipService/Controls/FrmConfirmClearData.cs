using CommonControls.Custom;

namespace CardChipMgtComponent.WorkItems
{
    public partial class FrmConfirmClearData : CommonDialog
    {
        public bool NotShowMore
        {
            get { return cbxDontAskLater.Checked; }
        }

        public FrmConfirmClearData()
        {
            InitializeComponent();
        }


    }
}
