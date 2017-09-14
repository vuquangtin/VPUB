using Microsoft.Practices.CompositeUI;
using CommonHelper.Constants;

namespace DemoComponent
{
    public class ComponentInit : ModuleInit
    {
        private WorkItem rootWorkItem;

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

        public override void Load()
        {
            base.Load();

            //Khởi tạo user control và add vào danh sách work item
            //UcMain uc = rootWorkItem.Items.AddNew<UcMain>(ComponentName.DEMO_COMP);

            //Hiển thị user control vào vị trí MAIN_WORKSPACE trong MainForm
            //rootWorkItem.Workspaces[WorkspaceName.MAIN_WORKSPACE].Show(uc);
            //uc.Parent.Text = "Demo Component";
        }
    }
}
