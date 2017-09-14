using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReaderManager.Pcsc;

namespace ReaderManager.Reader.Pcsc
{
    public interface IDesfine
    {
        bool Authentication(CardManager cm, byte keyno);
        bool ChangeKeySettings(CardManager cm, byte[] aid, byte keysetting);
        byte[] GetKeySettings(CardManager cm);
        bool ChangeKey(CardManager cm, byte[] keys);
        byte[] GetKeyVersion(CardManager cm, byte keyno);

        //APPLICATION COMMAND
        bool CreateApplication(CardManager cm, byte[] aid, byte keysetting, byte keynumber);
        bool DeleteApplication(CardManager cm, byte[] aid);
        byte[] GetApplicationIDs(CardManager cm);
        bool SelectApplication(CardManager cm, byte[] aid);
        bool FormatPICC(CardManager cm);
        byte[] GetVersion(CardManager cm);

        // FILE COMMAND
        byte[] GetFileIDs(CardManager cm);
        byte[] GetFileSettings(CardManager cm, byte fileno);
        void ChangeFileSettings(CardManager cm);
        bool CreadStandardDataFile(CardManager cm, byte fileno, byte comset, byte[] accessright, byte[] filesize);
        bool CreateBackupFile(CardManager cm, byte fileno, byte comset, byte[] accessright, byte[] filesize);
        bool CreateValueFile(CardManager cm, byte[] aid, byte fileno, byte comset, byte[] accessright, byte[] filesize, byte[] lowerlimit, byte[] upperlimit, byte[] value, byte creditenable, int lenght);


        bool CreateLinearRecordFile(CardManager cm, byte fileno, byte comset, byte[] accessright, byte[] recordsize, byte[] maxnumofrecord, int lenght);
        bool CreateCyclicRecordFile(CardManager cm, byte fileno, byte comset, byte[] accessright, byte[] recordsize, byte[] maxnumofrecord, int lenght);
        bool DeleteFile(CardManager cm, byte fid);
        

        //DATA COMMAND
        byte[] ReadData(CardManager cm, byte fino, byte[] offset, byte[] datasize);
        
        void WriteData(CardManager cm, byte[] aid, byte fid, byte[] data, int lenght);

        byte[] GetValue(CardManager cm, byte[] aid, byte fid);
        void SetCredit(CardManager cm, byte[] aid, byte fid, byte data);

        void SetLimitedCredit(CardManager cm, byte[] aid, byte fid, byte data);

        void WriteRecord(CardManager cm, byte[] aid, byte fid, byte[] data, int lenght);

        byte[] ReadRecord(CardManager cm, byte[] aid, byte fid);

        void ClearRecordFile(CardManager cm, byte[] aid, byte fid);
        
    }
}
