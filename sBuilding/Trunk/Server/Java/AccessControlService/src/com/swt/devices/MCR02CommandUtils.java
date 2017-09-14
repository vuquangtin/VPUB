package com.swt.devices;

public class MCR02CommandUtils {
	//Clears LCD 
    private static String LCDCLR = "LCDCLR";
    //Write Text to LCD
    private static String LCDSET = "LCDSET;10;20;2;";
    //Execute Buzzer
    private static String BUZZER_SUCCESS = "BUZZER;50;1";

    //Execute Buzzer
    private static String BUZZER_FAIL = "BUZZER;50;2";
    //Energize Relay-1 by Delay in Ms. 
    private static String ROLE1 = "ROLE1=";

    //Alive message is sent by the Terminal periodically
    private static String ALIVE;
    private static String ROLE2;
    //Set Terminals RTC from server.
    private static String TSYNC;


    //XX Delay in Milliseconds. The Relay is ON with XX Delay. 
    public static String OpenDoorByMilliseconds(int milliseconds)
    {
        return BUZZER_SUCCESS + "," + ROLE1 + milliseconds;
    }
    public static String OpenDoorByMilliseconds(int milliseconds, String message)
    {
        return BUZZER_SUCCESS + "," + ROLE1 + milliseconds + "," + LCDCLR + "," + LCDSET + message;
    }

    //Relay-2 ON or OFF all the time. 
    public static String OpenDoor()
    {
        return BUZZER_SUCCESS + ROLE1 + "ON";
    }
    public static String OpenDoor(String message)
    {
        return BUZZER_SUCCESS + "," + ROLE1 + "ON" + "," + LCDCLR + "," + LCDSET + message;
    }

    //Relay-2 ON or OFF all the time. 
    public static String CloseDoor()
    {
        return BUZZER_FAIL + "," + ROLE1 + "OFF";
    }
    public static String CloseDoor(String message)
    {
        return BUZZER_FAIL + "," + ROLE1 + "OFF" + "," + LCDCLR + "," + LCDSET + message;
    }
    
	public static String getALIVE() {
		return ALIVE;
	}
	public static void setALIVE(String aLIVE) {
		ALIVE = aLIVE;
	}
	public static String getROLE2() {
		return ROLE2;
	}
	public static void setROLE2(String rOLE2) {
		ROLE2 = rOLE2;
	}
	public static String getTSYNC() {
		return TSYNC;
	}
	public static void setTSYNC(String tSYNC) {
		TSYNC = tSYNC;
	}
}
