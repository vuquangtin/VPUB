package com.swt.devices;

import java.awt.image.BufferedImage;
import java.io.BufferedReader;
import java.io.File;
import java.io.InputStreamReader;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.nio.file.Files;
import java.util.Timer;
import java.util.TimerTask;
import java.util.concurrent.atomic.AtomicInteger;

import javax.imageio.ImageIO;

import org.apache.tomcat.util.codec.binary.Base64;

import uk.co.caprica.vlcj.discovery.NativeDiscovery;
import uk.co.caprica.vlcj.player.MediaPlayerFactory;
import uk.co.caprica.vlcj.player.headless.HeadlessMediaPlayer;
import uk.co.caprica.vlcj.runtime.x.LibXUtil;

import com.google.gson.Gson;
import com.swt.object.ShiftReturn;
import com.swt.object.Shift;
import com.swt.object.TimeKeepingAcess;
import com.swt.object.TimeKeepingImage;
import com.swt.service.SystemService;
import com.swt.utilities.AppConfig;
import com.swt.utilities.Logging;

public class MCR02 {

	private static MCR02 Instance = new MCR02();

	private boolean accessStatus = false;

	private static HeadlessMediaPlayer mediaPlayer1;
	private static HeadlessMediaPlayer mediaPlayer2;

	private boolean cameraStatus = false;

	private final int timeOpenDoor = Integer.parseInt(AppConfig.getInstance()
			.getTimeOpenDoor());

	public static MCR02 getInstance() {
		return Instance;
	}

	public void accessStart() {
		setAccessStatus(true);
	}

	public void cameraStart() {
		setCameraStatus(true);
	}

	public void startAccessProcessor() {
		initServer(Integer.parseInt(AppConfig.getInstance().getNumber()));
	}

	static AtomicInteger classCounter = new AtomicInteger();

	private void initServer(int number) {
		// tạo ra nhiều thread, mỗi thread listening 1 port. Từ port trong file
		// config => port + number
		for (int i = 0; i < number; i++) {
			Thread thread = new Thread() {
				public void run() {
					try {
						// lấy port trong file config
						int portReader = Integer.parseInt(AppConfig
								.getInstance().getPortReader())
						// counter multi thread
								+ classCounter.incrementAndGet() - 1;
						Logging.getInstance().writeInfo(
								"Server start listening port " + portReader);
						DatagramSocket serverSocket;
						try {
							serverSocket = new DatagramSocket(portReader);
						} catch (Exception e) {
							// chạy trên windows
							if (System.getProperty("os.name").toLowerCase()
									.indexOf("windows") > -1) {
								// kill process
								killProcessByPortOnWindows(portReader);
							} else {
								// rt.exec("kill -9 $(fuser -v -n udp 6777)"
								// +....);
							}
							Thread.sleep(1000);
							serverSocket = new DatagramSocket(portReader);
						}
						byte[] receiveData = new byte[1024];
						byte[] sendData = new byte[1024];
						while (true) {
							try {
								// UDP
								DatagramPacket receivePacket = new DatagramPacket(
										receiveData, receiveData.length);
								serverSocket.receive(receivePacket);
								String _receiveData = new String(
										receivePacket.getData()).trim();
								InetAddress IPAddress = receivePacket
										.getAddress();
								// MCR02-D5EF11,UID=803219509
								// MCR02-D5EF11,UID=3528E02F
								String[] arrayReceiveData = _receiveData
										.split(",");
								Logging.getInstance().writeInfo(
										new String(receivePacket.getData())
												.trim()
												+ ",IPAddress="
												+ IPAddress.toString());
								String _IP = IPAddress.toString().replaceAll(
										"/", "");
								// devID + ...
								String _sendData = arrayReceiveData[0] + ",";

								// AccessControl
								if (AppConfig.getInstance()
										.isUseAccessControl()) {
									try {
										// mở cửa
										if (checkOnServer(arrayReceiveData[1],
												_IP)) {
											_sendData += MCR02CommandUtils
													.OpenDoorByMilliseconds(timeOpenDoor)
													+ ",TSYNC="
													+ String.valueOf(System
															.currentTimeMillis() / 1000L);
											Logging.getInstance().writeInfo(
													"-----> open");
										} else { // đóng cửa
											_sendData += MCR02CommandUtils
													.CloseDoor()
													+ ",TSYNC="
													+ String.valueOf(System
															.currentTimeMillis() / 1000L);
											Logging.getInstance().writeInfo(
													"-----> close");
										}
										sendData = _sendData.getBytes();
									} catch (Exception e) {
										e.printStackTrace();
									}
								}

								// Timekeeping
								if (AppConfig.getInstance().isUseTimekeeping()) {
									try {
										Logging.getInstance().writeInfo(
												"UseTimekeeping");
										// kiem tra server roi moi gui tin hieu
										// ve dau doc
										if (AppConfig.getInstance()
												.isCheckServerAfterBeep()) {
											// chup hinh save shift
											TimeKeepingAcess timeKeepingAcess = checkIpDeviceForTimeKeeping(
													arrayReceiveData[1], _IP);
											if (timeKeepingAcess != null
													&& timeKeepingAcess
															.getMemberId() > 0) {
												// write shift
												ShiftReturn shiftReturn = inserShift(
														timeKeepingAcess
																.getDeviceDoorId(),
														_IP, timeKeepingAcess
																.getMemberId(),
														arrayReceiveData[1]);
												_sendData += MCR02CommandUtils
														.OpenDoorByMilliseconds(timeOpenDoor)
														+ ",TSYNC="
														+ String.valueOf(System
																.currentTimeMillis() / 1000L);
												Logging.getInstance()
														.writeInfo(
																"-----> Timekeeping");
												// sendData =
												// _sendData.getBytes();
												// chụp hình
												try {
													BufferedImage bi;
													if (AppConfig
															.getInstance()
															.getReaderForCamera2()
															.contains(_IP)) {
														bi = mediaPlayer2
																.getSnapshot();
													} else {
														bi = mediaPlayer1
																.getSnapshot();
													}

													File outputfile = new File(
															"tmp.jpg");
													ImageIO.write(bi, "jpg",
															outputfile);
													byte[] bitImage = null;
													bitImage = Files
															.readAllBytes(outputfile
																	.toPath());
													insertShiftImage(
															shiftReturn.getId(),
															Base64.encodeBase64String(bitImage));
													outputfile.delete();
												} catch (Exception e) {
													Logging.getInstance()
															.writeError(
																	e.getMessage());
													e.printStackTrace();
												}
											} else { // đóng cửa
												_sendData += MCR02CommandUtils
														.CloseDoor()
														+ ",TSYNC="
														+ String.valueOf(System
																.currentTimeMillis() / 1000L);
												Logging.getInstance()
														.writeInfo(
																"-----> Timekeeping Not Ok");
											}
											sendData = _sendData.getBytes();
											Logging.getInstance().writeInfo(
													_sendData);
											// tra tin hieu ve dau doc ngay
											// khong can check server
										} else {
											// 1 beep
//											_sendData += MCR02CommandUtils
//													.OpenDoorByMilliseconds(timeOpenDoor)
//													+ ",TSYNC="
//													+ String.valueOf(System
//															.currentTimeMillis() / 1000L);
											// 2 beep
											_sendData += MCR02CommandUtils
													.CloseDoor()
													+ ",TSYNC="
													+ String.valueOf(System
															.currentTimeMillis() / 1000L);
											Logging.getInstance()
													.writeInfo(
															"-----> Don't check server Timekeeping");
											sendData = _sendData.getBytes();
											Logging.getInstance().writeInfo(
													_sendData);

											new Thread(new Runnable() {
												private String param;

												public Runnable init(
														String param) {
													this.param = param;
													return this;
												}

												@Override
												public void run() {
													Logging.getInstance()
															.writeInfo(
																	"-----> Thread check server and insert shift");
													Logging.getInstance()
															.writeInfo(
																	"Param(UID & IP) "
																			+ this.param);
													String[] arrayParamData = this.param
															.split("&");
													if (arrayParamData.length > 1) {

														String UID_in_param = arrayParamData[0];
														String IP_in_param = arrayParamData[1];
														Logging.getInstance()
																.writeInfo(
																		"UID AND IP "
																				+ UID_in_param
																				+ IP_in_param);
														TimeKeepingAcess timeKeepingAcess = checkIpDeviceForTimeKeeping(
																// UID $$ IP
																UID_in_param,
																IP_in_param);
														if (timeKeepingAcess != null
																&& timeKeepingAcess
																		.getMemberId() > 0) {
															// write shift
															ShiftReturn shiftReturn = inserShift(
																	timeKeepingAcess
																			.getDeviceDoorId(),
																	IP_in_param,
																	timeKeepingAcess
																			.getMemberId(),
																	UID_in_param);
															Logging.getInstance()
																	.writeInfo(
																			"-----> Timekeeping");
															// sendData =
															// _sendData.getBytes();
															// chụp hình
															try {
																BufferedImage bi;
																if (AppConfig
																		.getInstance()
																		.getReaderForCamera2()
																		.contains(
																				IP_in_param)) {
																	bi = mediaPlayer2
																			.getSnapshot();
																} else {
																	bi = mediaPlayer1
																			.getSnapshot();
																}

																File outputfile = new File(
																		"tmp.jpg");
																ImageIO.write(
																		bi,
																		"jpg",
																		outputfile);
																byte[] bitImage = null;
																bitImage = Files
																		.readAllBytes(outputfile
																				.toPath());
																insertShiftImage(
																		shiftReturn
																				.getId(),
																		Base64.encodeBase64String(bitImage));
																outputfile
																		.delete();
															} catch (Exception e) {
																Logging.getInstance()
																		.writeError(
																				e.getMessage());
																e.printStackTrace();
															}
														}
													}
												}
											}.init(arrayReceiveData[1] + "&"
													+ _IP)).start();

										}
									} catch (Exception e) {
										e.printStackTrace();
									}
								}
								// gửi lại tín hiệu cho đầu đọc
								if (AppConfig.getInstance()
										.isUseAccessControl()
										|| AppConfig.getInstance()
												.isUseTimekeeping()) {
									DatagramPacket sendPacket = new DatagramPacket(
											sendData, sendData.length,
											IPAddress, portReader);
									serverSocket.send(sendPacket);
								}
							} catch (Exception e) {
								Logging.getInstance()
										.writeError(e.getMessage());
								e.printStackTrace();
							}
						}
					} catch (Exception e) {
						Logging.getInstance().writeError(e.getMessage());
						e.printStackTrace();
					}
				}
			};
			thread.start();
		}
	}

	/**
	 * kiểm tra camera theo thời gian đã cấu hình
	 */
	public void checkCamera() {
		try {
			for (int i = 0; i < AppConfig.getInstance().getNumberOfCamera(); i++) {
				switch (i) {
				case 0:
					Timer timer = new Timer();
					timer.schedule(new TimerTask() {
						@Override
						public void run() {
							try {
								if (null != mediaPlayer1) {
									if (mediaPlayer1.isPlaying()) {
										Logging.getInstance().writeInfo(
												"Camera 1 playing");
									} else {
										try {
											Logging.getInstance().writeInfo(
													"Camera 1 not play");
											mediaPlayer1.stop();
											startCameraTimeKeeping(1);
										} catch (Exception e) {
											Logging.getInstance().writeError(
													e.getMessage());
										}
									}
								} else {
									Logging.getInstance().writeError(
											"Error Camera 1");
									startCameraTimeKeeping(1);
								}
							} catch (Exception e) {
							}
						}
					}, 0, AppConfig.getInstance().getTimeInspectionCamera());
					break;

				case 1:
					Timer timer1 = new Timer();
					timer1.schedule(new TimerTask() {
						@Override
						public void run() {
							try {
								if (null != mediaPlayer2) {
									if (mediaPlayer2.isPlaying()) {
										Logging.getInstance().writeInfo(
												"Camera 2 playing");
									} else {
										try {
											Logging.getInstance().writeInfo(
													"Camera 2 not play");
											// mediaPlayer.stop();
											startCameraTimeKeeping(2);
										} catch (Exception e) {
											Logging.getInstance().writeError(
													e.getMessage());
										}
									}
								} else {
									Logging.getInstance().writeError(
											"Error Camera 2");
									startCameraTimeKeeping(2);
								}
							} catch (Exception e) {
							}
						}
					}, 0, AppConfig.getInstance().getTimeInspectionCamera());
					break;
				}

			}
		} catch (Exception e) {
			Logging.getInstance().writeError(e.getMessage());
		}
	}

	/**
	 * Start Camera
	 * 
	 * @param number
	 *            0,1,2 start camera all,1,2
	 */
	public void startCameraTimeKeeping(int number) {
		try {
			// NativeLibrary.addSearchPath("libvlc",
			// new File("").getAbsolutePath() + "\\lib_x64");
			// NativeLibrary.addSearchPath("libvlccore",
			// new File("").getAbsolutePath() + "\\lib_x64");
			// System.setProperty("VLC_PLUGIN_PATH", "\\lib_x64\\plugins");
			// NativeLibrary.addSearchPath(RuntimeUtil.getLibVlcLibraryName(),
			// "\\lib_x64");
			// NativeLibrary.addSearchPath("plugins",
			// new File("").getAbsolutePath() + "\\lib_x64\\plugins");
			for (int i = 0; i < AppConfig.getInstance().getNumberOfCamera(); i++) {
				LibXUtil.initialise();
				String[] linkRtsp = new String[1];
				linkRtsp[0] = AppConfig.getInstance().getCameraAddress(i + 1);
				if (linkRtsp.length != 1) {
					Logging.getInstance().writeInfo(
							"Specify a single MRL to stream");
				}
				NativeDiscovery nd = new NativeDiscovery();
				if (!nd.discover()) {
					Logging.getInstance().writeInfo("VLC not found");
				}
				String media = linkRtsp[0];
				MediaPlayerFactory mediaPlayerFactory = null;
				try {
					mediaPlayerFactory = new MediaPlayerFactory(linkRtsp);
				} catch (Exception e) {
					Logging.getInstance().writeError(e.getMessage());
				}
				if (mediaPlayerFactory != null) {
					switch (i) {
					case 0:
						if (number == 1) {
							mediaPlayer1 = mediaPlayerFactory
									.newHeadlessMediaPlayer();
							mediaPlayer1
									.playMedia(
											media,
											"" /* options */,
											"--no-snapshot-preview",
											"--ignore-config",
											"--network-caching=500",
											"--no-osd",
											"--no-video-title-show",
											"--no-audio",
											"--no-overlay",
											"--no-video-on-top",
											"--intf",
											"dummy", // no interface
											"--vout",
											"dummy", // we don't want video
														// (output)
											"--no-stats", // no stats
											"--no-sub-autodetect-file", // we
																		// don't
																		// want
																		// subtitles
											"--no-inhibit", // we don't want
															// interfaces
											"--no-disable-screensaver", // we
																		// don't
																		// want
																		// interfaces
											":no-sout-rtp-sap",
											":no-sout-standard-sap");
						}
						break;
					case 1:
						if (number == 2) {
							mediaPlayer2 = mediaPlayerFactory
									.newHeadlessMediaPlayer();
							mediaPlayer2
									.playMedia(
											media,
											"" /* options */,
											"--no-snapshot-preview",
											"--ignore-config",
											"--network-caching=500",
											"--no-osd",
											"--no-video-title-show",
											"--no-audio",
											"--no-overlay",
											"--no-video-on-top",
											"--intf",
											"dummy", // no interface
											"--vout",
											"dummy", // we don't want video
														// (output)
											"--no-stats", // no stats
											"--no-sub-autodetect-file", // we
																		// don't
																		// want
																		// subtitles
											"--no-inhibit", // we don't want
															// interfaces
											"--no-disable-screensaver", // we
																		// don't
																		// want
																		// interfaces
											":no-sout-rtp-sap",
											":no-sout-standard-sap");
						}
						break;
					}
				}
			}
			// Don't exit
			// Thread.currentThread().join();
		} catch (Exception e) {
			Logging.getInstance().writeError(e.getMessage());
		}
	}

	/**
	 * getSerial tùy đầu đọc trả về hex hay long
	 * 
	 * @param _UID
	 * @return
	 */
	private String getSerial(String _UID) {
		String _serial = "";
		try {
			// ví dụ UID=803219509
			_serial = longToHexStringForMCR02(
					Long.parseLong(_UID.substring(4).trim()), 8);
		} catch (Exception e) {
			// ví dụ UID=3528E02F
			_serial = _UID.substring(4, 12);
		}
		return _serial;
	}

	/**
	 * Inser Shift
	 * 
	 * @param deviceDoorId
	 * @param _IP
	 * @param memberId
	 * @param _UID
	 * @return
	 */
	private ShiftReturn inserShift(long deviceDoorId, String _IP,
			long memberId, String _UID) {
		Shift shift = new Shift();
		shift.setDeviceDoorId(deviceDoorId);
		shift.setDeviceDoorIp(_IP);
		shift.setMemberId(memberId);
		shift.setSerialNumber(getSerial(_UID));
		return SystemService.getInstance()
				.insertShift(new Gson().toJson(shift));
	}

	private TimeKeepingImage insertShiftImage(long timekeepingShiftId,
			String _image) {
		TimeKeepingImage timeKeepingImage = new TimeKeepingImage();
		timeKeepingImage.setImage(_image);
		return SystemService.getInstance().insertShiftImage(
				new Gson().toJson(timeKeepingImage), timekeepingShiftId);
	}

	private TimeKeepingAcess checkIpDeviceForTimeKeeping(String _UID, String _IP) {
		return SystemService.getInstance().checkIpDeviceForTimeKeeping(
				getSerial(_UID), _IP);
	}

	private boolean checkOnServer(String _UID, String _IP) {
		Logging.getInstance().writeInfo(getSerial(_UID));
		return SystemService.getInstance().accessProcess(getSerial(_UID), _IP);
	}

	/**
	 * long to hex MCR02, sắp xếp lại byte
	 * 
	 * @param id
	 * @param length
	 * @return
	 */
	private String longToHexStringForMCR02(long id, int length) {
		// ví dụ UID = 803219509
		String _s = Long.toHexString(id).toUpperCase();
		// => UID = 2FE02835
		String result = "";
		for (int i = 0; i < length / 2; i++) {
			result += _s.substring(_s.length() - 2);
			_s = _s.substring(0, _s.length() - 2);
		}
		// => UID = 3528E02F
		return result;
	}

	public boolean isAccessStatus() {
		return accessStatus;
	}

	public void setAccessStatus(boolean accessStatus) {
		this.accessStatus = accessStatus;
	}

	private void killProcessByPortOnWindows(int port) {
		try {
			String cmd = "cmd /c netstat -o -n -a | findstr 0.0:" + port;
			Runtime rt = Runtime.getRuntime();
			Process p = null;
			try {
				p = rt.exec(cmd);
			} catch (Exception e) {
				e.printStackTrace();
			}
			StringBuffer sbInput = new StringBuffer();
			BufferedReader brInput = new BufferedReader(new InputStreamReader(
					p.getInputStream()));
			BufferedReader brError = new BufferedReader(new InputStreamReader(
					p.getErrorStream()));
			String line;
			try {
				while ((line = brError.readLine()) != null) {
				}
			} catch (Exception e) {
				e.printStackTrace();
			}
			try {
				while ((line = brInput.readLine()) != null) {
					sbInput.append(line + "\n");
				}
			} catch (Exception e) {
				e.printStackTrace();
			}
			try {
				p.waitFor();
			} catch (InterruptedException e) {
				e.printStackTrace();
			}
			p.destroy();
			String resultString = sbInput.toString();
			resultString = resultString.substring(
					resultString.lastIndexOf(" ", resultString.length()))
					.replace("\n", "");
			cmd = "taskkill /F /PID " + resultString;
			Runtime.getRuntime().exec(cmd);
		} catch (Exception e) {
		}
	}

	public boolean isCameraStatus() {
		return cameraStatus;
	}

	public void setCameraStatus(boolean cameraStatus) {
		this.cameraStatus = cameraStatus;
	}
}
