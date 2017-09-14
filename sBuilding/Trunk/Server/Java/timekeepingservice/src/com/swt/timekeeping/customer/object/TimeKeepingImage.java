package com.swt.timekeeping.customer.object;

import java.io.Serializable;

public class TimeKeepingImage implements Serializable{

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	private String image;
	public TimeKeepingImage(){
		this.image = "";
	}
	/**
	 * @return the image
	 */
	public String getImage() {
		return image;
	}
	public TimeKeepingImage(String image) {
		super();
		this.image = image;
	}
	/**
	 * @param image the image to set
	 */
	public void setImage(String image) {
		this.image = image;
	}
	

}
