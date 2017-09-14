using sWorldModel.Exceptions;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CommonControls.Custom
{
    public partial class ResultDialog : CommonDialog
    {
        private DataTable dtbResult;

        private const string DefaultMessage = "Tác vụ đã hoàn tất, vui lòng kiểm tra lại kết quả trong danh sách bên dưới.";
        private int startupHeaderHeight;

        private static ResultDialog instance = null;
        private static object lob = new object();

        private const string SUCCESS = "Thành công";
        private const string FAILED = "Thất bại";

        private ResultDialog()
        {
            InitializeComponent();

            dtbResult = new DataTable();
            dtbResult.Columns.Add(colSubject.DataPropertyName);
            dtbResult.Columns.Add(colAction.DataPropertyName);
            dtbResult.Columns.Add(colResult.DataPropertyName);
            dtbResult.Columns.Add(colDetail.DataPropertyName);
            this.dgvResult.DataSource = dtbResult;

            this.KeyDown += KeyDownHandler;
            foreach (Control c in this.Controls)
            {
                c.KeyDown += KeyDownHandler;
            }
        }

        public static ResultDialog Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lob)
                    {
                        if (instance == null)
                        {
                            instance = new ResultDialog();
                            instance.startupHeaderHeight = instance.dgvResult.ColumnHeadersHeight;
                        }
                    }
                }
                else
                {
                    instance.dgvResult.ColumnHeadersHeight = instance.startupHeaderHeight;
                    instance.dtbResult.Rows.Clear();

                    instance.colSubject.HeaderText = "Đối Tượng";
                    instance.colSubject.Width = 125;
                    instance.colSubject.Visible = true;

                    instance.colAction.HeaderText = "Hành Động";
                    instance.colAction.Width = 200;
                    instance.colAction.Visible = false;

                    instance.colResult.HeaderText = "Kết Quả";
                    instance.colResult.Width = 125;
                    instance.colResult.Visible = true;

                    instance.colDetail.HeaderText = "Chi Tiết";
                    instance.colDetail.Width = 200;
                    instance.colDetail.Visible = true;
                }

                return instance;
            }
        }

        public void ChangeDataSource(List<MethodResultDto> source)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<List<MethodResultDto>>(ChangeDataSource), source);
                return;
            }

            dtbResult.Rows.Clear();

            foreach (MethodResultDto s in source)
            {
                DataRow row = dtbResult.NewRow();
                row.BeginEdit();

                row[colSubject.DataPropertyName] = s.Subject;
                row[colAction.DataPropertyName] = s.Action;
                row[colResult.DataPropertyName] = s.Result ? "Thành công" : "Thất bại";
                if (!string.IsNullOrEmpty(s.Detail))
                {
                    sWorldException ex = sWorldExceptionUtils.Deserialize(s.Detail);
                    row[colDetail.DataPropertyName] = ErrorCodes.GetErrorMessage(ex.Code);
                }

                row.EndEdit();
                dtbResult.Rows.Add(row);
            }

            dgvResult.DataSource = null;
            dgvResult.DataSource = dtbResult;
            dgvResult.Refresh();
        }

        public void HideColumn(int columnIndex)
        {
            dgvResult.Columns[columnIndex].Visible = false;
        }

        public void ChageColumnTitle(int columnIndex, string title)
        {
            dgvResult.Columns[columnIndex].HeaderText = title;
        }

        public void ChangeColumnWidth(int columnIndex, int width)
        {
            dgvResult.Columns[columnIndex].Width = width;
        }

        private void KeyDownHandler(object s, KeyEventArgs e)
        {
            //Đóng hộp thoại nếu người dùng nhấn ESCAPE
            if (e.KeyCode == Keys.Escape)
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => { this.Hide(); }));
                }
                else
                {
                    this.Hide();
                }
            }
        }
    }
}