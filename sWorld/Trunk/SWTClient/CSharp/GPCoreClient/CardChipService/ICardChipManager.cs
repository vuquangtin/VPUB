using ReaderManager;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardChipService
{
    public interface ICardChipManager
    {
        // master
        bool RsaVerifiedMasterLicenseServerHexValue(string licenserver);
        bool RsaVerifiedLicenseMaster(byte start, byte stop, out string msg);
        byte[] decryptData(string algorithmName, byte[] data, string keycode);
        //partner
        bool RsaVerifiedPartnerLicenseServerHexValue(string licenserver);
        bool RsaVerifiedLicensePartner(byte start, byte stop, out string msg);

        //relatied license
        bool HasPartner(byte[] headerdata);
        bool WriteLicenseData(byte start, byte stop, ResultCheckCardDTO resultKeyPair, out String msg);
        bool WriteHeaderData(bool IsMaster, List<KeyDTO> keydata, out string msg);
        bool ReadHeaderData(out byte[] headerData, out string msg);
        bool UpdateHeaderData(byte[] headerData, byte[] headerKeyB, out string msg);

       
        List<int> NeedRequestKeyReadData(byte[] headerdata);
        bool WriteAppData(DataToWriteCardDTO keydata, out string msg);
        bool WritePersoData(DataToWriteCardDTO keydata, out string msg);

        bool ReadAppData(DataToReadCardDTO keydata, byte[] headerData, out byte[] appdata, out string msg);
        bool ReadPersoData(DataToReadCardDTO keydata, byte[] headerData, out byte[] carddata, out string msg);

        bool ClearAppData(DataToWriteCardDTO keydata, out string msg);
        bool ClearPersoData(DataToWriteCardDTO keydata, out string msg);
         

        void IdentifyBeginSectorFromHeaderData(byte[] headerData, out byte sectorBegin, out byte sectorEnd);

        bool ClearUpAllData(DataToWriteCardDTO keydata, out string msg, bool isPartner);

        void SetReader(IReader reader);

        void SetCardInfor(int cardType, byte[] data);

        bool WaitingCard(string name);

        bool Disconnect();

        List<string> FindAllCardReader();

        void Alert(bool flag);

        void SetFreesParking();

        /// <summary>
        /// delegate to return data to form
        /// </summary>
        event DelegateCardActionHandler ActionDataHandler;

        
    }
}
