package com.sworld.timekeeping.common;

import java.util.List;

import org.codehaus.jettison.json.JSONArray;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;
import com.swt.timekeeping.domain.TimeConfig;
import com.swt.timekeeping.domain.Event;

public class TimeKeepingUtilites {
	private static TimeKeepingUtilites instance = null;

	private TimeKeepingUtilites() {
	}

	public static final TimeKeepingUtilites getInstance() {
		if (null == instance)
			instance = new TimeKeepingUtilites();

		return instance;
	}

	public List<TimeConfig> convertJsonArrayToListTimeKeeping(
			JSONArray jsonArray) {
		try {
			TypeToken<List<TimeConfig>> token = new TypeToken<List<TimeConfig>>() {
			};
			Gson gson = new Gson();
			return gson.fromJson(jsonArray.toString(), token.getType());
		} catch (Exception e) {
			// TODO: handle exception
		}
		return null;
	}
	
	public List<Event> convertJsonArrayToListEvent(
			JSONArray jsonArray) {
		try {
			TypeToken<List<Event>> token = new TypeToken<List<Event>>() {
			};
			Gson gson = new Gson();
			return gson.fromJson(jsonArray.toString(), token.getType());
		} catch (Exception e) {
			// TODO: handle exception
		}
		return null;
	}
}
