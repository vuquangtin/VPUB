package com.swt.sworld.kms.impls;

import java.security.Key;

import javax.crypto.Cipher;
import javax.crypto.spec.SecretKeySpec;


import com.nhn.utilities.Converter;
import com.swt.sworld.communication.customer.object.SectorKeyPairDTO;
import com.swt.sworld.kms.IGeneratorKey;

public class GeneratorDataUserAES implements IGeneratorKey {
	public GeneratorDataUserAES() {

	}

	private static final String ALGORITHM = "AES";
	private static final String TRANSFORMATION = "AES";

	private static byte[] doCrypto(int cipherMode, String key, byte[] data) {
		try {
			Key secretKey = new SecretKeySpec(key.getBytes(), ALGORITHM);
			Cipher cipher = Cipher.getInstance(TRANSFORMATION);
			cipher.init(cipherMode, secretKey);

			byte[] outputBytes = cipher.doFinal(data);
			return outputBytes;

		} catch (Exception ex) {
			System.out.println(ex.getMessage());
		}
		return null;
	}

	@Override
	public SectorKeyPairDTO deriveSectorPairKeyWithKeyADefault(byte sectornumber, byte[] serialnumber) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public SectorKeyPairDTO deriveDataSectorKeyPair(byte sectornumber, byte[] serialnumber) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public SectorKeyPairDTO deriveSectorKeyA(byte sectornumber, byte[] serialnumber) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public SectorKeyPairDTO deriveSectorKeyB(byte sectornumber, byte[] serialnumber) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public void setHeaderMasterKeyBytes(String key) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void setDataMasterKeyABytes(String key) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void setDataMasterKeyBBytes(String key) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public String encryptDataByHexXmlPubKey(String key, byte[] plaintext) {
		return null;
	}

	@Override
	public byte[] encryptDataByHexXmlPubKeyB(String key, byte[] plaintext) {
		return null;
	}

	@Override
	public String encryptDataByValueKey(String key, byte[] plaintext) {
		byte[] tmp  = doCrypto(Cipher.ENCRYPT_MODE, key, plaintext);
		return Converter.getInstance().byteArrayToHexString(tmp);
	}
}
