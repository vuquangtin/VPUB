using CommonHelper.Constants;
using CommonHelper.Utils;
using sWorldModel;
using System;
using System.Resources;
using System.Windows.Forms;

namespace CommonControls.Custom
{
    public partial class PagerPanel : CommonUserControl
    {
        public event LinkLabelClickedHandler LinkLabelClicked;

        public const string LabelNextText = ">>";
        public const string LabelBackText = "<<";
        private ResourceManager rm;
        private ILocalStorageService storageService;
        public ILocalStorageService StorageService
        {
            set
            {
                storageService = value;
            }
        }
        public  PagerPanel()
        {
            InitializeComponent();
        }
        /// <summary>
        /// load language for all controls in control
        /// </summary>
        public void LoadLanguage()
        {
            rm = storageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
        }

        /// <summary>
        /// Re-create paging link labels
        /// </summary>
        /// <param name="numTotalRecords">Total records</param>
        /// <param name="numRecordsPerPage">Number of records per page</param>
        /// <param name="currentPageIndex">One-based index of current page</param>
        public void UpdatePagingLinks(int numTotalRecords, int numRecordsPerPage, int currentPageIndex)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int, int, int>(UpdatePagingLinks), numTotalRecords, numRecordsPerPage, currentPageIndex);
                return;
            }

            // Clear existing page link label
            tblLinks.Controls.Clear();

            // Calculate number of pages
            int numTotalPage = numTotalRecords / numRecordsPerPage;
            if ((numTotalRecords % numRecordsPerPage) > 0)
            {
                numTotalPage++;
            }

            // Create page link label
            if (numTotalPage == 0)
            {
                lblPageResult.Visible = false;
                return;
            }
            else
            {
                lblPageResult.Visible = true;

                // Create next link
                if (currentPageIndex < numTotalPage)
                {
                    LinkLabel nextLabel = CreatePageLinkLabel(">>");
                    tblLinks.Controls.Add(nextLabel, 6, 0);
                }

                // Create page link
                if (currentPageIndex < 5)
                {
                    for (int i = numTotalPage; i > 0; i--)
                    {
                        if (currentPageIndex == i)
                        {
                            Label label = CreatePageLabel(i.ToString());
                            tblLinks.Controls.Add(label, i, 0);
                        }
                        else
                        {
                            LinkLabel label = CreatePageLinkLabel(i.ToString());
                            tblLinks.Controls.Add(label, i, 0);
                        }
                    }
                }
                else
                {
                    int j = 1;
                    for (int i = currentPageIndex - 2; i <= currentPageIndex + 2; i++)
                    {
                        if (i > numTotalPage)
                        {
                            break;
                        }
                        else if (currentPageIndex == i)
                        {
                            Label label = CreatePageLabel(i.ToString());
                            tblLinks.Controls.Add(label, j++, 0);
                        }
                        else
                        {
                            LinkLabel label = CreatePageLinkLabel(i.ToString());
                            tblLinks.Controls.Add(label, j++, 0);
                        }
                    }
                }

                // Create back link
                if (currentPageIndex > 1)
                {
                    LinkLabel backLabel = CreatePageLinkLabel("<<");
                    tblLinks.Controls.Add(backLabel, 0, 0);
                }
            }
        }

        private Label CreatePageLabel(string text)
        {
            Label label = new Label();
            label.Text = text;
            label.Dock = DockStyle.Fill;
            label.Width = 30;
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            return label;
        }

        private LinkLabel CreatePageLinkLabel(string text)
        {
            LinkLabel label = new LinkLabel();
            label.Text = text;
            label.Dock = DockStyle.Fill;
            label.Width = 30;
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label.Click += (s, e) =>
                {
                    if (LinkLabelClicked != null)
                    {
                        LinkLabelClicked(this, new LinkLabelClickedArgs(label.Text));
                    }
                };
            return label;
        }

        public void ShowMessage(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(ShowMessage), text);
            }
            lblMessage.Text = text;
        }

        public void ShowNumberOfRecords(int numTotalRecords, int numDisplayRecords, int numRecordsPerPage, int currentPageIndex)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int, int, int, int>(ShowNumberOfRecords), numTotalRecords, numDisplayRecords, numRecordsPerPage, currentPageIndex);
                return;
            }
            if (numTotalRecords == 0 || numDisplayRecords == 0)
            {
                lblMessage.Text = string.Empty;
                return;
            }
            int t = (currentPageIndex - 1) * numRecordsPerPage;
            lblMessage.Text = string.Format(MessageValidate.GetCurrentPage(rm), numDisplayRecords, t + 1, t + numDisplayRecords, numTotalRecords);
        }
    }

    public delegate void LinkLabelClickedHandler(object sender, LinkLabelClickedArgs e);

    public class LinkLabelClickedArgs : EventArgs
    {
        public string LabelText { get; private set; }

        public LinkLabelClickedArgs(string labelText)
        {
            this.LabelText = labelText;
        }
    }
}
