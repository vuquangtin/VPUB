package com.swt.sworld.ps.impl.factory;

import com.swt.sworld.ps.impl.PersonalizationSystem;
import com.swt.sworld.utilites.SworldConst;


public class PSFactory {
	public static PersonalizationSystem getFactory (int name) {
		switch(name)
		{
		case SworldConst.SWT:
			return new PersonalizationSystem(String.valueOf(name));
		default:
			return null;
		}
	}
}
