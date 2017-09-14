using Microsoft.Practices.CompositeUI;
using CommonHelper.Constants;
using Microsoft.Practices.ObjectBuilder;

namespace PaletteComponent
{
    public class ComponentInit : ModuleInit
    {
        private WorkItem workItem;

        [InjectionConstructor]
        public ComponentInit([ServiceDependency]WorkItem workItem)
        {
            this.workItem = workItem;
        }

        public override void Load()
        {
            base.Load();

            UsrPaletteBar uc = workItem.Items.AddNew<UsrPaletteBar>(ComponentNames.PaletteComponent);
            workItem.Workspaces[WorkspaceName.PaletteWorkspace].Show(uc);
        }
    }
}