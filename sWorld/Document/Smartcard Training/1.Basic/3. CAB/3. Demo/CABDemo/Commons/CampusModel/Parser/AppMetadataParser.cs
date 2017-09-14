using CampusModel.Model;
using System;
using System.Collections.Generic;

namespace CampusModel.Parser
{
    public class AppMetadataParser
    {
        public const int StartPositionOnHeader = 8;
        public const int AppMetadataLength = 5;  // in bytes

        public static List<AppMetadataDto> ToAppMetadataList(byte[] headerData)
        {
            if (headerData == null || headerData.Length != 48)
            {
                throw new ArgumentException("headerData");
            }

            List<AppMetadataDto> result = new List<AppMetadataDto>();

            for (int i = StartPositionOnHeader; i < headerData.Length; i += AppMetadataLength)
            {
                byte[] metadata = new byte[AppMetadataLength];
                Array.Copy(headerData, i, metadata, 0, AppMetadataLength);

                if (metadata[0] == 0)
                {
                    return result;
                }
                result.Add(new AppMetadataDto
                {
                    AppAlias = metadata[0],
                    KeyAlias = metadata[1],
                    MaxSectorUsed = metadata[2],
                    StartSectorNumber = metadata[3],
                });
            }
            return result;
        }

        public static AppMetadataDto GetTeacherAppProfile(byte[] headerData)
        {
            if (headerData == null || headerData.Length != 48)
            {
                throw new ArgumentException("headerData");
            }

            for (int i = StartPositionOnHeader; i < headerData.Length; i += AppMetadataLength)
            {
                byte[] metadata = new byte[AppMetadataLength];
                Array.Copy(headerData, i, metadata, 0, AppMetadataLength);

                if (metadata[0] == 0)
                {
                    return null;
                }
                if (metadata[0] == 1)
                {
                    return new AppMetadataDto
                    {
                        AppAlias = metadata[0],
                        KeyAlias = metadata[1],
                        MaxSectorUsed = metadata[2],
                        StartSectorNumber = metadata[3],
                    };
                }
            }
            return null;
        }
    }
}
