package com.nhn.utilities;


import java.awt.image.BufferedImage;
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.UnsupportedEncodingException;

import javax.imageio.ImageIO;
import org.apache.commons.codec.binary.Base64;

import com.nhn.predefine.values.PreDefine;

/**
 * The all convert functions
 * @author Vo tinh
 *
 */
public class Converter {
	private static final Converter instance = new Converter();
	private Converter() {

	}

	public static Converter getInstance() {
		return instance;
	}

	/**
	 * Chuyển đổi một hexa string sang mãng byte 
	 * @param str: hexa string cần chuyển
	 * @return mãng byte
	 */
	public byte[] hexStringToByteArray(String str) {
		int i = 0;
		byte[] results = new byte[str.length() / 2];
		for (int k = 0; k < str.length();) {
			results[i] = (byte) (Character.digit(str.charAt(k++), 16) << 4);
			results[i] += (byte) (Character.digit(str.charAt(k++), 16));
			i++;
		}
		return results;
	}

	/**
	 * Chuyển một mãng byte sang hexa string
	 * @param bytes: mãng byte cần chuyển
	 * @return hexa string
	 */
	public String byteArrayToHexString(byte[] bytes) {
		StringBuffer buffer = new StringBuffer();
		for (int i = 0; i < bytes.length; i++) {
			if (((int) bytes[i] & 0xff) < 0x10)
				buffer.append("0");
			buffer.append(Long.toString((int) bytes[i] & 0xff, 16));
		}
		return buffer.toString();
	}
	/**
	 * Splits string to array string by splitter
	 * @param str: source
	 * @param spliter: splitter
	 * @return string array: result of the function
	 */
	public String[] strToArray(String str,  String spliter)
	{
		return str.split(spliter);
	}
	/**
	 * Splits string to array string with default split
	 * @param str: data
	 * @return string array
	 */
	public String[] strToArray(String str)
	{
		return str.split(PreDefine.SPLITER);
	}
	
	/**
	 * encode image to base64 string
	 * @param image: image 
	 * @param type: image type
	 * @return base64 string
	 */
	public static String encodeToBase64String(BufferedImage image, String type) {
	    String imageString = null;
	    ByteArrayOutputStream bos = new ByteArrayOutputStream();

	    try {
	        ImageIO.write(image, type, bos);
	        byte[] imageBytes = bos.toByteArray();
	        imageString =  Base64.encodeBase64String(imageBytes);
	        
	        bos.close();
	    } catch (IOException e) {
	        e.printStackTrace();
	    }
	    return imageString;
	}
	
	/**
	 * decode base64 string to image
	 * @param imageString: base64 string
	 * @return buffered image
	 */
	public static BufferedImage decodeBase64StringToImage(String imageString) {
	    BufferedImage image = null;
	    byte[] imageByte;
	    try {
	        imageByte = Base64.decodeBase64(imageString);
	        ByteArrayInputStream bis = new ByteArrayInputStream(imageByte);
	        image = ImageIO.read(bis);
	        bis.close();
	    } catch (Exception e) {
	        e.printStackTrace();
	    }
	    return image;
	}
	
	public static String encodeToBase64String(String str) throws UnsupportedEncodingException{
		return Base64.encodeBase64String(str.getBytes("UTF-8"));
	}
	
	public static String decodeBase64StringToString(String base64) throws UnsupportedEncodingException{
		byte[] strBytes = Base64.decodeBase64(base64);
		return new String(strBytes, "UTF-8");
		
	}

}
