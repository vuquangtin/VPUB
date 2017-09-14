package com.swt.meeting.customObject;

import java.io.Serializable;

public class FileLCT implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	private String fileName;
	private String data;
	// loai file
	private String type;

	public void setFileName(String fileName) {
		this.fileName = fileName;
	}

	public String getFileName() {
		return fileName;
	}

	public String getData() {
		return data;
	}

	public void setData(String data) {
		this.data = data;
	}

	public String getType() {
		return type;
	}

	public void setType(String type) {
		this.type = type;
	}

}
