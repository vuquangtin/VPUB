package com.sworld.common;

import java.util.List;

import org.codehaus.jettison.json.JSONArray;
import org.codehaus.jettison.json.JSONObject;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;
import com.swt.sworld.communication.customer.object.PayOutDto;
import com.swt.sworld.ps.domain.MemberMobilePersonal;

public class Utilites {
	private static Utilites instance = null;

	private Utilites() {
	}
	public static final Utilites getInstance() {
		if (null == instance)
			instance = new Utilites();

		return instance;
	}

	public <T> List<T> convertJsonArrayToList(JSONArray jsonArray) {
		try {
			TypeToken<List<T>> token = new TypeToken<List<T>>() {
			};
			Gson gson = new Gson();
			return gson.fromJson(jsonArray.toString(), token.getType());
		} catch (Exception e) {
			// TODO: handle exception
		}

		return null;
	}

	public List<Long> convertJsonArrayToListLong(JSONArray jsonArray) {
		try {
			TypeToken<List<Long>> token = new TypeToken<List<Long>>() {
			};
			Gson gson = new Gson();
			return gson.fromJson(jsonArray.toString(), token.getType());
		} catch (Exception e) {
			// TODO: handle exception
		}

		return null;
	}

	public List<Integer> convertJsonArrayToListInteger(JSONArray jsonArray) {
		try {
			TypeToken<List<Integer>> token = new TypeToken<List<Integer>>() {
			};
			Gson gson = new Gson();
			return gson.fromJson(jsonArray.toString(), token.getType());
		} catch (Exception e) {
			// TODO: handle exception
		}

		return null;
	}

	public List<MemberMobilePersonal> convertJsonArrayToListMemberMobile(JSONArray jsonArray) {
		try {
			TypeToken<List<MemberMobilePersonal>> token = new TypeToken<List<MemberMobilePersonal>>() {
			};
			Gson gson = new Gson();
			return gson.fromJson(jsonArray.toString(), token.getType());
		} catch (Exception e) {
			// TODO: handle exception
		}
		return null;
	}
	
	public List<PayOutDto> convertJsonArrayToListPayOut(JSONArray jsonArray) {
		try {
			TypeToken<List<PayOutDto>> token = new TypeToken<List<PayOutDto>>() {
			};
			Gson gson = new Gson();
			return gson.fromJson(jsonArray.toString(), token.getType());
		} catch (Exception e) {
			// TODO: handle exception
		}
		return null;
	}

	public <T> T convertJsonObjToObject(JSONObject obj, Class<T> c) {
		try {
			Gson gson = new Gson();
			return gson.fromJson(obj.toString(), c);
		} catch (Exception e) {
			// TODO: handle exception
		}

		return null;
	}

	public <T> T convertJsonStrToObject(String obj) {
		try {
			TypeToken<T> token = new TypeToken<T>() {
			};
			Gson gson = new Gson();
			return gson.fromJson(obj, token.getType());
		} catch (Exception e) {
			// TODO: handle exception
		}

		return null;
	}
	
}
