using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.PieChart;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CardMagneticMgtComponent.WorkItems
{
    public partial class FrmPieChartSetup : CommonControls.Custom.CommonDialog
    {
        private static FrmPieChartSetup instance;

        public FrmPieChartSetup()
        {
            InitializeComponent();
            DataTable dtblTypes = new DataTable();
            dtblTypes.Columns.Add("Id");
            dtblTypes.Columns.Add("Name");

            List<EdgeColorType> types = EdgeColorTypeExtMethods.GetAll();
            types.Sort((x, y) => { return x.GetName().CompareTo(y.GetName()); });
            foreach (EdgeColorType t in types)
            {
                DataRow drow = dtblTypes.NewRow();
                drow.BeginEdit();

                drow["Id"] = (int)t;
                drow["Name"] = t.GetName();

                drow.EndEdit();
                dtblTypes.Rows.Add(drow);
            }
            cmbEdgeType.DisplayMember = "Name";
            cmbEdgeType.ValueMember = "Id";
            cmbEdgeType.DataSource = dtblTypes;
        }

        public static FrmPieChartSetup Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FrmPieChartSetup();
                }
                return instance;
            }
        }

        public Padding ChartMargin
        {
            get
            {
                return new Padding((int)tbxLeftMargin.Value, (int)tbxTopMargin.Value, (int)tbxRightMargin.Value, (int)tbxBottomMargin.Value);
            }
            set
            {
                tbxLeftMargin.Value = value.Left;
                tbxTopMargin.Value = value.Top;
                tbxRightMargin.Value = value.Right;
                tbxBottomMargin.Value = value.Bottom;
            }
        }

        public ShadowStyle ChartShadowStyle
        {
            get
            {
                if (rbtnShadowStyleGradualPieChartSetup.Checked)
                {
                    return ShadowStyle.GradualShadow;
                }
                else if (rbtnShadowStyleUniformPieChartSetup.Checked)
                {
                    return ShadowStyle.UniformShadow;
                }
                else
                {
                    return ShadowStyle.NoShadow;
                }
            }
            set
            {
                switch (value)
                {
                    case ShadowStyle.GradualShadow:
                        rbtnShadowStyleGradualPieChartSetup.Checked = true;
                        break;
                    case ShadowStyle.NoShadow:
                        rbtnShadowStyleNonePieChartSetup.Checked = true;
                        break;
                    case ShadowStyle.UniformShadow:
                        rbtnShadowStyleUniformPieChartSetup.Checked = true;
                        break;
                }
            }
        }

        public float ChartHeight
        {
            get
            {
                return (float)tbxPieHeight.Value;
            }
            set
            {
                tbxPieHeight.Value = (decimal)value;
            }
        }

        public float EdgeLineWidth
        {
            get
            {
                return (float)tbxEdgeLineWidth.Value;
            }
            set
            {
                tbxEdgeLineWidth.Value = (decimal)value;
            }
        }

        public float ChartAngle
        {
            get
            {
                return (float)tbxAngle.Value;
            }
            set
            {
                tbxAngle.Value = (decimal)value;
            }
        }

        public EdgeColorType EdgeColorType
        {
            get
            {
                return (EdgeColorType)Convert.ToInt32(cmbEdgeType.SelectedValue);
            }
            set
            {
                cmbEdgeType.SelectedValue = (int)value;
            }
        }
    }

    public static class EdgeColorTypeExtMethods
    {
        public static List<EdgeColorType> GetAll()
        {
            return Enum.GetValues(typeof(EdgeColorType)).Cast<EdgeColorType>().ToList();
        }

        public static string GetName(this EdgeColorType type)
        {
            switch (type)
            {
                case EdgeColorType.LighterThanSurface:
                    return "Màu sáng 1";
                case EdgeColorType.LighterLighterThanSurface:
                    return "Màu sáng 2";
                case EdgeColorType.DarkerThanSurface:
                    return "Màu tối 1";
                case EdgeColorType.DarkerDarkerThanSurface:
                    return "Màu tối 2";
                case EdgeColorType.Contrast:
                    return "Tương phản 1";
                case EdgeColorType.EnhancedContrast:
                    return "Tương phản 2";
                case EdgeColorType.FullContrast:
                    return "Tương phản 3";
                case EdgeColorType.NoEdge:
                    return "Không có cạnh";
                case EdgeColorType.SurfaceColor:
                    return "Cùng màu với bề mặt";
                case EdgeColorType.SystemColor:
                    return "Mặc định";
                default:
                    return "N/A";
            }
        }
    }
}
