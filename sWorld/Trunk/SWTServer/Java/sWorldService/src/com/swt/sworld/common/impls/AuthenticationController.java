package com.swt.sworld.common.impls;

import com.swt.sworld.common.domain.GroupSworld;
import com.swt.sworld.common.domain.UserSworld;
import com.swt.sworld.common.utilitis.TokenManager;
import com.swt.sworld.communication.customer.object.SessionDTO;

/**
 * Authenticate user of system
 * 
 * @author Vo tinh
 * 
 */
public class AuthenticationController {
	public static final AuthenticationController Instance = new AuthenticationController();
	private UserDAOImpl userDAO = new UserDAOImpl();
	private GroupDAOImpl grDAO = new GroupDAOImpl();

	private AuthenticationController() {

	}

	/**
	 * To check root group user of system
	 * 
	 * @param groupid
	 *            : group id
	 * @return It's true value if it is root group, another case is false value
	 */
	private boolean isRoot(long groupid) {
		GroupSworld gr = grDAO.getById(groupid);
		if (null == gr)
			return false;
		return gr.getIsAdmin() > 0 ? true : false;
	}
	// 2017-07-03 Bug718: All - Token for single user -> vu.pham Start
	/**
	 * login to system
	 * 
	 * @param username
	 *            : user name
	 * @param pwd
	 *            : password
	 * @return SessionDTO object
	 */
	public SessionDTO login(String username, String pwd, boolean accept) {
		SessionDTO result = null;
		UserSworld userSworld = userDAO.getUserByUserNameAndPwd(username, pwd);
		if (userSworld != null) {
			result = new SessionDTO(userSworld.getId(),
					userSworld.getGroupId(), userSworld.getUserName(),
					isRoot(userSworld.getGroupId()));
			String token = TokenManager.getInstance().checkTokenSession(
					username);
			if (token != null && !accept) {
				result.setIsLogin(true);
				result.setToken(token);
			} else {
				token = TokenManager.getInstance().generateToken(result);
				result.setToken(token);
			}
		}
		return result;
	}
	// 2017-07-03 Bug718: All - Token for single user -> vu.pham End
	/**
	 * login to system
	 * 
	 * @param username
	 *            : user name
	 * @param pwd
	 *            : password
	 * @return SessionDTO object
	 */
	public SessionDTO login(String username, String pwd) {
		SessionDTO result = null;
		UserSworld userSworld = userDAO.getUserByUserNameAndPwd(username, pwd);
		if (userSworld != null) {
			result = new SessionDTO(userSworld.getId(),
					userSworld.getGroupId(), userSworld.getUserName(),
					isRoot(userSworld.getGroupId()));
			String token = TokenManager.getInstance().generateToken(result);
			result.setToken(token);
		}
		return result;
	}
}
