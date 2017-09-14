using CampusModel.Model;
using System.Collections.Generic;

namespace CampusModel.Parser
{
    public class HeaderDataParser
    {
        public static byte[] ToByteArray(byte hmkAlias, byte dmkAlias, List<AppMetadataDto> appList)
        {
            byte[] result = new byte[48];
            result[0] = hmkAlias;
            result[1] = dmkAlias;

            int i = AppMetadataParser.StartPositionOnHeader;
            foreach (var app in appList)
            {
                app.GetAppMetadataBytes().CopyTo(result, 1);
                i += app.MaxSectorUsed;
            }

            return result;
        }
    }
}
