package com.nhn.error;

/**
 * Define error codes of the sworld project
 * @author Vo tinh
 *
 */
public class ErrorCodeSworld {
	
	//Perso Management 
	public static final int CARD_LOST = 1201;
    public static final int CARD_BROKEN = 1202;
    public static final int CARD_NOT_FOUND = 1203;
    public static final int CARD_PERSONALIZED = 1204;
    public static final int CARD_NOT_LOST = 1206;
    public static final int CARD_NOT_BROKEN = 1207;
    public static final int CARD_NOT_PERSONALIZED = 1208;
    public static final int CARD_ALREADY_EXISTS = 1211;
    public static final int CARD_TYPE_UNSUPPORTED = 1212;

    public static final int PERSO_UNREGISTERED = 1220;
    public static final int PERSO_LOCKED = 1221;
    public static final int PERSO_CANCELED = 1222;
    public static final int PERSO_NOT_FOUND = 1223;
    public static final int PERSO_NOT_LOCKED = 1224;
    public static final int PERSO_NOT_CANCELED = 1225;
    public static final int PERSO_REGISTERED = 1226;
    public static final int TEACHER_PROFILE_APP_NOT_PRESENT = 1227;
    public static final int PERSO_EXPIRED = 1228;
    public static final int PERSO_NOT_EXPIRED = 1229;
    public static final int PERSO_NOT_EXTENDED = 1230;
    public static final int INVALID_EXPIRATION_DATE = 1231;
    
    //User And Group Management
    public static final int SESSION_EXPIRED = 1100;
    public static final int LOGIN_FAILED = 1101;
    public static final int NOT_HAVE_PERMISSION = 1102;
    public static final int SESSION_NOT_FOUND = 1103;

    public static final int USER_LOCKED = 1110;
    public static final int USER_CANCELED = 1111;
    public static final int USER_NOT_LOCKED = 1112;
    public static final int USER_NOT_FOUND = 1113;
    public static final int GROUP_NOT_FOUND = 1114;
    public static final int FUNCTION_NOT_FOUND = 1115;
    public static final int UPDATE_ROOT_USER = 1116;
    public static final int GROUP_CANCELED = 1117;

    public static final int PASSWORD_TOO_SHORT = 1120;
    public static final int PASSWORD_TOO_LONG = 1121;
    public static final int PASSWORD_TOO_WEAK = 1122;
    public static final int USERNAME_TAKEN = 1123;
    public static final int USERNAME_TOO_SHORT = 1124;
    public static final int USERNAME_TOO_LONG = 1125;
    public static final int PASSWORD_NOT_MATCH = 1126;
    public static final int GROUPNAME_TAKEN = 1127;
    public static final int GROUPNAME_INVALID = 1128;
    
    public static final int CARD_ERROR = 1013;
    public static final int CARD_SUCCESS = 1000;
    
    
    public final static int FALSED_VALUE = 0;
	public final static int TRUE_VALUE = 1;
	
	public static final int FALSED = -2;
	public static final int SUCCESS = 0;
	public static final int UNKNOW = -1;
	
	public static final int OPEN_TRANSACTION_FALSED = -100;
	public static final int NOT_FOUND_OBJ = -101;
	
}
