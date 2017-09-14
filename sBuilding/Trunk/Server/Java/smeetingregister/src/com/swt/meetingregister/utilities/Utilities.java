package com.swt.meetingregister.utilities;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.net.URL;
import java.text.SimpleDateFormat;
import java.util.Date;

import com.google.gson.Gson;
import com.sworld.common.ResultObject;
import com.sworld.common.Status;

public class Utilities {

	private static Utilities Instance = new Utilities();

	public static Utilities getInstance() {
		return Instance;
	}

	public String getCurrentDateStrDDMMYYYY() {
		SimpleDateFormat sdfDate = new SimpleDateFormat("dd-MM-yyyy HH:mm:ss");
		return sdfDate.format(new Date());
	}

	public Object getDataFromServer(String session, String urlPattern,
			String method, Object... list) {
		String _url = getUrl(urlPattern, method, getParamater(list));
		return getDataFromServerByUrl(session, _url);
	}

	public Object postDataFromServer(String session, String urlPattern,
			String method, String _jsonObject, Object... list) {
		String _url = getUrl(urlPattern, method, getParamater(list));
		return postDataFromServerByUrl(session, _jsonObject, _url);
	}

	private String getParamater(Object... list) {
		StringBuilder builder = new StringBuilder();
		for (Object obj : list) {
			if (null == obj)
				continue;
			builder.append("/" + obj.toString());
		}
		return builder.toString();
	}

	private String getUrl(String urlPattern, String method, String parone) {
		return "http://localhost:8080/meetingWebServices/sworld" + urlPattern
				+ method + parone;
	}

	private Object getDataFromServerByUrl(String session, String _url) {
		try {
			URL url = new URL(_url);
			HttpURLConnection conn = (HttpURLConnection) url.openConnection();
			conn.setRequestMethod("GET");
			conn.setRequestProperty("content-type",
					"application/json; charset=utf-8");
			if (conn.getResponseCode() != 200) {
				throw new RuntimeException("Failed : HTTP error code : "
						+ conn.getResponseCode());
			}
			BufferedReader br = new BufferedReader(new InputStreamReader(
					(conn.getInputStream())));
			String output;
			StringBuilder result = new StringBuilder();
			while ((output = br.readLine()) != null) {
				result.append(output);
			}
			Gson gson = new Gson();
			ResultObject resultObject = gson.fromJson(result.toString(),
					ResultObject.class);
			conn.disconnect();
			if (resultObject.getStatus() == Status.SUCCESS) {
				return resultObject.getObj();
			}
			return null;
		} catch (Exception e) {
			Logging.getInstance().writeError(e.getMessage());
			e.printStackTrace();
			return null;
		}
	}

	private Object postDataFromServerByUrl(String session, String _jsonObject,
			String _url) {
		try {
			URL url = new URL(_url);
			HttpURLConnection conn = (HttpURLConnection) url.openConnection();
			conn.setDoOutput(true);
			conn.setRequestMethod("POST");
			conn.setRequestProperty("Content-Type",
					"application/json; charset=utf-8");

			BufferedWriter bw = new BufferedWriter(new OutputStreamWriter(
					conn.getOutputStream()));
			bw.write(_jsonObject);
			bw.close();

			if (conn.getResponseCode() != 200) {
				throw new RuntimeException("Failed : HTTP error code : "
						+ conn.getResponseCode());
			}

			BufferedReader br = new BufferedReader(new InputStreamReader(
					(conn.getInputStream())));
			String output;
			StringBuilder result = new StringBuilder();
			while ((output = br.readLine()) != null) {
				result.append(output);
			}
			conn.disconnect();
			ResultObject resultObject = new Gson().fromJson(result.toString(),
					ResultObject.class);
			if (resultObject.getStatus() == Status.SUCCESS) {
				return resultObject.getObj();
			}
			return null;
		} catch (Exception e) {
			Logging.getInstance().writeError(e.getMessage());
			e.printStackTrace();
			return null;
		}
	}
}
