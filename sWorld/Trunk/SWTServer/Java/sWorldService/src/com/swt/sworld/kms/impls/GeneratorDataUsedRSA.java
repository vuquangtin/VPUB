package com.swt.sworld.kms.impls;

import java.util.HashMap;

import com.nhn.utilities.Converter;
import com.swt.sworld.communication.customer.object.SectorKeyPairDTO;
import com.swt.sworld.kms.IGeneratorKey;

public class GeneratorDataUsedRSA implements IGeneratorKey {
	private HashMap<Byte, byte[]> smkACache = new HashMap<Byte, byte[]>();
	private HashMap<Byte, byte[]> smkBCache = new HashMap<Byte, byte[]>();

	private final String DEFAUL_KEY_A = Converter.getInstance().byteArrayToHexString(
					new byte[] { (byte) 0xFF, (byte) 0xFF, (byte) 0xFF,
								 (byte) 0xFF, (byte) 0xFF, (byte) 0xFF });

	private byte[] headerMasterKeyBytes;
	private byte[] dataMasterKeyABytes;
	private byte[] dataMasterKeyBBytes;

	private Sha1Hashing SHA1 = new Sha1Hashing();

	private byte[] deriveSectorMasterKey(byte[] masterKey, byte sectorNumber) {
		byte[] derivedKey = new byte[masterKey.length + 1];
		System.arraycopy(masterKey, 0, derivedKey, 0, masterKey.length);
		derivedKey[masterKey.length] = sectorNumber;

		if (SHA1 == null)
			SHA1 = new Sha1Hashing();

		return SHA1.Hash(derivedKey);
	}

	private byte[] deriveSectorKey(byte[] sectorMasterKey, byte[] serialNumber) {
		byte[] temp = new byte[sectorMasterKey.length + serialNumber.length];
		System.arraycopy(sectorMasterKey, 0, temp, 0, sectorMasterKey.length);
		System.arraycopy(serialNumber, 0, temp, sectorMasterKey.length,
				serialNumber.length);

		if (SHA1 == null)
			SHA1 = new Sha1Hashing();

		temp = SHA1.Hash(temp);

		byte[] sectorKey = new byte[6];
		System.arraycopy(temp, temp.length - sectorKey.length, sectorKey, 0,
				sectorKey.length);

		return sectorKey;
	}

	private byte[] deriveHeaderSectorKeyB(byte sectorNumber, byte[] serialNumber) {
		if (serialNumber == null)
			return null;

		if (!smkBCache.containsKey(sectorNumber)) {
			byte[] sectorMasterKey = deriveSectorMasterKey(
					headerMasterKeyBytes, sectorNumber);
			smkBCache.put(sectorNumber, sectorMasterKey);
		}
		return deriveSectorKey(smkBCache.get(sectorNumber), serialNumber);
	}

	public byte[] deriveDataSectorKeyA(byte sectorNumber, byte[] serialNumber) {
		if (serialNumber == null)
			return null;
		if (!smkACache.containsKey(sectorNumber)) {
			byte[] sectorMasterKey = deriveSectorMasterKey(dataMasterKeyABytes,
					sectorNumber);
			smkACache.put(sectorNumber, sectorMasterKey);
		}
		return deriveSectorKey(smkACache.get(sectorNumber), serialNumber);
	}

	public byte[] deriveDataSectorKeyB(byte sectorNumber, byte[] serialNumber) {
		if (serialNumber == null)
			return null;

		if (!smkBCache.containsKey(sectorNumber)) {
			byte[] sectorMasterKey = deriveSectorMasterKey(dataMasterKeyBBytes,
					sectorNumber);
			smkBCache.put(sectorNumber, sectorMasterKey);
		}
		return deriveSectorKey(smkBCache.get(sectorNumber), serialNumber);
	}

	public GeneratorDataUsedRSA() {

	}

	@Override
	public SectorKeyPairDTO deriveSectorPairKeyWithKeyADefault(
			byte sectornumber, byte[] serialnumber) {
		SectorKeyPairDTO keyPair = new SectorKeyPairDTO();

		// Header sectors
		keyPair.setKeyA(DEFAUL_KEY_A);
		String keyB = Converter.getInstance().byteArrayToHexString(deriveHeaderSectorKeyB(sectornumber, serialnumber));
		keyPair.setKeyB(keyB);
		return keyPair;
	}

	@Override
	public SectorKeyPairDTO deriveDataSectorKeyPair(byte sectorNumber,
			byte[] serialNumber) {
		SectorKeyPairDTO keyPair = new SectorKeyPairDTO();
		String keyA = Converter.getInstance().byteArrayToHexString(deriveDataSectorKeyA(sectorNumber, serialNumber));
		String keyB = Converter.getInstance().byteArrayToHexString(deriveDataSectorKeyB(sectorNumber, serialNumber));
		keyPair.setKeyA(keyA);
		keyPair.setKeyB(keyB);

		return keyPair;
	}

	public void setHeaderMasterKeyBytes(String key) {
		headerMasterKeyBytes = Converter.getInstance().hexStringToByteArray(key);
	}

	public void setDataMasterKeyABytes(String key) {
		dataMasterKeyABytes = Converter.getInstance().hexStringToByteArray(key);
	}

	public void setDataMasterKeyBBytes(String key) {
		dataMasterKeyBBytes = Converter.getInstance().hexStringToByteArray(key);
	}

	@Override
	public String encryptDataByHexXmlPubKey(String keyEncript, byte[] plaintext){
		String result = null;
		if (plaintext.length > 0) {
			try{
				byte[] data = RSAAlgorithm.Instance().encryptByPubKeyHexXml(keyEncript, plaintext);
				result = Converter.getInstance().byteArrayToHexString(data);
			}catch(Exception ex){
				ex.printStackTrace();
			}
		}
		return result;
	}
	
	@Override
	public byte[] encryptDataByHexXmlPubKeyB(String keyEncript, byte[] plaintext){
		
		if (plaintext.length > 0) {
			try{
				byte[] data = RSAAlgorithm.Instance().encryptByPubKeyHexXml(keyEncript, plaintext);
				return data;
			}catch(Exception ex){
				ex.printStackTrace();
			}
		}
		return null;
	}
	
	
	private String generalKey(byte sectornumber, byte[] serialnumber){
		return Converter.getInstance().byteArrayToHexString(deriveDataSectorKeyA(sectornumber, serialnumber));
	}

	@Override
	public SectorKeyPairDTO deriveSectorKeyA(byte sectornumber, byte[] serialnumber) {
		SectorKeyPairDTO keyPair = new SectorKeyPairDTO();
		
		keyPair.setKeyA(generalKey(sectornumber, serialnumber));
		keyPair.setKeyB(null);

		return keyPair;
	}

	@Override
	public SectorKeyPairDTO deriveSectorKeyB(byte sectornumber,
			byte[] serialnumber) {
		SectorKeyPairDTO keyPair = new SectorKeyPairDTO();
		keyPair.setKeyB(generalKey(sectornumber, serialnumber));
		keyPair.setKeyA(null);

		return keyPair;
	}

	@Override
	public String encryptDataByValueKey(String keyEncript, byte[] plaintext) {
		// TODO Auto-generated method stub
		return null;
	}

}
