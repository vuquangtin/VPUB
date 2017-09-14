package com.swt.utilities;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.util.Properties;

public class AppConfig {

	private static AppConfig Instance = new AppConfig();

	public static AppConfig getInstance() {
		return Instance;
	}

	public AppConfig() {
		LoadConfig();
	}

	public void LoadConfig() {
		try {
			File configFile = new File("config.xml");
			InputStream inputStream = new FileInputStream(configFile);
			Properties props = new Properties();
			props.loadFromXML(inputStream);

			setJavaWebService(props.getProperty("JavaWebService"));
			setUser(props.getProperty("User"));
			setPassworld(props.getProperty("Password"));
			setUseTimekeeping(Boolean.valueOf(props
					.getProperty("UseTimekeeping")));
			setUseAccessControl(Boolean.valueOf(props
					.getProperty("UseAccessControl")));
			setCameraAddress1(props.getProperty("CameraAddress1"));
			setCameraAddress2(props.getProperty("CameraAddress2"));
			setReaderForCamera1(props.getProperty("ReaderForCamera1"));
			setReaderForCamera2(props.getProperty("ReaderForCamera2"));
			// số lượng port sử dụng
			setNumber(props.getProperty("Number"));
			// port sử dụng
			setPortReader(props.getProperty("PortReader"));
			setTimeOpenDoor(props.getProperty("TimeOpenDoor"));
			setMode(props.getProperty("Mode"));
			setTimeInspectionCamera(Integer.valueOf(props
					.getProperty("TimeInspectionCamera")));
			setTimeInspectionServer(Integer.valueOf(props
					.getProperty("TimeInspectionServer")));
			setNumberOfCamera(Integer.valueOf(props
					.getProperty("NumberOfCamera")));
			setCheckServerAfterBeep(Boolean.valueOf(props
					.getProperty("CheckServerAfterBeep")));

			inputStream.close();
		} catch (Exception ex) {
			// tạo file config default nếu chưa có
			Properties defaultProps = new Properties();
			// web service
			defaultProps.setProperty("JavaWebService",
					"http://192.168.1.141:80/sworldwebservice/sworld");
			defaultProps.setProperty("User", "swtadmin");
			defaultProps.setProperty("Password", "1");
			defaultProps.setProperty("UseTimekeeping", "true");
			defaultProps.setProperty("UseAccessControl", "true");
			// số lượng camera được sử dụng
			defaultProps.setProperty("NumberOfCamera", "1");
			defaultProps.setProperty("CameraAddress1",
					"rtsp://192.168.1.91:554/video.mp4");
			defaultProps.setProperty("CameraAddress2",
					"rtsp://192.168.1.90:554/video.mp4");
			// IP của đầu đọc cho camera theo số thứ tự, sử dụng dấu ',' nếu nhiều đầu đọc
			defaultProps.setProperty("ReaderForCamera1", "192.168.1.78");
			defaultProps.setProperty("ReaderForCamera2", "192.168.1.77");
			// số lượng port mở ra để listerning tín hiệu từ đầu đọc
			defaultProps.setProperty("Number", "3");
			// port bắt đầu
			defaultProps.setProperty("PortReader", "6777");
			// thời gian chờ khi mở cửa thành công
			defaultProps.setProperty("TimeOpenDoor", "5000");
			// mode phân quyền theo tòa nhà '12121212', hay theo device
			defaultProps.setProperty("Mode", "1212121211");
			// thời gian kiểm tra camera, server 'Timer check'
			defaultProps.setProperty("TimeInspectionCamera", "30000");
			defaultProps.setProperty("TimeInspectionServer", "30000");
			
			defaultProps.setProperty("CheckServerAfterBeep", "false");

			try {
				File configFileDefault = new File("config.xml");
				OutputStream outputStream = new FileOutputStream(
						configFileDefault);
				defaultProps.storeToXML(outputStream, "App Config");
			} catch (IOException e) {
				e.printStackTrace();
			}
		}
	}

	private String javaWebService;
	private String user;
	private String passworld;
	private boolean useTimekeeping;
	private boolean useAccessControl;
	private String cameraAddress1;
	private String cameraAddress2;
	private String readerForCamera1;
	private String readerForCamera2;
	private String number;
	private String portReader;
	private String timeOpenDoor;
	private String mode;
	private int timeInspectionCamera;
	private int timeInspectionServer;
	private int numberOfCamera;
	
	private boolean checkServerAfterBeep;

	public int getTimeInspectionCamera() {
		return timeInspectionCamera;
	}

	public void setTimeInspectionCamera(int timeInspectionCamera) {
		this.timeInspectionCamera = timeInspectionCamera;
	}

	public String getMode() {
		return mode;
	}

	public void setMode(String mode) {
		this.mode = mode;
	}

	public String getJavaWebService() {
		return javaWebService;
	}

	public void setJavaWebService(String javaWebService) {
		this.javaWebService = javaWebService;
	}

	public String getUser() {
		return user;
	}

	public void setUser(String user) {
		this.user = user;
	}

	public String getPassworld() {
		return passworld;
	}

	public void setPassworld(String passworld) {
		this.passworld = passworld;
	}

	public static void setInstance(AppConfig instance) {
		Instance = instance;
	}

	public String getNumber() {
		return number;
	}

	public void setNumber(String number) {
		this.number = number;
	}

	public String getPortReader() {
		return portReader;
	}

	public void setPortReader(String portReader) {
		this.portReader = portReader;
	}

	public String getTimeOpenDoor() {
		return timeOpenDoor;
	}

	public void setTimeOpenDoor(String timeOpenDoor) {
		this.timeOpenDoor = timeOpenDoor;
	}

	public boolean isUseAccessControl() {
		return useAccessControl;
	}

	public void setUseAccessControl(boolean useAccessControl) {
		this.useAccessControl = useAccessControl;
	}

	public boolean isUseTimekeeping() {
		return useTimekeeping;
	}

	public void setUseTimekeeping(boolean useTimekeeping) {
		this.useTimekeeping = useTimekeeping;
	}

	public int getTimeInspectionServer() {
		return timeInspectionServer;
	}

	public void setTimeInspectionServer(int timeInspectionServer) {
		this.timeInspectionServer = timeInspectionServer;
	}

	public int getNumberOfCamera() {
		return numberOfCamera;
	}

	public void setNumberOfCamera(int numberOfCamera) {
		this.numberOfCamera = numberOfCamera;
	}

	public String getCameraAddress1() {
		return cameraAddress1;
	}

	public void setCameraAddress1(String cameraAddress1) {
		this.cameraAddress1 = cameraAddress1;
	}

	public String getCameraAddress2() {
		return cameraAddress2;
	}

	public void setCameraAddress2(String cameraAddress2) {
		this.cameraAddress2 = cameraAddress2;
	}

	public String getCameraAddress(int number) {
		switch (number) {
		case 1:
			return cameraAddress1;
		default:
			return cameraAddress2;
		}
	}

	public String getReaderForCamera1() {
		return readerForCamera1;
	}

	public void setReaderForCamera1(String readerForCamera1) {
		this.readerForCamera1 = readerForCamera1;
	}

	public String getReaderForCamera2() {
		return readerForCamera2;
	}

	public void setReaderForCamera2(String readerForCamera2) {
		this.readerForCamera2 = readerForCamera2;
	}

	public String getReaderForCamera(int number) {
		switch (number) {
		case 1:
			return readerForCamera1;
		default:
			return readerForCamera2;
		}
	}

	public boolean isCheckServerAfterBeep() {
		return checkServerAfterBeep;
	}

	public void setCheckServerAfterBeep(boolean checkServerAfterBeep) {
		this.checkServerAfterBeep = checkServerAfterBeep;
	}
}
