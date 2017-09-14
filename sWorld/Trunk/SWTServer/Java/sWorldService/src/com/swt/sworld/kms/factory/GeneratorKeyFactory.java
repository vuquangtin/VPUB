package com.swt.sworld.kms.factory;

import com.swt.sworld.kms.IGeneratorKey;
import com.swt.sworld.kms.impls.GeneratorDataUsedRSA;
import com.swt.sworld.kms.impls.GeneratorDataUserAES;
import com.swt.sworld.utilites.SworldConst;

public class GeneratorKeyFactory {
	public IGeneratorKey Instance(int key) {
		switch (key) {
		case SworldConst.RSA:
			return new GeneratorDataUsedRSA();
		case SworldConst.AES:
			return new GeneratorDataUserAES(); 
			
		default:
			break;
		}
		return new GeneratorDataUsedRSA();
	}

}