/**
 * 
 */
package com.swt.sworld.test;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.StringReader;
import java.math.BigInteger;
import java.security.KeyFactory;
import java.security.KeyPair;
import java.security.KeyPairGenerator;
import java.security.NoSuchAlgorithmException;
import java.security.PrivateKey;
import java.security.PublicKey;
import java.security.spec.InvalidKeySpecException;
import java.security.spec.RSAPrivateKeySpec;
import java.security.spec.RSAPublicKeySpec;

import javax.crypto.Cipher;
import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;

import org.w3c.dom.Document;
import org.xml.sax.InputSource;
import org.xml.sax.SAXException;

import com.nhn.utilities.Converter;

/**
 * @author votinh
 * 
 */
public class MainTest {

	public static void main(String[] args) throws Exception {
		// RSAAlgorithm.Instance().RSAtoXML(p, kp)

		KeyPairGenerator kpg = KeyPairGenerator.getInstance("RSA");
		kpg.initialize(1024);
		KeyPair kp = kpg.genKeyPair();

		KeyFactory fact = KeyFactory.getInstance("RSA");
		RSAPublicKeySpec pub = fact.getKeySpec(kp.getPublic(),
				RSAPublicKeySpec.class);
		RSAPrivateKeySpec priv = fact.getKeySpec(kp.getPrivate(),
				RSAPrivateKeySpec.class);

		savePublicToFile("public.txt", pub.getModulus(),
				pub.getPublicExponent());
		savePrivateToFile("private.txt", priv.getModulus(),
				priv.getPrivateExponent());
		
		String plantext = "Nguyễn Hồng Nam";
		
		System.out.println("plan text:" + plantext);
		
		byte[] endata = rsaEncrypt(plantext.getBytes());
		
		byte[] dedata = rsaDecrypt( endata );
		
		System.out.println("decrypt data:" + new String(dedata));
		
//		List<Member> list = MemberController.Instance.getMemberBytotalCount(39, subOrgId, filter, start, length);

	}

	public static void savePublicToFile(String fileName, BigInteger mod,
			BigInteger exp) throws IOException {

		BufferedWriter writer = new BufferedWriter(new FileWriter(fileName));

		try {
			String xml = "<RSAPublicKey>"
					+ "<Modulus>"
					+ Converter.getInstance().byteArrayToHexString(
							mod.toByteArray())
					+ "</Modulus>"
					+ "<Exponent>"
					+ Converter.getInstance().byteArrayToHexString(
							exp.toByteArray()) + "</Exponent>";
			xml += "</RSAPublicKey>";

			writer.write(xml);
		} catch (Exception e) {
			throw new IOException("Unexpected error", e);
		} finally {
			writer.close();
		}
	}

	public static void savePrivateToFile(String fileName, BigInteger mod, BigInteger exp) throws IOException {

		BufferedWriter writer = new BufferedWriter(new FileWriter(fileName));

		try {
			String xml = "<RSAPrivateKey>"
					+ "<Modulus>"
					+ Converter.getInstance().byteArrayToHexString(
							mod.toByteArray())
					+ "</Modulus>"
					+ "<Exponent>"
					+ Converter.getInstance().byteArrayToHexString(
							exp.toByteArray()) + "</Exponent>";
			xml += "</RSAPrivateKey>";

			writer.write(xml);
		} catch (Exception e) {
			throw new IOException("Unexpected error", e);
		} finally {
			writer.close();
		}
	}

	public static byte[] rsaEncrypt(byte[] data) {
		try{
		  PublicKey pubKey = readPublicKeyFromFile();
		  Cipher cipher = Cipher.getInstance("RSA");
		  cipher.init(Cipher.ENCRYPT_MODE, pubKey);
		  byte[] cipherData = cipher.doFinal(data);
		  return cipherData;
		}catch(Exception ex){
			
		}
		return null;
	}
	
	public static byte[] rsaDecrypt(byte[] data) {
		try{
		  PrivateKey pubKey = readPrivateKeyFromFile();
		  Cipher cipher = Cipher.getInstance("RSA");
		  cipher.init(Cipher.DECRYPT_MODE, pubKey);
		  byte[] cipherData = cipher.doFinal(data);
		  return cipherData;
		}catch(Exception ex){
			
		}
		return null;
	}
	
	
	public static PublicKey readPublicKeyFromFile() throws IOException {
		BufferedReader br = new BufferedReader(new FileReader("public.txt"));
		try {

			String sCurrentLine = br.readLine();
			
			System.out.println(sCurrentLine);
			
			DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
			DocumentBuilder builder = factory.newDocumentBuilder();
			InputSource is = new InputSource(new StringReader(sCurrentLine));
			Document doc = builder.parse(is);
			byte[] modules = Converter.getInstance().hexStringToByteArray(doc.getElementsByTagName("Modulus").item(0).getTextContent());
			byte[] exponent = Converter.getInstance().hexStringToByteArray(doc.getElementsByTagName("Exponent").item(0).getTextContent());
			BigInteger m = new BigInteger ( modules );
			BigInteger e = new BigInteger ( exponent );
			RSAPublicKeySpec keySpec = new RSAPublicKeySpec(m, e);
			KeyFactory fact = KeyFactory.getInstance("RSA");
			PublicKey pubKey = fact.generatePublic(keySpec);
			return pubKey;

		} catch (IOException | ParserConfigurationException | SAXException | NoSuchAlgorithmException | InvalidKeySpecException e) {
			e.printStackTrace();
		} finally {
			br.close();
		}
		
		return null;
	}
	
	public static PrivateKey readPrivateKeyFromFile() throws IOException {
		BufferedReader br = new BufferedReader(new FileReader("private.txt"));
		try {

			String sCurrentLine = br.readLine();
			
			System.out.println(sCurrentLine);

			DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
			DocumentBuilder builder = factory.newDocumentBuilder();
			InputSource is = new InputSource(new StringReader(sCurrentLine));
			Document doc = builder.parse(is);
			
			byte[] modules = Converter.getInstance().hexStringToByteArray(doc.getElementsByTagName("Modulus").item(0).getTextContent());
			byte[] exponent = Converter.getInstance().hexStringToByteArray(doc.getElementsByTagName("Exponent").item(0).getTextContent());
			
			BigInteger m = new BigInteger (modules);
			BigInteger e = new BigInteger (exponent);
			RSAPrivateKeySpec keySpec = new RSAPrivateKeySpec(m, e);
			KeyFactory fact = KeyFactory.getInstance("RSA");
			PrivateKey pubKey = fact.generatePrivate(keySpec);
			return pubKey;

		} catch (IOException | ParserConfigurationException | SAXException | NoSuchAlgorithmException | InvalidKeySpecException e) {
			e.printStackTrace();
		} finally {
			br.close();
		}
		
		return null;
	}

}
