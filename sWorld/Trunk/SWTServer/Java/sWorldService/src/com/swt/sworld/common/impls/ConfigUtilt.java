package com.swt.sworld.common.impls;

import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.Serializable;
import java.util.Properties;

public class ConfigUtilt implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = -5237904879901553737L;
	private static ConfigUtilt instance = null;
	private String filename = "";
	private Properties config;

	public ConfigUtilt() {
		loadFileConfig();
	}

	public static ConfigUtilt Instance() {
		if (null == instance)
			instance = new ConfigUtilt();

		return instance;
	}

	private void loadFileConfig() {
		try {

			if (null == filename || "".equals(filename))
				filename = "/config.properties";

			config = new Properties();
			try {

				InputStreamReader fMainProp = new InputStreamReader(this
						.getClass().getResourceAsStream(filename));

				config.load(fMainProp);

			} catch (FileNotFoundException e) {
				System.out.println("FileNotFoundException: " + e.getMessage());
				// TODO Auto-generated catch block
				e.printStackTrace();

			} catch (IOException e) {
				System.out.println("IOException: " + e.getMessage());
				// TODO Auto-generated catch block
				e.printStackTrace();

			}

		} catch (Throwable ex) {

		}
	}

	public String getValueByKey(String key) {
		if (config.containsKey(key))
			return config.getProperty(key);

		return "";
	}

	public String getFilename() {
		return filename;
	}

	public void setFilename(String filename) {
		this.filename = filename;
	}

}
