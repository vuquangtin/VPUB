/**
 * 
 */
package com.swt.sworld.kms;

/**
 * @author LOCVIP
 *
 */
public interface IKMS {
	
	String extKey(String ten);
	/*
	 *  KeyDTO
	 */
	/**
	 * 
	 * Nhiệm vụ: thêm key vào database
	 * @param name : tên, ký danh
	 * @param description : mô tả
	 * @param value : giá trị
	 * @param curUserName : tên ngư�?i dùng hiện tại
	 * @return : EntityTranslator.ToKeyDto();
	 */
	Object AddKey(String name, String description, String value, String curUserName);
	
	/**
	 * 
	 * Nhiệm vụ: tự động sinh ra sector master key
	 * @param keyBytes : mảng key byte
	 * @param sector : sector
	 * @return : mảng SMK dã mã hóa SHA1
	 */
	byte[] GenerateSmk(byte[] keyBytes, byte sector);
	
	/**
	 * 
	 * Nhiệm vụ: tự động sinh ra key A
	 * @param smkBytes : sector master key
	 * @param snBytes : serial number of card
	 * @return : mảng key A 6 byte
	 */
	byte[] GenerateSectorKeyA(byte[] smkBytes, byte[] snBytes);
	
	/**
	 * 
	 * Nhiệm vụ: tự động sinh ra key B
	 * @param smkBytes : sector master key
	 * @param snBytes : serial number of card
	 * @return : mảng key B 6 byte
	 */
	byte[] GenerateSectorKeyB(byte[] smkBytes, byte[] snBytes);
	
	/**
	 * 
	 * Nhiệm vụ: tự động sinh ra key Pair
	 * @param smkBytes : sector master key
	 * @param snBytes : serial number of card
	 * @param keyABytes : key A
	 * @param keyBBytes : key B
	 */
	void GenerateSectorKeyPair(byte[] smkBytes, byte[] snBytes,/*out*/  byte[] keyABytes,/*out*/ byte[] keyBBytes);

}
