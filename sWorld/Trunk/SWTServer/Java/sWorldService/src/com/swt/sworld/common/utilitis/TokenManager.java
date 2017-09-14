package com.swt.sworld.common.utilitis;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.HashMap;
import java.util.Iterator;
import java.util.Map;

import org.apache.commons.lang3.RandomStringUtils;
import com.swt.sworld.communication.customer.object.SessionDTO;

public class TokenManager {
	private HashMap<String, SessionDTO> map = new HashMap<String, SessionDTO>();
	private static TokenManager instance = null;

	private TokenManager() {
	}

	public static final TokenManager getInstance() {
		if (null == instance)
			instance = new TokenManager();
		return instance;
	}

	/**
	 * created session was used random string
	 * 
	 * @return
	 */
	private String sessionCreated() {
		String token = RandomStringUtils.randomAlphanumeric(15);
		if (!map.containsKey(token))
			return token;
		return sessionCreated();
	}

	public String generateToken(SessionDTO user) {
		String token = sessionCreated();
		/* second time is error
		// if (map.containsValue(user)) { date always change => never true
		for (Map.Entry<String, SessionDTO> e : map.entrySet()) {
			// check user name, only one token for user
			if (user.getUsername().equals(e.getValue().getUsername())) {
				map.remove(e.getKey());
				// break;
			}
		}*/
		// using Iterator.remove
		Iterator<Map.Entry<String, SessionDTO>> it = map.entrySet().iterator();
		while (it.hasNext()) {
			Map.Entry<String, SessionDTO> e = it.next();
			if (user.getUsername().equals(e.getValue().getUsername())) {
				it.remove();
			}
		}

		// }
		map.put(token, user);
		return token;
	}

	public boolean checkTokenSession(String session, String token) {
		// if (session.equals(token) && map.containsKey(session))
		if (map.containsKey(token)) {
			SessionDTO sessionDTO = map.get(token);
			// format default of function new Date().toString()
			DateFormat df = new SimpleDateFormat("EEE MMM dd HH:mm:ss z yyyy");
			try {
				Date lastActionsTime = df.parse(sessionDTO.getDatelogin());
				// get milliseconds form last action to now
				long waitingTimeMillis = new Date().getTime()
						- lastActionsTime.getTime();
				// keep token in 2h
				if (waitingTimeMillis < 7200000) {
					// update last action time for sessionDTO in hash map
					sessionDTO.setDatelogin(new Date().toString());
					map.put(token, sessionDTO);
					return true;
				} else {
					// remove token
					removeTokenSession(token, token);
					return false;
				}
			} catch (Exception e) {
			}
		}
		return false;
	}

	// 2017-07-03 Bug718: All - Token for single user -> vu.pham Start
	public String checkTokenSession(String username) {
		try {
			if (!map.isEmpty()) {
				for (Map.Entry<String, SessionDTO> e : map.entrySet()) {
					// check user name token
					if (username.equals(e.getValue().getUsername())) {
						e.getValue().setDatelogin(new Date().toString());
						return e.getValue().getToken();
					}
				}
			}
		} catch (Exception e) {
		}
		return null;
	}

	public void removeTokenSession(String session, String token) {
		if (map.containsKey(token))
			map.remove(token);
	}

	public String getUserBySession(String session) {
		String user = "";
		if (map.containsKey(session)) {
			SessionDTO ses = map.get(session);
			user = ses.getUsername();
		}
		return user;
	}
	// 2017-07-03 Bug718: All - Token for single user -> vu.pham End
}
