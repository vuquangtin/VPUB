package com.swt.sworld.kms.impls;

import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;

import com.swt.sworld.common.impls.ConfigDAOImpl;
import com.swt.sworld.utilites.SworldConst;

public class Sha1Hashing {

	private MessageDigest mDigest;
	private static ConfigDAOImpl configDAOImpl = new ConfigDAOImpl();
	private static int count_hash = Integer.parseInt(configDAOImpl.getValueActive(SworldConst.COUNT_HASH_PASSWORD));
	public Sha1Hashing()
	{
		try {
			mDigest = MessageDigest.getInstance("SHA1");
			
		} catch (NoSuchAlgorithmException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
	public byte[] Hash(String text, int loop) {
		byte[] msgBytes =  text.getBytes();
		for (int i = 0; i < loop; i++) {
			msgBytes = mDigest.digest(msgBytes);
		}
		return msgBytes;
	}

	public byte[] Hash(String text) {
		byte[] msgBytes =  text.getBytes();
		
		return mDigest.digest(msgBytes);
		
	}
	
	public byte[] Hash(byte[]  msgBytes) {
		return mDigest.digest(msgBytes);
		
	}
	
	public String bytesToHex(byte[] in) {
	    final StringBuilder builder = new StringBuilder();
	    for(byte b : in) {
	        builder.append(String.format("%02x", b));
	    }
	    return builder.toString();
	}
	
	public String encryptPassword(String password)
	{
	    String sha1 = "";
	    try
	    {
	    	sha1 = bytesToHex(Hash(password, count_hash));
	    }
	    catch(Exception e)
	    {
	        e.printStackTrace();
	    }
	    return sha1;
	}
}
