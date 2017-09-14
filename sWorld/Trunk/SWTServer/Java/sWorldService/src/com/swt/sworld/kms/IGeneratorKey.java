package com.swt.sworld.kms;

import com.swt.sworld.communication.customer.object.SectorKeyPairDTO;

public interface IGeneratorKey {

	
	SectorKeyPairDTO deriveSectorPairKeyWithKeyADefault(byte sectornumber, byte[] serialnumber);
	SectorKeyPairDTO deriveDataSectorKeyPair(byte sectornumber, byte[] serialnumber);
	
	SectorKeyPairDTO deriveSectorKeyA(byte sectornumber, byte[] serialnumber);
	SectorKeyPairDTO deriveSectorKeyB(byte sectornumber, byte[] serialnumber);

	void setHeaderMasterKeyBytes(String key);
	void setDataMasterKeyABytes(String key);
	void setDataMasterKeyBBytes(String key);
	
	String encryptDataByHexXmlPubKey(String keyEncript, byte[] plaintext);
	byte[] encryptDataByHexXmlPubKeyB(String keyEncript, byte[] plaintext);
	String encryptDataByValueKey(String keyEncript, byte[] plaintext);

	
	//String createCardLicenseByPriKeyHexXml(String keyEncript, byte[] plaintext);
	//String desCreateCardLicenseByPubKeyHexXml(String keyDecript, byte[] plaintext);
	
	//String createCardLicenseByPriKeyXml(String keyEncript, byte[] plaintext);
	//String desCreateCardLicenseByPubKeyXml(String keyDecript, byte[] plaintext);
	

}
