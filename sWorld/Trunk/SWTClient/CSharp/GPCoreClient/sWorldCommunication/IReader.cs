using System;
using System.Collections.Generic;
using System.Text;

namespace ReaderManager
{
    public interface IReader
    {
        void ConnectToReader(string readerAlias);

        void DisconnectFromReader();

        /// <summary>
        /// authentication sector
        /// </summary>
        /// <param name="sector"></param>
        /// <param name="isKeyA"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        bool Authenticate(byte sector, bool isKeyA, byte[] key);

        /// <summary>
        /// authentication default
        /// </summary>
        /// <param name="sector"></param>
        /// <returns></returns>
        bool AuthenticateDefault(byte sector);

        /// <summary>
        /// read data on block
        /// </summary>
        /// <param name="block"></param>
        /// <param name="blockData"></param>
        /// <returns></returns>
        bool ReadBlock(byte block, out byte[] blockData);

        /// <summary>
        /// read data on sector
        /// </summary>
        /// <param name="sector"></param>
        /// <param name="sectorData"></param>
        /// <returns></returns>
        bool ReadSector(byte sector, out byte[] sectorData);

        /// <summary>
        /// write data to block
        /// </summary>
        /// <param name="block"></param>
        /// <param name="blockData"></param>
        /// <returns></returns>
        bool WriteBlock(byte block, byte[] blockData);

        /// <summary>
        /// write data to sector
        /// </summary>
        /// <param name="sector"></param>
        /// <param name="sectorData"></param>
        /// <returns></returns>
        bool WriteSector(byte sector, byte[] sectorData);


        bool ReadLicense(byte beginsector, byte endsector, out byte[] license);

        /// <summary>
        /// validate data 
        /// </summary>
        /// <param name="firstSectorKeyA"></param>
        /// <returns></returns>
        bool IsSwtCard(byte[] firstSectorKeyA);

        /// <summary>
        /// read header data
        /// </summary>
        /// <param name="headerData"></param>
        /// <returns></returns>
        bool ReadHeader(out byte[] headerData);

        /// <summary>
        /// write data to sector key
        /// </summary>
        /// <param name="sector"></param>
        /// <param name="newKeyA"></param>
        /// <param name="newKeyB"></param>
        /// <param name="accessCondition"></param>
        /// <returns></returns>
        bool WriteSectorKeys(byte sector, byte[] newKeyA, byte[] newKeyB, byte[] accessCondition);

        /// <summary>
        /// write data key
        /// </summary>
        /// <param name="sector"></param>
        /// <param name="newKeyA"></param>
        /// <param name="newKeyB"></param>
        /// <returns></returns>
        bool WriteDataKeys(byte sector, byte[] newKeyA, byte[] newKeyB);

        /// <summary>
        /// write header key b
        /// </summary>
        /// <param name="newKeyB"></param>
        /// <returns></returns>
        bool WriteHeaderKeyB(byte sector, byte[] newKeyB);

        /// <summary>
        /// write default keys
        /// </summary>
        /// <param name="sector"></param>
        /// <returns></returns>
        bool WriteDefaultKeys(byte sector);

        /// <summary>
        /// clear data on sector
        /// </summary>
        /// <param name="sector"></param>
        /// <returns></returns>
        bool ClearSectorData(byte sector);
    }
}
