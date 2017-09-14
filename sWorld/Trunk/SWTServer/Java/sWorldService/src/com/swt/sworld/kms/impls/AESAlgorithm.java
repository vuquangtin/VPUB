package com.swt.sworld.kms.impls;

import java.security.Key;

import javax.crypto.Cipher;
import javax.crypto.spec.SecretKeySpec;

public class AESAlgorithm {
	private static final String ALGORITHM = "AES";
	private static final String TRANSFORMATION = "AES";

	public static byte[] encrypt(String key, byte[] plaintdata) {
		return doCrypto(Cipher.ENCRYPT_MODE, key, plaintdata);
	}

	public static byte[] decrypt(String key, byte[] plaintdata) {
		return doCrypto(Cipher.DECRYPT_MODE, key, plaintdata);
	}

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
}
