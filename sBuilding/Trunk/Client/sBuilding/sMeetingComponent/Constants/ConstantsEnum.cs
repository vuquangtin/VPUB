
namespace sMeetingComponent.Constants
{
    public class ConstantsEnum
    {
        public static int positionIndexCol = 2;
        public int positionIndexForPrint = 6;

        private static ConstantsEnum instance = new ConstantsEnum();
        public static ConstantsEnum Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConstantsEnum();
                }
                return instance;
            }
        }

        public ConstantsEnum() { }
        public int setPositionIndex(int index)
        {
            return this.positionIndexForPrint = index;
        }
    }
}
