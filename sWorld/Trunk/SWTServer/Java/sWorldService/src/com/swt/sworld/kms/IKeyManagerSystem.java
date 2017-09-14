/**
 * Description: the all functions for KMS package
 * Author: NH Nam
 * Date: 2013 06 28 
 */
package com.swt.sworld.kms;

public interface IKeyManagerSystem {
	//TODO: define
	byte[] GenerateSmk(byte[] keyBytes, byte sector);
	byte[] GenerateSectorKeyA(byte[] smkBytes, byte[] snBytes);
	byte[] GenerateSectorKeyB(byte[] smkBytes, byte[] snBytes);
	void GenerateSectorKeyPair(byte[] smkBytes, byte[] snBytes,  byte[] keyABytes, byte[] keyBBytes);
}
