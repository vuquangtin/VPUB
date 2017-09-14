package com.swt.sworld.kms.impls;

import java.io.StringReader;
import java.math.BigInteger;
import java.security.KeyFactory;
import java.security.PrivateKey;
import java.security.PublicKey;
import java.security.spec.RSAPrivateKeySpec;
import java.security.spec.RSAPublicKeySpec;

import javax.crypto.Cipher;
import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;

import org.w3c.dom.Document;
import org.xml.sax.InputSource;

import com.nhn.utilities.Converter;

public class RSAAlgorithm {
	private static RSAAlgorithm instance = null;
	private Cipher cipher;
	
	private RSAAlgorithm() throws Exception{
			cipher = Cipher.getInstance("RSA");
	}

	public  PublicKey publicKeyFromHexString(String xml) throws Exception{
		return buildPublicKeyFromHexString(xml);
	}
	private PublicKey buildPublicKeyFromHexString(String xml) throws Exception{
		RSAPublicKeySpec pkeyspec = null;
		Document doc = loadXMLFromString(xml);
		pkeyspec = new RSAPublicKeySpec(
				new BigInteger(Converter.getInstance().hexStringToByteArray(doc.getElementsByTagName("Modulus").item(0).getTextContent())),
				new BigInteger (Converter.getInstance().hexStringToByteArray(doc.getElementsByTagName("Exponent").item(0).getTextContent()))
			);	
		
		KeyFactory fact = KeyFactory.getInstance("RSA");
	    PublicKey pubKey = fact.generatePublic(pkeyspec);
	    
		return pubKey;
	}
	
	private PrivateKey buildPrivateKeyFromHexString(String xml) throws Exception{
		RSAPrivateKeySpec pkeyspec = null;
		Document doc = loadXMLFromString(xml);
		pkeyspec = new RSAPrivateKeySpec(
				new BigInteger(Converter.getInstance().hexStringToByteArray(doc.getElementsByTagName("Modulus").item(0).getTextContent())),
				new BigInteger (Converter.getInstance().hexStringToByteArray(doc.getElementsByTagName("Exponent").item(0).getTextContent()))
			);	
		
		KeyFactory fact = KeyFactory.getInstance("RSA");
		PrivateKey prikey = fact.generatePrivate(pkeyspec);
	    
		return prikey;
	}
	
	private  Document loadXMLFromString(String xml) throws Exception
	{
	    DocumentBuilderFactory	factory = DocumentBuilderFactory.newInstance();
	    DocumentBuilder	builder = factory.newDocumentBuilder();
	    InputSource	is = new InputSource(new StringReader(xml));
	    return	builder.parse(is);
	}
	
	public static RSAAlgorithm Instance() throws Exception{
		if(null == instance)
			instance = new RSAAlgorithm();
		
		return instance;
	}
	
	

	public byte[] encryptByPubKey(PublicKey key, byte[] message)  throws Exception {
		
		cipher.init(Cipher.ENCRYPT_MODE, key);
		return cipher.doFinal(message);
	}
	
	private byte[] encrypt128ByPubKeyHexXml(PublicKey key, byte[] message)  throws Exception {
		
		cipher.init(Cipher.ENCRYPT_MODE, key);
		return cipher.doFinal(message);
	}

	public byte[] encryptByPubKeyHexXml(String pubkeyxml, byte[] message)  throws Exception {
		
		PublicKey key = buildPublicKeyFromHexString(pubkeyxml);
		cipher.init(Cipher.ENCRYPT_MODE, key);
	
		return encrypt128ByPubKeyHexXml(key, message);
	}
	
	public byte[] decryptByPriKey(PrivateKey key, byte[] endata)  throws Exception{
		
		cipher.init(Cipher.DECRYPT_MODE, key);
		return  cipher.doFinal(endata);
	}
	
	public byte[] decryptByPubKeyXml(String prikeyxml, byte[] endata)  throws Exception{
		PrivateKey key = buildPrivateKeyFromHexString(prikeyxml);
		cipher.init(Cipher.DECRYPT_MODE, key);
		return  cipher.doFinal(endata);
	}

}
