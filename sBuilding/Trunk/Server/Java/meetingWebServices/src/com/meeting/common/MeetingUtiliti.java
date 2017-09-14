package com.meeting.common;

public class MeetingUtiliti {
	private static MeetingUtiliti instance = null;
	
	private MeetingUtiliti(){
		
	}
	public static final MeetingUtiliti getInstance(){
		if(null == instance){
			instance = new MeetingUtiliti();
		}
		return instance;
	}
	
}
